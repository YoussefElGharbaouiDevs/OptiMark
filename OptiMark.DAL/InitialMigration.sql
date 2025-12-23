IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [Channels] (
    [ChannelId] int NOT NULL IDENTITY,
    [ChannelName] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Channels] PRIMARY KEY ([ChannelId])
);

CREATE TABLE [Companies] (
    [CompanyId] int NOT NULL IDENTITY,
    [CompanyName] nvarchar(200) NOT NULL,
    [ProfileDetails] nvarchar(max) NULL,
    CONSTRAINT [PK_Companies] PRIMARY KEY ([CompanyId])
);

CREATE TABLE [Roles] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
);

CREATE TABLE [Campaigns] (
    [CampaignId] int NOT NULL IDENTITY,
    [CompanyId] int NOT NULL,
    [CampaignName] nvarchar(200) NOT NULL,
    [StartDate] date NOT NULL,
    [EndDate] date NOT NULL,
    [Budget] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Campaigns] PRIMARY KEY ([CampaignId]),
    CONSTRAINT [FK_Campaigns_Companies_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Companies] ([CompanyId]) ON DELETE CASCADE
);

CREATE TABLE [Users] (
    [Id] nvarchar(450) NOT NULL,
    [FullName] nvarchar(max) NOT NULL,
    [CompanyId] int NULL,
    [UserName] nvarchar(256) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [Email] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Users_Companies_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Companies] ([CompanyId])
);

CREATE TABLE [RoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_RoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_RoleClaims_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [KPIs] (
    [KPIId] int NOT NULL IDENTITY,
    [CampaignId] int NOT NULL,
    [ChannelId] int NOT NULL,
    [Date] date NOT NULL,
    [ROI] decimal(10,4) NOT NULL,
    [CPA] decimal(10,4) NOT NULL,
    [CTR] decimal(10,4) NOT NULL,
    [CPC] decimal(10,4) NOT NULL,
    CONSTRAINT [PK_KPIs] PRIMARY KEY ([KPIId]),
    CONSTRAINT [FK_KPIs_Campaigns_CampaignId] FOREIGN KEY ([CampaignId]) REFERENCES [Campaigns] ([CampaignId]) ON DELETE CASCADE,
    CONSTRAINT [FK_KPIs_Channels_ChannelId] FOREIGN KEY ([ChannelId]) REFERENCES [Channels] ([ChannelId]) ON DELETE CASCADE
);

CREATE TABLE [PerformanceData] (
    [PerformanceDataId] int NOT NULL IDENTITY,
    [CampaignId] int NOT NULL,
    [ChannelId] int NOT NULL,
    [Date] date NOT NULL,
    [Impressions] int NOT NULL,
    [Clicks] int NOT NULL,
    [BudgetSpent] decimal(18,2) NOT NULL,
    [Conversions] int NOT NULL,
    [Revenue] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_PerformanceData] PRIMARY KEY ([PerformanceDataId]),
    CONSTRAINT [FK_PerformanceData_Campaigns_CampaignId] FOREIGN KEY ([CampaignId]) REFERENCES [Campaigns] ([CampaignId]) ON DELETE CASCADE,
    CONSTRAINT [FK_PerformanceData_Channels_ChannelId] FOREIGN KEY ([ChannelId]) REFERENCES [Channels] ([ChannelId]) ON DELETE CASCADE
);

CREATE TABLE [Reports] (
    [ReportId] int NOT NULL IDENTITY,
    [CampaignId] int NOT NULL,
    [CompanyId] int NOT NULL,
    [ReportType] int NOT NULL,
    [GeneratedDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Reports] PRIMARY KEY ([ReportId]),
    CONSTRAINT [FK_Reports_Campaigns_CampaignId] FOREIGN KEY ([CampaignId]) REFERENCES [Campaigns] ([CampaignId]),
    CONSTRAINT [FK_Reports_Companies_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Companies] ([CompanyId])
);

CREATE TABLE [UserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_UserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UserClaims_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [UserLogins] (
    [LoginProvider] nvarchar(450) NOT NULL,
    [ProviderKey] nvarchar(450) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_UserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_UserLogins_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [UserRoles] (
    [UserId] nvarchar(450) NOT NULL,
    [RoleId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_UserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [UserTokens] (
    [UserId] nvarchar(450) NOT NULL,
    [LoginProvider] nvarchar(450) NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_UserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_UserTokens_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_Campaigns_CompanyId] ON [Campaigns] ([CompanyId]);

CREATE INDEX [IX_KPIs_CampaignId] ON [KPIs] ([CampaignId]);

CREATE INDEX [IX_KPIs_ChannelId] ON [KPIs] ([ChannelId]);

CREATE INDEX [IX_PerformanceData_CampaignId] ON [PerformanceData] ([CampaignId]);

CREATE INDEX [IX_PerformanceData_ChannelId] ON [PerformanceData] ([ChannelId]);

CREATE INDEX [IX_Reports_CampaignId] ON [Reports] ([CampaignId]);

CREATE INDEX [IX_Reports_CompanyId] ON [Reports] ([CompanyId]);

CREATE INDEX [IX_RoleClaims_RoleId] ON [RoleClaims] ([RoleId]);

CREATE UNIQUE INDEX [RoleNameIndex] ON [Roles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;

CREATE INDEX [IX_UserClaims_UserId] ON [UserClaims] ([UserId]);

CREATE INDEX [IX_UserLogins_UserId] ON [UserLogins] ([UserId]);

CREATE INDEX [IX_UserRoles_RoleId] ON [UserRoles] ([RoleId]);

CREATE INDEX [EmailIndex] ON [Users] ([NormalizedEmail]);

CREATE INDEX [IX_Users_CompanyId] ON [Users] ([CompanyId]);

CREATE UNIQUE INDEX [UserNameIndex] ON [Users] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251105162709_Initial', N'9.0.10');

COMMIT;
GO

