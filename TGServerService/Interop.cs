﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;
using System.Web.Security;
using TGServiceInterface;

namespace TGServerService
{
	//handles talking between the world and us
	partial class TGStationServer : ITGInterop
	{

		object topicLock = new object();
		const int CommsKeyLen = 64;
		string serviceCommsKey; //regenerated every DD restart

		//range of supported api versions
		readonly Version MinAPIVersion = new Version("3.1.0.0");
		readonly Version MaxAPIVersion = new Version("3.1.0.99");
		Version GameAPIVersion;

		//See code/modules/server_tools/server_tools.dm for command switch
		const string SCHardReboot = "hard_reboot";  //requests that dreamdaemon restarts when the round ends
		const string SCGracefulShutdown = "graceful_shutdown";  //requests that dreamdaemon stops when the round ends
		const string SCWorldAnnounce = "world_announce";	//sends param 'message' to the world
		const string SCListCustomCommands = "list_custom_commands"; //Get a list of commands supported by the server
		const string SCAPICompat = "api_compat";    //Tells the server we understand each other
		const string SCPlayerCount = "client_count";	//Gets the number of connected clients

		const string SRKillProcess = "killme";
		const string SRIRCBroadcast = "irc";
		const string SRIRCAdminChannelMessage = "send2irc";
		const string SRWorldReboot = "worldreboot";
		const string SRAPIVersion = "api_ver";

		const string CCPHelpText = "help_text";
		const string CCPAdminOnly = "admin_only";
		const string CCPRequiredParameters = "required_parameters";

		List<Command> ServerChatCommands;

		void LoadServerChatCommands()
		{
			if (DaemonStatus() != TGDreamDaemonStatus.Online)
				return;
			var json = SendCommand(SCListCustomCommands);
			if (String.IsNullOrWhiteSpace(json))
				return;
			List<Command> tmp = new List<Command>();
			try
			{
				foreach(var I in new JavaScriptSerializer().Deserialize<IDictionary<string, IDictionary<string, object>>>(json))
					tmp.Add(new ServerChatCommand(I.Key, (string)I.Value[CCPHelpText], ((int)I.Value[CCPAdminOnly]) == 1, (int)I.Value[CCPRequiredParameters]));
				ServerChatCommands = tmp;
			}
			catch { }
		}

		//raw command string sent here via world.ExportService
		void HandleCommand(string cmd)
		{
			var splits = new List<string>(cmd.Split(' '));
			cmd = splits[0];
			splits.RemoveAt(0);

			bool APIValid;
			lock (topicLock)
			{
				APIValid = CheckAPIVersionConstraints();
			}

			if (!APIValid && cmd != SRAPIVersion)
				return;	//SPEAK THE LANGUAGE!!!

			switch (cmd)
			{
				case SRIRCBroadcast:
					SendMessage("GAME: " + String.Join(" ", splits), ChatMessageType.GameInfo);
					break;
				case SRKillProcess:
					KillMe();
					break;
				case SRIRCAdminChannelMessage:
					SendMessage("RELAY: " + String.Join(" ", splits), ChatMessageType.AdminInfo);
					break;
				case SRWorldReboot:
					TGServerService.WriteInfo("World Rebooted", TGServerService.EventID.WorldReboot);
					ServerChatCommands = null;
					ChatConnectivityCheck();
					lock (CompilerLock)
					{
						if (UpdateStaged)
						{
							UpdateStaged = false;
							lock (topicLock)
							{
								GameAPIVersion = null;  //needs updating
							}
							TGServerService.WriteInfo("Staged update applied", TGServerService.EventID.ServerUpdateApplied);
						}
					}
					break;
				case SRAPIVersion:
					lock (topicLock)
					{
						try
						{
							GameAPIVersion = new Version(splits[0]);
							if (!CheckAPIVersionConstraints())
								throw new Exception();
						}
						catch
						{
							TGServerService.WriteWarning(String.Format("API version of the game ({0}) is incompatible with the current supported API versions (Min: {1}. Max: {2}). Interop disabled.", splits.Count > 1 ? splits[1] : "NULL", MinAPIVersion, MaxAPIVersion), TGServerService.EventID.APIVersionMismatch);
							GameAPIVersion = null;
							break;
						}
					}
					//This needs to be done asyncronously otherwise DD won't be able to process it, because it's waiting for THIS THREAD to return
					ThreadPool.QueueUserWorkItem(_ => SendCommand(SCAPICompat));
					break;
			}
		}

