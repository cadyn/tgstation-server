﻿namespace Tgstation.Server.Host.Models
{
	sealed class ChatSettings : Api.Models.ChatSettings
	{
		public long Id { get; set; }

		public long InstanceId { get; set; }
	}
}
