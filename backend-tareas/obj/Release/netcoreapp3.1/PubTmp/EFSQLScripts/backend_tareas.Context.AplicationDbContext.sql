IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210813143751_v1.0.1')
BEGIN
    CREATE TABLE [Notacs] (
        [Id] int NOT NULL IDENTITY,
        [Descript] nvarchar(max) NOT NULL,
        [CreationDate] datetime2 NULL,
        [ExpirationDate] datetime2 NULL,
        [Title] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Notacs] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210813143751_v1.0.1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210813143751_v1.0.1', N'3.1.9');
END;

GO