		public string SendCommand(string cmd)
		{
			lock (watchdogLock)
			{
				if (currentStatus != TGDreamDaemonStatus.Online)
					return "Error: Server Offline!";
				return SendTopic(String.Format("serviceCommsKey={0};command={1}", serviceCommsKey, cmd), currentPort);
			}
		}

		public int PlayerCount()
		{
			try
			{
				return Convert.ToInt32(SendCommand(SCPlayerCount));
			}
			catch
			{
				return -1;
			}
		}

		//requires topiclock
		bool CheckAPIVersionConstraints()
		{
			return !(GameAPIVersion == null || GameAPIVersion < MinAPIVersion || GameAPIVersion > MaxAPIVersion);
		}

		public static string SanitizeTopicString(string input)
		{
			return input.Replace("%", "%25").Replace("=", "%3d").Replace(";", "%3b").Replace("&", "%26").Replace("+", "%2b");
		}

		//Fuckery to diddle byond with the right packet to accept our girth
		string SendTopic(string topicdata, ushort port)
		{
			//santize the escape characters in accordance with http://www.byond.com/docs/ref/info.html#/proc/params2list
			lock (topicLock) {
				if (!CheckAPIVersionConstraints())
					return "Incompatible API!";
				using (var topicSender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp) { SendTimeout = 5000, ReceiveTimeout = 5000 })
				{
					try
					{
						topicSender.Connect(IPAddress.Loopback, port);

						StringBuilder stringPacket = new StringBuilder();
						stringPacket.Append((char)'\x00', 8);
						stringPacket.Append('?' + topicdata);
						stringPacket.Append((char)'\x00');
						string fullString = stringPacket.ToString();
						var packet = Encoding.ASCII.GetBytes(fullString);
						packet[1] = 0x83;
						var FinalLength = packet.Length - 4;
						if (FinalLength > UInt16.MaxValue)
							return "Error: Topic too long";

						var lengthBytes = BitConverter.GetBytes((ushort)FinalLength);

						packet[2] = lengthBytes[1]; //fucking endianess
						packet[3] = lengthBytes[0];

						topicSender.Send(packet);

						string returnedString = "NULL";
						try
						{
							var returnedData = new byte[UInt16.MaxValue];
							topicSender.Receive(returnedData);
							var raw_string = Encoding.ASCII.GetString(returnedData).TrimEnd(new char[] { (char)0 }).Trim();
							if (raw_string.Length > 6)
								returnedString = raw_string.Substring(5, raw_string.Length - 5).Trim();
						}
						catch
						{
							returnedString = "Topic recieve error!";
						}
						finally
						{
							topicSender.Shutdown(SocketShutdown.Both);
						}
						
						return returnedString;
					}
					catch
					{
						return "Topic delivery failed!";
					}
				}
			}
		}

		//Every time we make a new DD process we generate a new comms key for security
		//It's in world.params['server_service']
		void GenCommsKey()
		{
			var charsToRemove = new string[] { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "_", "-", "+", "=", "[", "{", "]", "}", ";", ":", "<", ">", "|", ".", "/", "?" };
			serviceCommsKey = String.Empty;
			do {
				var tmp = Membership.GeneratePassword(CommsKeyLen, 0);
				foreach (var c in charsToRemove)
					tmp = tmp.Replace(c, String.Empty);
				serviceCommsKey += tmp;
			} while (serviceCommsKey.Length < CommsKeyLen);
			serviceCommsKey = serviceCommsKey.Substring(0, CommsKeyLen);
			TGServerService.WriteInfo("Service Comms Key set to: " + serviceCommsKey, TGServerService.EventID.CommsKeySet);
		}

		/// <inheritdoc />
		public bool InteropMessage(string command)
		{
			try
			{
				HandleCommand(command);
				return true;
			}
			catch(Exception e)
			{
				TGServerService.WriteWarning(String.Format("Handle command for \"{0}\" failed: {1}", command, e.ToString()), TGServerService.EventID.InteropCallException);
				return false;
			}
		}
	}
}
