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

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240629233521_InitialCreate'
)
BEGIN
    CREATE TABLE [dbo].[Catalogue] (
        [CatalogueId] uniqueidentifier NOT NULL DEFAULT (NEWID()),
        [Name] varchar(30) NOT NULL,
        [Description] varchar(100) NULL,
        [Created] datetimeoffset NOT NULL DEFAULT (GETUTCDATE()),
        [Version] rowversion NOT NULL,
        CONSTRAINT [PK_Catalogue] PRIMARY KEY ([CatalogueId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240629233521_InitialCreate'
)
BEGIN
    CREATE TABLE [dbo].[Inventory] (
        [ProductId] uniqueidentifier NOT NULL,
        [Quantity] int NOT NULL,
        [Unit] decimal(9,2) NOT NULL,
        [UnitType] varchar(3) NOT NULL,
        [Price] decimal(10,2) NOT NULL,
        [Created] datetimeoffset NOT NULL DEFAULT (GETUTCDATE()),
        [Version] rowversion NOT NULL,
        CONSTRAINT [PK_Inventory] PRIMARY KEY ([ProductId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240629233521_InitialCreate'
)
BEGIN
    CREATE TABLE [dbo].[Permission] (
        [PermissionId] uniqueidentifier NOT NULL DEFAULT (NEWID()),
        [Order] int NOT NULL,
        [Name] varchar(50) NOT NULL,
        [DisplayName] varchar(50) NOT NULL,
        [Created] datetimeoffset NOT NULL DEFAULT (GETUTCDATE()),
        [Version] rowversion NOT NULL,
        CONSTRAINT [PK_Permission] PRIMARY KEY ([PermissionId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240629233521_InitialCreate'
)
BEGIN
    CREATE TABLE [dbo].[Role] (
        [RoleId] uniqueidentifier NOT NULL DEFAULT (NEWID()),
        [Name] varchar(30) NOT NULL,
        [DisplayName] varchar(50) NOT NULL,
        [Created] datetimeoffset NOT NULL DEFAULT (GETUTCDATE()),
        [Version] rowversion NOT NULL,
        CONSTRAINT [PK_Role] PRIMARY KEY ([RoleId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240629233521_InitialCreate'
)
BEGIN
    CREATE TABLE [dbo].[Product] (
        [ProductId] uniqueidentifier NOT NULL,
        [CatalogueId] uniqueidentifier NOT NULL,
        [Name] varchar(50) NOT NULL,
        [Description] varchar(100) NULL,
        [Created] datetimeoffset NOT NULL DEFAULT (GETUTCDATE()),
        [Version] rowversion NOT NULL,
        CONSTRAINT [PK_Product] PRIMARY KEY ([ProductId]),
        CONSTRAINT [FK_Product_Catalogue_CatalogueId] FOREIGN KEY ([CatalogueId]) REFERENCES [dbo].[Catalogue] ([CatalogueId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Product_Inventory_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Inventory] ([ProductId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240629233521_InitialCreate'
)
BEGIN
    CREATE TABLE [dbo].[RolePermission] (
        [RoleId] uniqueidentifier NOT NULL,
        [PermissionId] uniqueidentifier NOT NULL,
        [Created] datetimeoffset NOT NULL DEFAULT (GETUTCDATE()),
        [Version] rowversion NOT NULL,
        CONSTRAINT [PK_RolePermission] PRIMARY KEY ([RoleId], [PermissionId]),
        CONSTRAINT [FK_RolePermission_Permission_PermissionId] FOREIGN KEY ([PermissionId]) REFERENCES [dbo].[Permission] ([PermissionId]) ON DELETE CASCADE,
        CONSTRAINT [FK_RolePermission_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([RoleId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240629233521_InitialCreate'
)
BEGIN
    CREATE TABLE [dbo].[User] (
        [UserId] uniqueidentifier NOT NULL DEFAULT (NEWID()),
        [RoleId] uniqueidentifier NOT NULL,
        [DocumentNumber] varchar(20) NOT NULL,
        [Mobile] varchar(20) NOT NULL,
        [Username] varchar(100) NOT NULL,
        [Password] varchar(max) NOT NULL,
        [Email] varchar(100) NOT NULL,
        [Firstname] varchar(50) NOT NULL,
        [Lastname] varchar(50) NOT NULL,
        [IsActive] bit NOT NULL,
        [Salt] varbinary(max) NOT NULL,
        [Created] datetimeoffset NOT NULL DEFAULT (GETUTCDATE()),
        [Version] rowversion NOT NULL,
        CONSTRAINT [PK_User] PRIMARY KEY ([UserId]),
        CONSTRAINT [FK_User_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([RoleId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240629233521_InitialCreate'
)
BEGIN
    CREATE TABLE [dbo].[Order] (
        [OrderId] uniqueidentifier NOT NULL DEFAULT (NEWID()),
        [UserId] uniqueidentifier NOT NULL,
        [ProductId] uniqueidentifier NOT NULL,
        [Created] datetimeoffset NOT NULL DEFAULT (GETUTCDATE()),
        [Version] rowversion NOT NULL,
        CONSTRAINT [PK_Order] PRIMARY KEY ([OrderId]),
        CONSTRAINT [FK_Order_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([ProductId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Order_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240629233521_InitialCreate'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CatalogueId', N'Created', N'Description', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[Catalogue]'))
        SET IDENTITY_INSERT [dbo].[Catalogue] ON;
    EXEC(N'INSERT INTO [dbo].[Catalogue] ([CatalogueId], [Created], [Description], [Name])
    VALUES (''16d135b1-e117-47ad-a4ac-c15d40f133fd'', ''2024-02-14T10:11:00.0000000+03:00'', NULL, ''Frutas''),
    (''525d3a2b-3b4a-48e0-9e8e-8a5a844e4d0b'', ''2024-02-18T05:33:00.0000000+03:00'', ''Cereales sin grasa'', ''Cereales''),
    (''a35a2e5a-63a7-48a6-ab62-1ab5bf012c65'', ''2024-02-19T18:00:00.0000000+03:00'', NULL, ''Bebidas''),
    (''efddc257-66f9-4abc-815e-cd8bb4d39897'', ''2024-02-10T09:45:00.0000000+03:00'', NULL, ''Verduras'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CatalogueId', N'Created', N'Description', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[Catalogue]'))
        SET IDENTITY_INSERT [dbo].[Catalogue] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240629233521_InitialCreate'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProductId', N'Created', N'Price', N'Quantity', N'Unit', N'UnitType') AND [object_id] = OBJECT_ID(N'[dbo].[Inventory]'))
        SET IDENTITY_INSERT [dbo].[Inventory] ON;
    EXEC(N'INSERT INTO [dbo].[Inventory] ([ProductId], [Created], [Price], [Quantity], [Unit], [UnitType])
    VALUES (''0ab34369-9ea3-4153-97ae-099ebef7f746'', ''2024-02-10T09:11:00.0000000+03:00'', 4400.5, 24, 500.2, ''G''),
    (''3bfd012b-734b-424b-8c38-31f550037db6'', ''2024-02-15T20:11:00.0000000+03:00'', 2490.1, 310, 500.0, ''G''),
    (''3cbcffd4-60a8-4584-97a0-eacabf555ad8'', ''2024-02-18T23:17:00.0000000+03:00'', 17430.4, 45, 500.0, ''G''),
    (''67073233-c813-4646-ba42-06b7e7997fa9'', ''2024-02-21T02:00:00.0000000+03:00'', 48250.5, 19, 1.3, ''Lt''),
    (''7124211b-ff28-41b6-8404-d111c0a7ddb3'', ''2024-02-18T06:10:00.0000000+03:00'', 55500.0, 8, 720.2, ''G''),
    (''8b0ce0e2-2850-4673-bc32-8cfd0554409b'', ''2024-02-14T17:15:00.0000000+03:00'', 9120.5, 120, 1000.8, ''G''),
    (''9037cc53-fa37-4dd6-8833-40d583fd2371'', ''2024-02-18T21:12:00.0000000+03:00'', 15167.5, 13, 250.5, ''G''),
    (''920c202d-4ed1-453d-8769-557f4e5d0f90'', ''2024-02-19T03:00:00.0000000+03:00'', 5200.5, 80, 250.5, ''G''),
    (''96be3795-4827-4def-b766-6302e4ae3fef'', ''2024-02-19T10:05:00.0000000+03:00'', 7900.0, 33, 200.0, ''G''),
    (''9f15a35d-c294-471b-905f-e72d85538610'', ''2024-02-11T10:04:00.0000000+03:00'', 8990.5, 10, 220.0, ''G''),
    (''b1369640-650a-46f8-ad78-677690e222db'', ''2024-02-11T02:26:00.0000000+03:00'', 3250.44, 66, 340.5, ''G''),
    (''b323b549-dd2f-4fa5-aace-46239ed7f954'', ''2024-02-22T09:10:00.0000000+03:00'', 2720.8, 50, 400.0, ''Ml''),
    (''b3ce1679-ae8e-4f5b-9c22-0b672d7aab48'', ''2024-02-19T20:02:00.0000000+03:00'', 22000.0, 29, 7200.0, ''Ml'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProductId', N'Created', N'Price', N'Quantity', N'Unit', N'UnitType') AND [object_id] = OBJECT_ID(N'[dbo].[Inventory]'))
        SET IDENTITY_INSERT [dbo].[Inventory] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240629233521_InitialCreate'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PermissionId', N'Created', N'DisplayName', N'Name', N'Order') AND [object_id] = OBJECT_ID(N'[dbo].[Permission]'))
        SET IDENTITY_INSERT [dbo].[Permission] ON;
    EXEC(N'INSERT INTO [dbo].[Permission] ([PermissionId], [Created], [DisplayName], [Name], [Order])
    VALUES (''7cadecb0-c11f-4884-beaf-7b37090282a1'', ''2024-03-02T08:49:33.0000000+03:00'', ''List Order By User'', ''AllowListOrderByUser'', 3),
    (''a4f4aba0-8a5c-431d-82d5-de44bebd223e'', ''2024-03-01T14:05:00.0000000+03:00'', ''List Orders'', ''AllowListOrders'', 2),
    (''b4748720-c24d-44bb-9c76-cdddc3a0574d'', ''2024-02-24T10:10:00.0000000+03:00'', ''Manage Food'', ''AllowManageFood'', 1),
    (''e74c1d1b-c402-43d1-9492-0df9a67729c8'', ''2024-03-02T20:01:00.0000000+03:00'', ''Create Order'', ''AllowCreateOrder'', 4)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PermissionId', N'Created', N'DisplayName', N'Name', N'Order') AND [object_id] = OBJECT_ID(N'[dbo].[Permission]'))
        SET IDENTITY_INSERT [dbo].[Permission] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240629233521_InitialCreate'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'Created', N'DisplayName', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[Role]'))
        SET IDENTITY_INSERT [dbo].[Role] ON;
    EXEC(N'INSERT INTO [dbo].[Role] ([RoleId], [Created], [DisplayName], [Name])
    VALUES (''838c1363-9abd-4999-95e8-71382312ac74'', ''2024-02-05T16:23:11.0000000+03:00'', ''Common User'', ''CommonUser''),
    (''d146b771-7df4-411f-8ccb-490b2d65d22f'', ''2024-01-10T12:30:00.0000000+03:00'', ''Administrator'', ''AdminUser'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'Created', N'DisplayName', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[Role]'))
        SET IDENTITY_INSERT [dbo].[Role] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240629233521_InitialCreate'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProductId', N'CatalogueId', N'Created', N'Description', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[Product]'))
        SET IDENTITY_INSERT [dbo].[Product] ON;
    EXEC(N'INSERT INTO [dbo].[Product] ([ProductId], [CatalogueId], [Created], [Description], [Name])
    VALUES (''0ab34369-9ea3-4153-97ae-099ebef7f746'', ''efddc257-66f9-4abc-815e-cd8bb4d39897'', ''2024-02-10T09:11:00.0000000+03:00'', ''Apio crudo'', ''Apio''),
    (''3bfd012b-734b-424b-8c38-31f550037db6'', ''16d135b1-e117-47ad-a4ac-c15d40f133fd'', ''2024-02-15T20:11:00.0000000+03:00'', NULL, ''Guayaba rosa''),
    (''3cbcffd4-60a8-4584-97a0-eacabf555ad8'', ''525d3a2b-3b4a-48e0-9e8e-8a5a844e4d0b'', ''2024-02-18T23:17:00.0000000+03:00'', NULL, ''Galleta de animalitos''),
    (''67073233-c813-4646-ba42-06b7e7997fa9'', ''a35a2e5a-63a7-48a6-ab62-1ab5bf012c65'', ''2024-02-21T02:00:00.0000000+03:00'', ''Leche entera alqueria'', ''Leche entera''),
    (''7124211b-ff28-41b6-8404-d111c0a7ddb3'', ''525d3a2b-3b4a-48e0-9e8e-8a5a844e4d0b'', ''2024-02-18T06:10:00.0000000+03:00'', NULL, ''Galleta salmas''),
    (''8b0ce0e2-2850-4673-bc32-8cfd0554409b'', ''16d135b1-e117-47ad-a4ac-c15d40f133fd'', ''2024-02-14T17:15:00.0000000+03:00'', NULL, ''Fresa entera''),
    (''9037cc53-fa37-4dd6-8833-40d583fd2371'', ''525d3a2b-3b4a-48e0-9e8e-8a5a844e4d0b'', ''2024-02-18T21:12:00.0000000+03:00'', NULL, ''Maíz Tostado''),
    (''920c202d-4ed1-453d-8769-557f4e5d0f90'', ''525d3a2b-3b4a-48e0-9e8e-8a5a844e4d0b'', ''2024-02-19T03:00:00.0000000+03:00'', NULL, ''Pan de barra''),
    (''96be3795-4827-4def-b766-6302e4ae3fef'', ''525d3a2b-3b4a-48e0-9e8e-8a5a844e4d0b'', ''2024-02-19T10:05:00.0000000+03:00'', NULL, ''Galleta maría''),
    (''9f15a35d-c294-471b-905f-e72d85538610'', ''efddc257-66f9-4abc-815e-cd8bb4d39897'', ''2024-02-11T10:04:00.0000000+03:00'', NULL, ''Chile jalapeño''),
    (''b1369640-650a-46f8-ad78-677690e222db'', ''efddc257-66f9-4abc-815e-cd8bb4d39897'', ''2024-02-11T02:26:00.0000000+03:00'', NULL, ''Chayote cocido picado''),
    (''b323b549-dd2f-4fa5-aace-46239ed7f954'', ''a35a2e5a-63a7-48a6-ab62-1ab5bf012c65'', ''2024-02-22T09:10:00.0000000+03:00'', ''Té Verde FUZE Manzanilla'', ''Té Verde''),
    (''b3ce1679-ae8e-4f5b-9c22-0b672d7aab48'', ''a35a2e5a-63a7-48a6-ab62-1ab5bf012c65'', ''2024-02-19T20:02:00.0000000+03:00'', ''Agua natural Cristal'', ''Cristal'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProductId', N'CatalogueId', N'Created', N'Description', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[Product]'))
        SET IDENTITY_INSERT [dbo].[Product] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240629233521_InitialCreate'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PermissionId', N'RoleId', N'Created') AND [object_id] = OBJECT_ID(N'[dbo].[RolePermission]'))
        SET IDENTITY_INSERT [dbo].[RolePermission] ON;
    EXEC(N'INSERT INTO [dbo].[RolePermission] ([PermissionId], [RoleId], [Created])
    VALUES (''7cadecb0-c11f-4884-beaf-7b37090282a1'', ''838c1363-9abd-4999-95e8-71382312ac74'', ''2024-03-25T00:01:00.0000000+03:00''),
    (''e74c1d1b-c402-43d1-9492-0df9a67729c8'', ''838c1363-9abd-4999-95e8-71382312ac74'', ''2024-03-28T01:22:00.0000000+03:00''),
    (''7cadecb0-c11f-4884-beaf-7b37090282a1'', ''d146b771-7df4-411f-8ccb-490b2d65d22f'', ''2024-03-24T11:43:00.0000000+03:00''),
    (''a4f4aba0-8a5c-431d-82d5-de44bebd223e'', ''d146b771-7df4-411f-8ccb-490b2d65d22f'', ''2024-03-09T22:12:00.0000000+03:00''),
    (''b4748720-c24d-44bb-9c76-cdddc3a0574d'', ''d146b771-7df4-411f-8ccb-490b2d65d22f'', ''2024-03-01T17:33:00.0000000+03:00''),
    (''e74c1d1b-c402-43d1-9492-0df9a67729c8'', ''d146b771-7df4-411f-8ccb-490b2d65d22f'', ''2024-03-25T04:28:00.0000000+03:00'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PermissionId', N'RoleId', N'Created') AND [object_id] = OBJECT_ID(N'[dbo].[RolePermission]'))
        SET IDENTITY_INSERT [dbo].[RolePermission] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240629233521_InitialCreate'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'DocumentNumber', N'Email', N'Firstname', N'IsActive', N'Lastname', N'Mobile', N'Password', N'RoleId', N'Salt', N'Username') AND [object_id] = OBJECT_ID(N'[dbo].[User]'))
        SET IDENTITY_INSERT [dbo].[User] ON;
    EXEC(N'INSERT INTO [dbo].[User] ([UserId], [DocumentNumber], [Email], [Firstname], [IsActive], [Lastname], [Mobile], [Password], [RoleId], [Salt], [Username])
    VALUES (''c880a1fd-2c32-46cb-b744-a6fad6175a53'', ''1023944678'', ''cristian10camilo95@gmail.com'', ''Cristian Camilo'', CAST(1 AS bit), ''Bonilla'', ''+573163534451'', ''YFkPmMblk1zN27cI5lSDvIBiLrCXRBAI+MeF17esCFD+dOdffFtBocWmhEcFUIfsS0yMCjt4pgwKrZX0/ywq9Q=='', ''d146b771-7df4-411f-8ccb-490b2d65d22f'', 0x60590F98C6E5935CCDDBB708E65483BC80622EB097441008F8C785D7B7AC0850, ''chris__boni'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'DocumentNumber', N'Email', N'Firstname', N'IsActive', N'Lastname', N'Mobile', N'Password', N'RoleId', N'Salt', N'Username') AND [object_id] = OBJECT_ID(N'[dbo].[User]'))
        SET IDENTITY_INSERT [dbo].[User] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240629233521_InitialCreate'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'OrderId', N'Created', N'ProductId', N'UserId') AND [object_id] = OBJECT_ID(N'[dbo].[Order]'))
        SET IDENTITY_INSERT [dbo].[Order] ON;
    EXEC(N'INSERT INTO [dbo].[Order] ([OrderId], [Created], [ProductId], [UserId])
    VALUES (''4520742c-0ed4-4b5f-bb2b-887be306fb85'', ''2024-04-03T17:08:00.0000000+03:00'', ''9037cc53-fa37-4dd6-8833-40d583fd2371'', ''c880a1fd-2c32-46cb-b744-a6fad6175a53''),
    (''e384af28-6c38-4bf2-83cc-18ae3b58a23a'', ''2024-04-01T20:11:00.0000000+03:00'', ''8b0ce0e2-2850-4673-bc32-8cfd0554409b'', ''c880a1fd-2c32-46cb-b744-a6fad6175a53'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'OrderId', N'Created', N'ProductId', N'UserId') AND [object_id] = OBJECT_ID(N'[dbo].[Order]'))
        SET IDENTITY_INSERT [dbo].[Order] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240629233521_InitialCreate'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Catalogue_Name] ON [dbo].[Catalogue] ([Name]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240629233521_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Order_ProductId] ON [dbo].[Order] ([ProductId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240629233521_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Order_UserId] ON [dbo].[Order] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240629233521_InitialCreate'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Permission_Name_DisplayName] ON [dbo].[Permission] ([Name], [DisplayName]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240629233521_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Product_CatalogueId] ON [dbo].[Product] ([CatalogueId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240629233521_InitialCreate'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Product_Name] ON [dbo].[Product] ([Name]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240629233521_InitialCreate'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Role_Name_DisplayName] ON [dbo].[Role] ([Name], [DisplayName]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240629233521_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_RolePermission_PermissionId] ON [dbo].[RolePermission] ([PermissionId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240629233521_InitialCreate'
)
BEGIN
    CREATE UNIQUE INDEX [IX_User_DocumentNumber_Username_Email_Mobile] ON [dbo].[User] ([DocumentNumber], [Username], [Email], [Mobile]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240629233521_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_User_RoleId] ON [dbo].[User] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240629233521_InitialCreate'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240629233521_InitialCreate', N'8.0.4');
END;
GO

COMMIT;
GO

