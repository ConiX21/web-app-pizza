
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/23/2018 15:54:39
-- Generated from EDMX file: C:\Users\dmr\documents\visual studio 2017\Projects\web-app-pizza\web-app-pizza\Models\ModelPizza.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [pizzaDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ClientClients_Roles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Clients_Roles] DROP CONSTRAINT [FK_ClientClients_Roles];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Client]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Client];
GO
IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO
IF OBJECT_ID(N'[dbo].[Clients_Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clients_Roles];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Client'
CREATE TABLE [dbo].[Client] (
    [IDClient] uniqueidentifier  NOT NULL,
    [UserName] varchar(35)  NULL,
    [Email] varchar(100)  NULL,
    [Password] varchar(10)  NULL,
    [Lastname] varchar(35)  NULL,
    [Firstname] varchar(35)  NULL,
    [Address] varchar(150)  NULL,
    [ZipCode] varchar(5)  NULL,
    [City] varchar(50)  NULL,
    [Phone] varchar(10)  NULL,
    [IsOnline] bit  NULL
);
GO

-- Creating table 'Role'
CREATE TABLE [dbo].[Role] (
    [IdRole] uniqueidentifier  NOT NULL,
    [RoleName] nvarchar(35)  NOT NULL
);
GO

-- Creating table 'Clients_Roles'
CREATE TABLE [dbo].[Clients_Roles] (
    [IdClient_Roles] uniqueidentifier  NOT NULL,
    [ClientIDClient] uniqueidentifier  NOT NULL,
    [RoleName] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IDClient] in table 'Client'
ALTER TABLE [dbo].[Client]
ADD CONSTRAINT [PK_Client]
    PRIMARY KEY CLUSTERED ([IDClient] ASC);
GO

-- Creating primary key on [IdRole] in table 'Role'
ALTER TABLE [dbo].[Role]
ADD CONSTRAINT [PK_Role]
    PRIMARY KEY CLUSTERED ([IdRole] ASC);
GO

-- Creating primary key on [IdClient_Roles] in table 'Clients_Roles'
ALTER TABLE [dbo].[Clients_Roles]
ADD CONSTRAINT [PK_Clients_Roles]
    PRIMARY KEY CLUSTERED ([IdClient_Roles] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ClientIDClient] in table 'Clients_Roles'
ALTER TABLE [dbo].[Clients_Roles]
ADD CONSTRAINT [FK_ClientClients_Roles]
    FOREIGN KEY ([ClientIDClient])
    REFERENCES [dbo].[Client]
        ([IDClient])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientClients_Roles'
CREATE INDEX [IX_FK_ClientClients_Roles]
ON [dbo].[Clients_Roles]
    ([ClientIDClient]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------