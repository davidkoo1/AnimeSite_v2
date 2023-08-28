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
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824224412_Init')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824224412_Init')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [ProfileImage] nvarchar(max) NULL,
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
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824224412_Init')
BEGIN
    CREATE TABLE [Editors] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NULL,
        [Image] nvarchar(max) NULL,
        CONSTRAINT [PK_Editors] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824224412_Init')
BEGIN
    CREATE TABLE [Genres] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Genres] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824224412_Init')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824224412_Init')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824224412_Init')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824224412_Init')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824224412_Init')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824224412_Init')
BEGIN
    CREATE TABLE [Animes] (
        [EditorId] int NULL,
        [AnimeName] nvarchar(450) NOT NULL,
        [Description] nvarchar(max) NULL,
        [TitleImage] nvarchar(max) NOT NULL,
        [Trailer] nvarchar(max) NULL,
        CONSTRAINT [PK_Animes] PRIMARY KEY ([AnimeName]),
        CONSTRAINT [FK_Animes_Editors_EditorId] FOREIGN KEY ([EditorId]) REFERENCES [Editors] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824224412_Init')
BEGIN
    CREATE TABLE [AnimeGenres] (
        [AnimeName] nvarchar(450) NOT NULL,
        [GenreId] int NOT NULL,
        CONSTRAINT [PK_AnimeGenres] PRIMARY KEY ([AnimeName], [GenreId]),
        CONSTRAINT [FK_AnimeGenres_Animes_AnimeName] FOREIGN KEY ([AnimeName]) REFERENCES [Animes] ([AnimeName]) ON DELETE CASCADE,
        CONSTRAINT [FK_AnimeGenres_Genres_GenreId] FOREIGN KEY ([GenreId]) REFERENCES [Genres] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824224412_Init')
BEGIN
    CREATE TABLE [FavouriteAnime] (
        [AnimeName] nvarchar(450) NOT NULL,
        [AppUserId] nvarchar(450) NOT NULL,
        [dateTime] datetime2 NULL,
        CONSTRAINT [PK_FavouriteAnime] PRIMARY KEY ([AnimeName], [AppUserId]),
        CONSTRAINT [FK_FavouriteAnime_Animes_AnimeName] FOREIGN KEY ([AnimeName]) REFERENCES [Animes] ([AnimeName]) ON DELETE CASCADE,
        CONSTRAINT [FK_FavouriteAnime_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824224412_Init')
BEGIN
    CREATE TABLE [Seasons] (
        [AnimeName] nvarchar(450) NOT NULL,
        [SeasonNumber] int NOT NULL,
        [SeasonTitle] nvarchar(max) NOT NULL,
        [SeasonImage] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Seasons] PRIMARY KEY ([AnimeName], [SeasonNumber]),
        CONSTRAINT [FK_Seasons_Animes_AnimeName] FOREIGN KEY ([AnimeName]) REFERENCES [Animes] ([AnimeName]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824224412_Init')
BEGIN
    CREATE TABLE [Episodes] (
        [AnimeName] nvarchar(450) NOT NULL,
        [SeasonNumber] int NOT NULL,
        [EpisodeNumber] int NOT NULL,
        [EpisodeSrc] nvarchar(max) NOT NULL,
        [ReleaseEpisode] datetime2 NOT NULL,
        CONSTRAINT [PK_Episodes] PRIMARY KEY ([AnimeName], [SeasonNumber], [EpisodeNumber]),
        CONSTRAINT [FK_Episodes_Seasons_AnimeName_SeasonNumber] FOREIGN KEY ([AnimeName], [SeasonNumber]) REFERENCES [Seasons] ([AnimeName], [SeasonNumber]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824224412_Init')
BEGIN
    CREATE TABLE [Ratings] (
        [AnimeName] nvarchar(450) NOT NULL,
        [SeasonNumber] int NOT NULL,
        [AppUserId] nvarchar(450) NOT NULL,
        [Mark] int NOT NULL,
        CONSTRAINT [PK_Ratings] PRIMARY KEY ([AnimeName], [SeasonNumber], [AppUserId]),
        CONSTRAINT [FK_Ratings_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Ratings_Seasons_AnimeName_SeasonNumber] FOREIGN KEY ([AnimeName], [SeasonNumber]) REFERENCES [Seasons] ([AnimeName], [SeasonNumber]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824224412_Init')
BEGIN
    CREATE TABLE [Comments] (
        [CommentId] uniqueidentifier NOT NULL,
        [AnimeName] nvarchar(450) NOT NULL,
        [SeasonNumber] int NOT NULL,
        [EpisodeNumber] int NOT NULL,
        [AppUserId] nvarchar(450) NULL,
        [Message] nvarchar(max) NOT NULL,
        [Date] datetime2 NULL,
        CONSTRAINT [PK_Comments] PRIMARY KEY ([CommentId]),
        CONSTRAINT [FK_Comments_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]),
        CONSTRAINT [FK_Comments_Episodes_AnimeName_SeasonNumber_EpisodeNumber] FOREIGN KEY ([AnimeName], [SeasonNumber], [EpisodeNumber]) REFERENCES [Episodes] ([AnimeName], [SeasonNumber], [EpisodeNumber]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824224412_Init')
BEGIN
    CREATE INDEX [IX_AnimeGenres_GenreId] ON [AnimeGenres] ([GenreId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824224412_Init')
BEGIN
    CREATE INDEX [IX_Animes_EditorId] ON [Animes] ([EditorId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824224412_Init')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824224412_Init')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824224412_Init')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824224412_Init')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824224412_Init')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824224412_Init')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824224412_Init')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824224412_Init')
BEGIN
    CREATE INDEX [IX_Comments_AnimeName_SeasonNumber_EpisodeNumber] ON [Comments] ([AnimeName], [SeasonNumber], [EpisodeNumber]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824224412_Init')
BEGIN
    CREATE INDEX [IX_Comments_AppUserId] ON [Comments] ([AppUserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824224412_Init')
BEGIN
    CREATE INDEX [IX_FavouriteAnime_AppUserId] ON [FavouriteAnime] ([AppUserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824224412_Init')
BEGIN
    CREATE INDEX [IX_Ratings_AppUserId] ON [Ratings] ([AppUserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230824224412_Init')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230824224412_Init', N'7.0.9');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230825145238_ServerDB')
BEGIN
    ALTER TABLE [Animes] DROP CONSTRAINT [FK_Animes_Editors_EditorId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230825145238_ServerDB')
BEGIN
    DROP INDEX [IX_Animes_EditorId] ON [Animes];
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Animes]') AND [c].[name] = N'EditorId');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Animes] DROP CONSTRAINT [' + @var0 + '];');
    EXEC(N'UPDATE [Animes] SET [EditorId] = 0 WHERE [EditorId] IS NULL');
    ALTER TABLE [Animes] ALTER COLUMN [EditorId] int NOT NULL;
    ALTER TABLE [Animes] ADD DEFAULT 0 FOR [EditorId];
    CREATE INDEX [IX_Animes_EditorId] ON [Animes] ([EditorId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230825145238_ServerDB')
BEGIN
    ALTER TABLE [Animes] ADD CONSTRAINT [FK_Animes_Editors_EditorId] FOREIGN KEY ([EditorId]) REFERENCES [Editors] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230825145238_ServerDB')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230825145238_ServerDB', N'7.0.9');
END;
GO

COMMIT;
GO

