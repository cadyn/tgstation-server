﻿// <auto-generated />
using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tgstation.Server.Host.Database.Migrations
{
	[DbContext(typeof(MySqlDatabaseContext))]
	[Migration("20231220032515_MYAddTopicPort")]
	partial class MYAddTopicPort
	{
		/// <inheritdoc />
		protected override void BuildTargetModel(ModelBuilder modelBuilder)
		{
#pragma warning disable 612, 618
			modelBuilder
				.HasAnnotation("ProductVersion", "8.0.0")
				.HasAnnotation("Relational:MaxIdentifierLength", 64);

			modelBuilder.Entity("Tgstation.Server.Host.Models.ChatBot", b =>
			{
				b.Property<long?>("Id")
					.ValueGeneratedOnAdd()
					.HasColumnType("bigint");

				b.Property<ushort?>("ChannelLimit")
					.IsRequired()
					.HasColumnType("smallint unsigned");

				b.Property<string>("ConnectionString")
					.IsRequired()
					.HasMaxLength(10000)
					.HasColumnType("longtext");

				MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("ConnectionString"), "utf8mb4");

				b.Property<bool?>("Enabled")
					.HasColumnType("tinyint(1)");

				b.Property<long>("InstanceId")
					.HasColumnType("bigint");

				b.Property<string>("Name")
					.IsRequired()
					.HasMaxLength(100)
					.HasColumnType("varchar(100)");

				b.Property<int>("Provider")
					.HasColumnType("int");

				b.Property<uint?>("ReconnectionInterval")
					.IsRequired()
					.HasColumnType("int unsigned");

				b.HasKey("Id");

				b.HasIndex("InstanceId", "Name")
					.IsUnique();

				b.ToTable("ChatBots");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.ChatChannel", b =>
			{
				b.Property<long>("Id")
					.ValueGeneratedOnAdd()
					.HasColumnType("bigint");

				b.Property<long>("ChatSettingsId")
					.HasColumnType("bigint");

				b.Property<ulong?>("DiscordChannelId")
					.HasColumnType("bigint unsigned");

				b.Property<string>("IrcChannel")
					.HasMaxLength(100)
					.HasColumnType("varchar(100)");

				MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("IrcChannel"), "utf8mb4");

				b.Property<bool?>("IsAdminChannel")
					.IsRequired()
					.HasColumnType("tinyint(1)");

				b.Property<bool?>("IsSystemChannel")
					.IsRequired()
					.HasColumnType("tinyint(1)");

				b.Property<bool?>("IsUpdatesChannel")
					.IsRequired()
					.HasColumnType("tinyint(1)");

				b.Property<bool?>("IsWatchdogChannel")
					.IsRequired()
					.HasColumnType("tinyint(1)");

				b.Property<string>("Tag")
					.HasMaxLength(10000)
					.HasColumnType("longtext");

				MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Tag"), "utf8mb4");

				b.HasKey("Id");

				b.HasIndex("ChatSettingsId", "DiscordChannelId")
					.IsUnique();

				b.HasIndex("ChatSettingsId", "IrcChannel")
					.IsUnique();

				b.ToTable("ChatChannels");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.CompileJob", b =>
			{
				b.Property<long?>("Id")
					.ValueGeneratedOnAdd()
					.HasColumnType("bigint");

				b.Property<int?>("DMApiMajorVersion")
					.HasColumnType("int");

				b.Property<int?>("DMApiMinorVersion")
					.HasColumnType("int");

				b.Property<int?>("DMApiPatchVersion")
					.HasColumnType("int");

				b.Property<Guid?>("DirectoryName")
					.IsRequired()
					.HasColumnType("char(36)");

				b.Property<string>("DmeName")
					.IsRequired()
					.HasColumnType("longtext");

				MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("DmeName"), "utf8mb4");

				b.Property<string>("EngineVersion")
					.IsRequired()
					.HasColumnType("longtext");

				MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("EngineVersion"), "utf8mb4");

				b.Property<int?>("GitHubDeploymentId")
					.HasColumnType("int");

				b.Property<long?>("GitHubRepoId")
					.HasColumnType("bigint");

				b.Property<long>("JobId")
					.HasColumnType("bigint");

				b.Property<int?>("MinimumSecurityLevel")
					.HasColumnType("int");

				b.Property<string>("Output")
					.IsRequired()
					.HasColumnType("longtext");

				MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Output"), "utf8mb4");

				b.Property<string>("RepositoryOrigin")
					.HasColumnType("longtext");

				MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("RepositoryOrigin"), "utf8mb4");

				b.Property<long>("RevisionInformationId")
					.HasColumnType("bigint");

				b.HasKey("Id");

				b.HasIndex("DirectoryName");

				b.HasIndex("JobId")
					.IsUnique();

				b.HasIndex("RevisionInformationId");

				b.ToTable("CompileJobs");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.DreamDaemonSettings", b =>
			{
				b.Property<long>("Id")
					.ValueGeneratedOnAdd()
					.HasColumnType("bigint");

				b.Property<string>("AdditionalParameters")
					.IsRequired()
					.HasMaxLength(10000)
					.HasColumnType("longtext");

				MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("AdditionalParameters"), "utf8mb4");

				b.Property<bool?>("AllowWebClient")
					.IsRequired()
					.HasColumnType("tinyint(1)");

				b.Property<bool?>("AutoStart")
					.IsRequired()
					.HasColumnType("tinyint(1)");

				b.Property<bool?>("DumpOnHealthCheckRestart")
					.IsRequired()
					.HasColumnType("tinyint(1)");

				b.Property<uint?>("HealthCheckSeconds")
					.IsRequired()
					.HasColumnType("int unsigned");

				b.Property<long>("InstanceId")
					.HasColumnType("bigint");

				b.Property<bool?>("LogOutput")
					.IsRequired()
					.HasColumnType("tinyint(1)");

				b.Property<uint?>("MapThreads")
					.IsRequired()
					.HasColumnType("int unsigned");

				b.Property<ushort?>("Port")
					.IsRequired()
					.HasColumnType("smallint unsigned");

				b.Property<int>("SecurityLevel")
					.HasColumnType("int");

				b.Property<bool?>("StartProfiler")
					.IsRequired()
					.HasColumnType("tinyint(1)");

				b.Property<uint?>("StartupTimeout")
					.IsRequired()
					.HasColumnType("int unsigned");

				b.Property<uint?>("TopicRequestTimeout")
					.IsRequired()
					.HasColumnType("int unsigned");

				b.Property<int>("Visibility")
					.HasColumnType("int");

				b.HasKey("Id");

				b.HasIndex("InstanceId")
					.IsUnique();

				b.ToTable("DreamDaemonSettings");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.DreamMakerSettings", b =>
			{
				b.Property<long>("Id")
					.ValueGeneratedOnAdd()
					.HasColumnType("bigint");

				b.Property<ushort?>("ApiValidationPort")
					.IsRequired()
					.HasColumnType("smallint unsigned");

				b.Property<int>("ApiValidationSecurityLevel")
					.HasColumnType("int");

				b.Property<long>("InstanceId")
					.HasColumnType("bigint");

				b.Property<string>("ProjectName")
					.HasMaxLength(10000)
					.HasColumnType("longtext");

				MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("ProjectName"), "utf8mb4");

				b.Property<bool?>("RequireDMApiValidation")
					.IsRequired()
					.HasColumnType("tinyint(1)");

				b.Property<TimeSpan?>("Timeout")
					.IsRequired()
					.HasColumnType("time(6)");

				b.HasKey("Id");

				b.HasIndex("InstanceId")
					.IsUnique();

				b.ToTable("DreamMakerSettings");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.Instance", b =>
			{
				b.Property<long?>("Id")
					.ValueGeneratedOnAdd()
					.HasColumnType("bigint");

				b.Property<uint?>("AutoUpdateInterval")
					.IsRequired()
					.HasColumnType("int unsigned");

				b.Property<ushort?>("ChatBotLimit")
					.IsRequired()
					.HasColumnType("smallint unsigned");

				b.Property<int>("ConfigurationType")
					.HasColumnType("int");

				b.Property<string>("Name")
					.IsRequired()
					.HasMaxLength(100)
					.HasColumnType("varchar(100)");

				MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Name"), "utf8mb4");

				b.Property<bool?>("Online")
					.IsRequired()
					.HasColumnType("tinyint(1)");

				b.Property<string>("Path")
					.IsRequired()
					.HasColumnType("varchar(255)");

				MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Path"), "utf8mb4");

				b.Property<string>("SwarmIdentifer")
					.HasColumnType("varchar(255)");

				MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("SwarmIdentifer"), "utf8mb4");

				b.HasKey("Id");

				b.HasIndex("Path", "SwarmIdentifer")
					.IsUnique();

				b.ToTable("Instances");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.InstancePermissionSet", b =>
			{
				b.Property<long>("Id")
					.ValueGeneratedOnAdd()
					.HasColumnType("bigint");

				b.Property<ulong>("ChatBotRights")
					.HasColumnType("bigint unsigned");

				b.Property<ulong>("ConfigurationRights")
					.HasColumnType("bigint unsigned");

				b.Property<ulong>("DreamDaemonRights")
					.HasColumnType("bigint unsigned");

				b.Property<ulong>("DreamMakerRights")
					.HasColumnType("bigint unsigned");

				b.Property<ulong>("EngineRights")
					.HasColumnType("bigint unsigned");

				b.Property<long>("InstanceId")
					.HasColumnType("bigint");

				b.Property<ulong>("InstancePermissionSetRights")
					.HasColumnType("bigint unsigned");

				b.Property<long>("PermissionSetId")
					.HasColumnType("bigint");

				b.Property<ulong>("RepositoryRights")
					.HasColumnType("bigint unsigned");

				b.HasKey("Id");

				b.HasIndex("InstanceId");

				b.HasIndex("PermissionSetId", "InstanceId")
					.IsUnique();

				b.ToTable("InstancePermissionSets");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.Job", b =>
			{
				b.Property<long?>("Id")
					.ValueGeneratedOnAdd()
					.HasColumnType("bigint");

				b.Property<ulong?>("CancelRight")
					.HasColumnType("bigint unsigned");

				b.Property<ulong?>("CancelRightsType")
					.HasColumnType("bigint unsigned");

				b.Property<bool?>("Cancelled")
					.IsRequired()
					.HasColumnType("tinyint(1)");

				b.Property<long?>("CancelledById")
					.HasColumnType("bigint");

				b.Property<string>("Description")
					.IsRequired()
					.HasColumnType("longtext");

				MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Description"), "utf8mb4");

				b.Property<uint?>("ErrorCode")
					.HasColumnType("int unsigned");

				b.Property<string>("ExceptionDetails")
					.HasColumnType("longtext");

				MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("ExceptionDetails"), "utf8mb4");

				b.Property<long>("InstanceId")
					.HasColumnType("bigint");

				b.Property<byte>("JobCode")
					.HasColumnType("tinyint unsigned");

				b.Property<DateTimeOffset?>("StartedAt")
					.IsRequired()
					.HasColumnType("datetime(6)");

				b.Property<long>("StartedById")
					.HasColumnType("bigint");

				b.Property<DateTimeOffset?>("StoppedAt")
					.HasColumnType("datetime(6)");

				b.HasKey("Id");

				b.HasIndex("CancelledById");

				b.HasIndex("InstanceId");

				b.HasIndex("StartedById");

				b.ToTable("Jobs");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.OAuthConnection", b =>
			{
				b.Property<long>("Id")
					.ValueGeneratedOnAdd()
					.HasColumnType("bigint");

				b.Property<string>("ExternalUserId")
					.IsRequired()
					.HasMaxLength(100)
					.HasColumnType("varchar(100)");

				MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("ExternalUserId"), "utf8mb4");

				b.Property<int>("Provider")
					.HasColumnType("int");

				b.Property<long?>("UserId")
					.HasColumnType("bigint");

				b.HasKey("Id");

				b.HasIndex("UserId");

				b.HasIndex("Provider", "ExternalUserId")
					.IsUnique();

				b.ToTable("OAuthConnections");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.PermissionSet", b =>
			{
				b.Property<long?>("Id")
					.ValueGeneratedOnAdd()
					.HasColumnType("bigint");

				b.Property<ulong>("AdministrationRights")
					.HasColumnType("bigint unsigned");

				b.Property<long?>("GroupId")
					.HasColumnType("bigint");

				b.Property<ulong>("InstanceManagerRights")
					.HasColumnType("bigint unsigned");

				b.Property<long?>("UserId")
					.HasColumnType("bigint");

				b.HasKey("Id");

				b.HasIndex("GroupId")
					.IsUnique();

				b.HasIndex("UserId")
					.IsUnique();

				b.ToTable("PermissionSets");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.ReattachInformation", b =>
			{
				b.Property<long?>("Id")
					.ValueGeneratedOnAdd()
					.HasColumnType("bigint");

				b.Property<string>("AccessIdentifier")
					.IsRequired()
					.HasColumnType("longtext");

				MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("AccessIdentifier"), "utf8mb4");

				b.Property<long>("CompileJobId")
					.HasColumnType("bigint");

				b.Property<long?>("InitialCompileJobId")
					.HasColumnType("bigint");

				b.Property<int>("LaunchSecurityLevel")
					.HasColumnType("int");

				b.Property<int>("LaunchVisibility")
					.HasColumnType("int");

				b.Property<ushort>("Port")
					.HasColumnType("smallint unsigned");

				b.Property<int>("ProcessId")
					.HasColumnType("int");

				b.Property<int>("RebootState")
					.HasColumnType("int");

				b.Property<ushort?>("TopicPort")
					.HasColumnType("smallint unsigned");

				b.HasKey("Id");

				b.HasIndex("CompileJobId");

				b.HasIndex("InitialCompileJobId");

				b.ToTable("ReattachInformations");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.RepositorySettings", b =>
			{
				b.Property<long>("Id")
					.ValueGeneratedOnAdd()
					.HasColumnType("bigint");

				b.Property<string>("AccessToken")
					.HasMaxLength(10000)
					.HasColumnType("longtext");

				MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("AccessToken"), "utf8mb4");

				b.Property<string>("AccessUser")
					.HasMaxLength(10000)
					.HasColumnType("longtext");

				MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("AccessUser"), "utf8mb4");

				b.Property<bool?>("AutoUpdatesKeepTestMerges")
					.IsRequired()
					.HasColumnType("tinyint(1)");

				b.Property<bool?>("AutoUpdatesSynchronize")
					.IsRequired()
					.HasColumnType("tinyint(1)");

				b.Property<string>("CommitterEmail")
					.IsRequired()
					.HasMaxLength(10000)
					.HasColumnType("longtext");

				MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("CommitterEmail"), "utf8mb4");

				b.Property<string>("CommitterName")
					.IsRequired()
					.HasMaxLength(10000)
					.HasColumnType("longtext");

				MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("CommitterName"), "utf8mb4");

				b.Property<bool?>("CreateGitHubDeployments")
					.IsRequired()
					.HasColumnType("tinyint(1)");

				b.Property<long>("InstanceId")
					.HasColumnType("bigint");

				b.Property<bool?>("PostTestMergeComment")
					.IsRequired()
					.HasColumnType("tinyint(1)");

				b.Property<bool?>("PushTestMergeCommits")
					.IsRequired()
					.HasColumnType("tinyint(1)");

				b.Property<bool?>("ShowTestMergeCommitters")
					.IsRequired()
					.HasColumnType("tinyint(1)");

				b.Property<bool?>("UpdateSubmodules")
					.IsRequired()
					.HasColumnType("tinyint(1)");

				b.HasKey("Id");

				b.HasIndex("InstanceId")
					.IsUnique();

				b.ToTable("RepositorySettings");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.RevInfoTestMerge", b =>
			{
				b.Property<long>("Id")
					.ValueGeneratedOnAdd()
					.HasColumnType("bigint");

				b.Property<long>("RevisionInformationId")
					.HasColumnType("bigint");

				b.Property<long>("TestMergeId")
					.HasColumnType("bigint");

				b.HasKey("Id");

				b.HasIndex("RevisionInformationId");

				b.HasIndex("TestMergeId");

				b.ToTable("RevInfoTestMerges");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.RevisionInformation", b =>
			{
				b.Property<long>("Id")
					.ValueGeneratedOnAdd()
					.HasColumnType("bigint");

				b.Property<string>("CommitSha")
					.IsRequired()
					.HasMaxLength(40)
					.HasColumnType("varchar(40)");

				MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("CommitSha"), "utf8mb4");

				b.Property<long>("InstanceId")
					.HasColumnType("bigint");

				b.Property<string>("OriginCommitSha")
					.IsRequired()
					.HasMaxLength(40)
					.HasColumnType("varchar(40)");

				MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("OriginCommitSha"), "utf8mb4");

				b.Property<DateTimeOffset>("Timestamp")
					.HasColumnType("datetime(6)");

				b.HasKey("Id");

				b.HasIndex("InstanceId", "CommitSha")
					.IsUnique();

				b.ToTable("RevisionInformations");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.TestMerge", b =>
			{
				b.Property<long>("Id")
					.ValueGeneratedOnAdd()
					.HasColumnType("bigint");

				b.Property<string>("Author")
					.IsRequired()
					.HasColumnType("longtext");

				MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Author"), "utf8mb4");

				b.Property<string>("BodyAtMerge")
					.IsRequired()
					.HasColumnType("longtext");

				MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("BodyAtMerge"), "utf8mb4");

				b.Property<string>("Comment")
					.HasMaxLength(10000)
					.HasColumnType("longtext");

				MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Comment"), "utf8mb4");

				b.Property<DateTimeOffset>("MergedAt")
					.HasColumnType("datetime(6)");

				b.Property<long>("MergedById")
					.HasColumnType("bigint");

				b.Property<int>("Number")
					.HasColumnType("int");

				b.Property<long?>("PrimaryRevisionInformationId")
					.IsRequired()
					.HasColumnType("bigint");

				b.Property<string>("TargetCommitSha")
					.IsRequired()
					.HasMaxLength(40)
					.HasColumnType("varchar(40)");

				MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("TargetCommitSha"), "utf8mb4");

				b.Property<string>("TitleAtMerge")
					.IsRequired()
					.HasColumnType("longtext");

				MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("TitleAtMerge"), "utf8mb4");

				b.Property<string>("Url")
					.IsRequired()
					.HasColumnType("longtext");

				MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Url"), "utf8mb4");

				b.HasKey("Id");

				b.HasIndex("MergedById");

				b.HasIndex("PrimaryRevisionInformationId")
					.IsUnique();

				b.ToTable("TestMerges");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.User", b =>
			{
				b.Property<long?>("Id")
					.ValueGeneratedOnAdd()
					.HasColumnType("bigint");

				b.Property<string>("CanonicalName")
					.IsRequired()
					.HasMaxLength(100)
					.HasColumnType("varchar(100)");

				MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("CanonicalName"), "utf8mb4");

				b.Property<DateTimeOffset?>("CreatedAt")
					.IsRequired()
					.HasColumnType("datetime(6)");

				b.Property<long?>("CreatedById")
					.HasColumnType("bigint");

				b.Property<bool?>("Enabled")
					.IsRequired()
					.HasColumnType("tinyint(1)");

				b.Property<long?>("GroupId")
					.HasColumnType("bigint");

				b.Property<DateTimeOffset?>("LastPasswordUpdate")
					.HasColumnType("datetime(6)");

				b.Property<string>("Name")
					.IsRequired()
					.HasMaxLength(100)
					.HasColumnType("varchar(100)");

				MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Name"), "utf8mb4");

				b.Property<string>("PasswordHash")
					.HasColumnType("longtext");

				MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("PasswordHash"), "utf8mb4");

				b.Property<string>("SystemIdentifier")
					.HasMaxLength(100)
					.HasColumnType("varchar(100)");

				MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("SystemIdentifier"), "utf8mb4");

				b.HasKey("Id");

				b.HasIndex("CanonicalName")
					.IsUnique();

				b.HasIndex("CreatedById");

				b.HasIndex("GroupId");

				b.HasIndex("SystemIdentifier")
					.IsUnique();

				b.ToTable("Users");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.UserGroup", b =>
			{
				b.Property<long?>("Id")
					.ValueGeneratedOnAdd()
					.HasColumnType("bigint");

				b.Property<string>("Name")
					.IsRequired()
					.HasMaxLength(100)
					.HasColumnType("varchar(100)");

				MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Name"), "utf8mb4");

				b.HasKey("Id");

				b.HasIndex("Name")
					.IsUnique();

				b.ToTable("Groups");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.ChatBot", b =>
			{
				b.HasOne("Tgstation.Server.Host.Models.Instance", "Instance")
					.WithMany("ChatSettings")
					.HasForeignKey("InstanceId")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();

				b.Navigation("Instance");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.ChatChannel", b =>
			{
				b.HasOne("Tgstation.Server.Host.Models.ChatBot", "ChatSettings")
					.WithMany("Channels")
					.HasForeignKey("ChatSettingsId")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();

				b.Navigation("ChatSettings");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.CompileJob", b =>
			{
				b.HasOne("Tgstation.Server.Host.Models.Job", "Job")
					.WithOne()
					.HasForeignKey("Tgstation.Server.Host.Models.CompileJob", "JobId")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();

				b.HasOne("Tgstation.Server.Host.Models.RevisionInformation", "RevisionInformation")
					.WithMany("CompileJobs")
					.HasForeignKey("RevisionInformationId")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();

				b.Navigation("Job");

				b.Navigation("RevisionInformation");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.DreamDaemonSettings", b =>
			{
				b.HasOne("Tgstation.Server.Host.Models.Instance", "Instance")
					.WithOne("DreamDaemonSettings")
					.HasForeignKey("Tgstation.Server.Host.Models.DreamDaemonSettings", "InstanceId")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();

				b.Navigation("Instance");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.DreamMakerSettings", b =>
			{
				b.HasOne("Tgstation.Server.Host.Models.Instance", "Instance")
					.WithOne("DreamMakerSettings")
					.HasForeignKey("Tgstation.Server.Host.Models.DreamMakerSettings", "InstanceId")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();

				b.Navigation("Instance");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.InstancePermissionSet", b =>
			{
				b.HasOne("Tgstation.Server.Host.Models.Instance", "Instance")
					.WithMany("InstancePermissionSets")
					.HasForeignKey("InstanceId")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();

				b.HasOne("Tgstation.Server.Host.Models.PermissionSet", "PermissionSet")
					.WithMany("InstancePermissionSets")
					.HasForeignKey("PermissionSetId")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();

				b.Navigation("Instance");

				b.Navigation("PermissionSet");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.Job", b =>
			{
				b.HasOne("Tgstation.Server.Host.Models.User", "CancelledBy")
					.WithMany()
					.HasForeignKey("CancelledById");

				b.HasOne("Tgstation.Server.Host.Models.Instance", "Instance")
					.WithMany("Jobs")
					.HasForeignKey("InstanceId")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();

				b.HasOne("Tgstation.Server.Host.Models.User", "StartedBy")
					.WithMany()
					.HasForeignKey("StartedById")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();

				b.Navigation("CancelledBy");

				b.Navigation("Instance");

				b.Navigation("StartedBy");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.OAuthConnection", b =>
			{
				b.HasOne("Tgstation.Server.Host.Models.User", "User")
					.WithMany("OAuthConnections")
					.HasForeignKey("UserId")
					.OnDelete(DeleteBehavior.Cascade);

				b.Navigation("User");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.PermissionSet", b =>
			{
				b.HasOne("Tgstation.Server.Host.Models.UserGroup", "Group")
					.WithOne("PermissionSet")
					.HasForeignKey("Tgstation.Server.Host.Models.PermissionSet", "GroupId")
					.OnDelete(DeleteBehavior.Cascade);

				b.HasOne("Tgstation.Server.Host.Models.User", "User")
					.WithOne("PermissionSet")
					.HasForeignKey("Tgstation.Server.Host.Models.PermissionSet", "UserId")
					.OnDelete(DeleteBehavior.Cascade);

				b.Navigation("Group");

				b.Navigation("User");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.ReattachInformation", b =>
			{
				b.HasOne("Tgstation.Server.Host.Models.CompileJob", "CompileJob")
					.WithMany()
					.HasForeignKey("CompileJobId")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();

				b.HasOne("Tgstation.Server.Host.Models.CompileJob", "InitialCompileJob")
					.WithMany()
					.HasForeignKey("InitialCompileJobId");

				b.Navigation("CompileJob");

				b.Navigation("InitialCompileJob");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.RepositorySettings", b =>
			{
				b.HasOne("Tgstation.Server.Host.Models.Instance", "Instance")
					.WithOne("RepositorySettings")
					.HasForeignKey("Tgstation.Server.Host.Models.RepositorySettings", "InstanceId")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();

				b.Navigation("Instance");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.RevInfoTestMerge", b =>
			{
				b.HasOne("Tgstation.Server.Host.Models.RevisionInformation", "RevisionInformation")
					.WithMany("ActiveTestMerges")
					.HasForeignKey("RevisionInformationId")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();

				b.HasOne("Tgstation.Server.Host.Models.TestMerge", "TestMerge")
					.WithMany("RevisonInformations")
					.HasForeignKey("TestMergeId")
					.OnDelete(DeleteBehavior.ClientNoAction)
					.IsRequired();

				b.Navigation("RevisionInformation");

				b.Navigation("TestMerge");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.RevisionInformation", b =>
			{
				b.HasOne("Tgstation.Server.Host.Models.Instance", "Instance")
					.WithMany("RevisionInformations")
					.HasForeignKey("InstanceId")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();

				b.Navigation("Instance");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.TestMerge", b =>
			{
				b.HasOne("Tgstation.Server.Host.Models.User", "MergedBy")
					.WithMany("TestMerges")
					.HasForeignKey("MergedById")
					.OnDelete(DeleteBehavior.Restrict)
					.IsRequired();

				b.HasOne("Tgstation.Server.Host.Models.RevisionInformation", "PrimaryRevisionInformation")
					.WithOne("PrimaryTestMerge")
					.HasForeignKey("Tgstation.Server.Host.Models.TestMerge", "PrimaryRevisionInformationId")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();

				b.Navigation("MergedBy");

				b.Navigation("PrimaryRevisionInformation");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.User", b =>
			{
				b.HasOne("Tgstation.Server.Host.Models.User", "CreatedBy")
					.WithMany("CreatedUsers")
					.HasForeignKey("CreatedById");

				b.HasOne("Tgstation.Server.Host.Models.UserGroup", "Group")
					.WithMany("Users")
					.HasForeignKey("GroupId");

				b.Navigation("CreatedBy");

				b.Navigation("Group");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.ChatBot", b =>
			{
				b.Navigation("Channels");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.Instance", b =>
			{
				b.Navigation("ChatSettings");

				b.Navigation("DreamDaemonSettings");

				b.Navigation("DreamMakerSettings");

				b.Navigation("InstancePermissionSets");

				b.Navigation("Jobs");

				b.Navigation("RepositorySettings");

				b.Navigation("RevisionInformations");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.PermissionSet", b =>
			{
				b.Navigation("InstancePermissionSets");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.RevisionInformation", b =>
			{
				b.Navigation("ActiveTestMerges");

				b.Navigation("CompileJobs");

				b.Navigation("PrimaryTestMerge");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.TestMerge", b =>
			{
				b.Navigation("RevisonInformations");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.User", b =>
			{
				b.Navigation("CreatedUsers");

				b.Navigation("OAuthConnections");

				b.Navigation("PermissionSet");

				b.Navigation("TestMerges");
			});

			modelBuilder.Entity("Tgstation.Server.Host.Models.UserGroup", b =>
			{
				b.Navigation("PermissionSet")
					.IsRequired();

				b.Navigation("Users");
			});
#pragma warning restore 612, 618
		}
	}
}
