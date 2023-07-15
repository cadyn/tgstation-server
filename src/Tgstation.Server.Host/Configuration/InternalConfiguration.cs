﻿namespace Tgstation.Server.Host.Configuration
{
	/// <summary>
	/// Unstable configuration options used internally by TGS.
	/// </summary>
	public sealed class InternalConfiguration
	{
		/// <summary>
		/// The key for the <see cref="Microsoft.Extensions.Configuration.IConfigurationSection"/> the <see cref="InternalConfiguration"/> resides in.
		/// </summary>
		public const string Section = "Internal";

		/// <summary>
		/// The name of the pipe opened by the host watchdog, if any.
		/// </summary>
		public string CommandPipe { get; set; }

		/// <summary>
		/// If the server is running under SystemD.
		/// </summary>
		public bool UsingSystemD { get; set; }

		/// <summary>
		/// The base path for the app settings configuration files.
		/// </summary>
		public string AppSettingsBasePath { get; set; }
	}
}