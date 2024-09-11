﻿// <auto-generated />
using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Tgstation.Server.Host.Database.Migrations
{
	[DbContext(typeof(PostgresSqlDatabaseContext))]
	partial class PostgresSqlDatabaseContextModelSnapshot : ModelSnapshot
	{
		protected override void BuildModel(ModelBuilder modelBuilder)
		{
#pragma warning disable 612, 618
			modelBuilder
				.HasAnnotation("ProductVersion", "8.0.8")
				.HasAnnotation("Relational:MaxIdentifierLength", 63);

			NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

			modelBuilder.Entity("Tgstation.Server.Host.Models.ChatBot", b =>
			{
				b.Property<long?>("Id")
					.ValueGeneratedOnAdd()
					.HasColumnType("bigint");

				NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long?>("Id"));

				b.Property<int>("ChannelLimit")
					.HasColumnType("integer");

				b.Property<string>("ConnectionString")
					.IsRequired()
					.HasMaxLength(10000)
					.HasColumnType("character varying(10000)");

				b.Property<bool?>("Enabled")
					.HasColumnType("boolean");

				b.Property<long>("InstanceId")
					.HasColumnType("bigint");

				b.Property<string>("Name")
					.IsRequired()
					.HasMaxLength(100)
					.HasColumnType("character varying(100)");

				b.Property<int>("Provider")
					.HasColumnType("integer");

				b.Property<long>("ReconnectionInterval")
					.HasColumnType("bigint");

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

				NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

				b.Property<long>("ChatSettingsId")
					.HasColumnType("bigint");

				b.Property<decimal?>("DiscordChannelId")
					.HasColumnType("numeric(20,0)");

				b.Property<string>("IrcChannel")
					.HasMaxLength(100)
					.HasColumnType("character varying(100)");

				b.Property<bool?>("IsAdminChannel")
					.IsRequired()
					.HasColumnType("boolean");

				b.Property<bool?>("IsSystemChannel")
					.IsRequired()
					.HasColumnType("boolean");

				b.Property<bool?>("IsUpdatesChannel")
					.IsRequired()
					.HasColumnType("boolean");

				b.Property<bool?>("IsWatchdogChannel")
					.IsRequired()
					.HasColumnType("boolean");

				b.Property<string>("Tag")
					.HasMaxLength(10000)
					.HasColumnType("character varying(10000)");

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

				NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long?>("Id"));

				b.Property<int?>("DMApiMajorVersion")
					.HasColumnType("integer");

				b.Property<int?>("DMApiMinorVersion")
					.HasColumnType("integer");

				b.Property<int?>("DMApiPatchVersion")
					.HasColumnType("integer");

				b.Property<Guid?>("DirectoryName")
					.IsRequired()
					.HasColumnType("uuid");

				b.Property<string>("DmeName")
					.IsRequired()
					.HasColumnType("text");

				b.Property<string>("EngineVersion")
					.IsRequired()
					.HasColumnType("text");

				b.Property<long?>("GitHubDeploymentId")
					.HasColumnType("bigint");

				b.Property<long?>("GitHubRepoId")
					.HasColumnType("bigint");

				b.Property<long>("JobId")
					.HasColumnType("bigint");

				b.Property<int?>("MinimumSecurityLevel")
					.HasColumnType("integer");

				b.Property<string>("Output")
					.IsRequired()
					.HasColumnType("text");

				b.Property<string>("RepositoryOrigin")
					.HasColumnType("text");

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

				NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

				b.Property<string>("AdditionalParameters")
					.IsRequired()
					.HasMaxLength(10000)
					.HasColumnType("character varying(10000)");

				b.Property<bool?>("AllowWebClient")
					.IsRequired()
					.HasColumnType("boolean");

				b.Property<bool?>("AutoStart")
					.IsRequired()
					.HasColumnType("boolean");

				b.Property<bool?>("DumpOnHealthCheckRestart")
					.IsRequired()
					.HasColumnType("boolean");

				b.Property<long>("HealthCheckSeconds")
					.HasColumnType("bigint");

				b.Property<long>("InstanceId")
					.HasColumnType("bigint");

				b.Property<bool?>("LogOutput")
					.IsRequired()
					.HasColumnType("boolean");

				b.Property<long>("MapThreads")
					.HasColumnType("bigint");

				b.Property<bool?>("Minidumps")
					.IsRequired()
					.HasColumnType("boolean");

				b.Property<int>("OpenDreamTopicPort")
					.HasColumnType("integer");

				b.Property<int>("Port")
					.HasColumnType("integer");

				b.Property<int>("SecurityLevel")
					.HasColumnType("integer");

				b.Property<bool?>("StartProfiler")
					.IsRequired()
					.HasColumnType("boolean");

				b.Property<long>("StartupTimeout")
					.HasColumnType("bigint");

				b.Property<long>("TopicRequestTimeout")
					.HasColumnType("bigint");

				b.Property<int>("Visibility")
					.HasColumnType("integer");

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

				NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

				b.Property<int>("ApiValidationPort")
					.HasColumnType("integer");

				b.Property<int>("ApiValidationSecurityLevel")
					.HasColumnType("integer");

				b.Property<string>("CompilerAdditionalArguments")
					.HasMaxLength(10000)
					.HasColumnType("character varying(10000)");

				b.Property<int>("DMApiValidationMode")
					.HasColumnType("integer");

				b.Property<long>("InstanceId")
					.HasColumnType("bigint");

				b.Property<string>("ProjectName")
					.HasMaxLength(10000)
					.HasColumnType("character varying(10000)");

				b.Property<TimeSpan?>("Timeout")
					.IsRequired()
					.HasColumnType("interval");

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

				NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long?>("Id"));

				b.Property<string>("AutoUpdateCron")
					.IsRequired()
					.HasMaxLength(10000)
					.HasColumnType("character varying(10000)");

				b.Property<long>("AutoUpdateInterval")
					.HasColumnType("bigint");

				b.Property<int>("ChatBotLimit")
					.HasColumnType("integer");

				b.Property<int>("ConfigurationType")
					.HasColumnType("integer");

				b.Property<string>("Name")
					.IsRequired()
					.HasMaxLength(100)
					.HasColumnType("character varying(100)");

				b.Property<bool?>("Online")
					.IsRequired()
					.HasColumnType("boolean");

				b.Property<string>("Path")
					.IsRequired()
					.HasColumnType("text");

				b.Property<string>("SwarmIdentifer")
					.HasColumnType("text");

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

				NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

				b.Property<decimal>("ChatBotRights")
					.HasColumnType("numeric(20,0)");

				b.Property<decimal>("ConfigurationRights")
					.HasColumnType("numeric(20,0)");

				b.Property<decimal>("DreamDaemonRights")
					.HasColumnType("numeric(20,0)");

				b.Property<decimal>("DreamMakerRights")
					.HasColumnType("numeric(20,0)");

				b.Property<decimal>("EngineRights")
					.HasColumnType("numeric(20,0)");

				b.Property<long>("InstanceId")
					.HasColumnType("bigint");

				b.Property<decimal>("InstancePermissionSetRights")
					.HasColumnType("numeric(20,0)");

				b.Property<long>("PermissionSetId")
					.HasColumnType("bigint");

				b.Property<decimal>("RepositoryRights")
					.HasColumnType("numeric(20,0)");

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

				NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long?>("Id"));

				b.Property<decimal?>("CancelRight")
					.HasColumnType("numeric(20,0)");

				b.Property<decimal?>("CancelRightsType")
					.HasColumnType("numeric(20,0)");

				b.Property<bool?>("Cancelled")
					.IsRequired()
					.HasColumnType("boolean");

				b.Property<long?>("CancelledById")
					.HasColumnType("bigint");

				b.Property<string>("Description")
					.IsRequired()
					.HasColumnType("text");

				b.Property<long?>("ErrorCode")
					.HasColumnType("bigint");

				b.Property<string>("ExceptionDetails")
					.HasColumnType("text");

				b.Property<long>("InstanceId")
					.HasColumnType("bigint");

				b.Property<byte>("JobCode")
					.HasColumnType("smallint");

				b.Property<DateTimeOffset?>("StartedAt")
					.IsRequired()
					.HasColumnType("timestamp with time zone");

				b.Property<long>("StartedById")
					.HasColumnType("bigint");

				b.Property<DateTimeOffset?>("StoppedAt")
					.HasColumnType("timestamp with time zone");

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

				NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

				b.Property<string>("ExternalUserId")
					.IsRequired()
					.HasMaxLength(100)
					.HasColumnType("character varying(100)");

				b.Property<int>("Provider")
					.HasColumnType("integer");

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

				NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long?>("Id"));

				b.Property<decimal>("AdministrationRights")
					.HasColumnType("numeric(20,0)");

				b.Property<long?>("GroupId")
					.HasColumnType("bigint");

				b.Property<decimal>("InstanceManagerRights")
					.HasColumnType("numeric(20,0)");

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

				NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long?>("Id"));

				b.Property<string>("AccessIdentifier")
					.IsRequired()
					.HasColumnType("text");

				b.Property<long>("CompileJobId")
					.HasColumnType("bigint");

				b.Property<long?>("InitialCompileJobId")
					.HasColumnType("bigint");

				b.Property<int>("LaunchSecurityLevel")
					.HasColumnType("integer");

				b.Property<int>("LaunchVisibility")
					.HasColumnType("integer");

				b.Property<int>("Port")
					.HasColumnType("integer");

				b.Property<int>("ProcessId")
					.HasColumnType("integer");

				b.Property<int>("RebootState")
					.HasColumnType("integer");

				b.Property<int?>("TopicPort")
					.HasColumnType("integer");

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

				NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

				b.Property<string>("AccessToken")
					.HasMaxLength(10000)
					.HasColumnType("character varying(10000)");

				b.Property<string>("AccessUser")
					.HasMaxLength(10000)
					.HasColumnType("character varying(10000)");

				b.Property<bool?>("AutoUpdatesKeepTestMerges")
					.IsRequired()
					.HasColumnType("boolean");

				b.Property<bool?>("AutoUpdatesSynchronize")
					.IsRequired()
					.HasColumnType("boolean");

				b.Property<string>("CommitterEmail")
					.IsRequired()
					.HasMaxLength(10000)
					.HasColumnType("character varying(10000)");

				b.Property<string>("CommitterName")
					.IsRequired()
					.HasMaxLength(10000)
					.HasColumnType("character varying(10000)");

				b.Property<bool?>("CreateGitHubDeployments")
					.IsRequired()
					.HasColumnType("boolean");

				b.Property<long>("InstanceId")
					.HasColumnType("bigint");

				b.Property<bool?>("PostTestMergeComment")
					.IsRequired()
					.HasColumnType("boolean");

				b.Property<bool?>("PushTestMergeCommits")
					.IsRequired()
					.HasColumnType("boolean");

				b.Property<bool?>("ShowTestMergeCommitters")
					.IsRequired()
					.HasColumnType("boolean");

				b.Property<bool?>("UpdateSubmodules")
					.IsRequired()
					.HasColumnType("boolean");

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

				NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

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

				NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

				b.Property<string>("CommitSha")
					.IsRequired()
					.HasMaxLength(40)
					.HasColumnType("character varying(40)");

				b.Property<long>("InstanceId")
					.HasColumnType("bigint");

				b.Property<string>("OriginCommitSha")
					.IsRequired()
					.HasMaxLength(40)
					.HasColumnType("character varying(40)");

				b.Property<DateTimeOffset>("Timestamp")
					.HasColumnType("timestamp with time zone");

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

				NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

				b.Property<string>("Author")
					.IsRequired()
					.HasColumnType("text");

				b.Property<string>("BodyAtMerge")
					.IsRequired()
					.HasColumnType("text");

				b.Property<string>("Comment")
					.HasMaxLength(10000)
					.HasColumnType("character varying(10000)");

				b.Property<DateTimeOffset>("MergedAt")
					.HasColumnType("timestamp with time zone");

				b.Property<long>("MergedById")
					.HasColumnType("bigint");

				b.Property<int>("Number")
					.HasColumnType("integer");

				b.Property<long?>("PrimaryRevisionInformationId")
					.IsRequired()
					.HasColumnType("bigint");

				b.Property<string>("TargetCommitSha")
					.IsRequired()
					.HasMaxLength(40)
					.HasColumnType("character varying(40)");

				b.Property<string>("TitleAtMerge")
					.IsRequired()
					.HasColumnType("text");

				b.Property<string>("Url")
					.IsRequired()
					.HasColumnType("text");

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

				NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long?>("Id"));

				b.Property<string>("CanonicalName")
					.IsRequired()
					.HasMaxLength(100)
					.HasColumnType("character varying(100)");

				b.Property<DateTimeOffset?>("CreatedAt")
					.IsRequired()
					.HasColumnType("timestamp with time zone");

				b.Property<long?>("CreatedById")
					.HasColumnType("bigint");

				b.Property<bool?>("Enabled")
					.IsRequired()
					.HasColumnType("boolean");

				b.Property<long?>("GroupId")
					.HasColumnType("bigint");

				b.Property<DateTimeOffset?>("LastPasswordUpdate")
					.HasColumnType("timestamp with time zone");

				b.Property<string>("Name")
					.IsRequired()
					.HasMaxLength(100)
					.HasColumnType("character varying(100)");

				b.Property<string>("PasswordHash")
					.HasColumnType("text");

				b.Property<string>("SystemIdentifier")
					.HasMaxLength(100)
					.HasColumnType("character varying(100)");

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

				NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long?>("Id"));

				b.Property<string>("Name")
					.IsRequired()
					.HasMaxLength(100)
					.HasColumnType("character varying(100)");

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
