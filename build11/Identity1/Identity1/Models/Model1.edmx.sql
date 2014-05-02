
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/02/2014 20:10:28
-- Generated from EDMX file: C:\Users\issadmin\bodyline\build11\Identity1\Identity1\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Identity1-1-14];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ActivityGymClass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GymClasses] DROP CONSTRAINT [FK_ActivityGymClass];
GO
IF OBJECT_ID(N'[dbo].[FK_RoomGymClass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GymClasses] DROP CONSTRAINT [FK_RoomGymClass];
GO
IF OBJECT_ID(N'[dbo].[FK_ActivityMemberLog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MemberLogs] DROP CONSTRAINT [FK_ActivityMemberLog];
GO
IF OBJECT_ID(N'[dbo].[FK_GymClassBookedBy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookedBies] DROP CONSTRAINT [FK_GymClassBookedBy];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Activities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Activities];
GO
IF OBJECT_ID(N'[dbo].[Rooms]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rooms];
GO
IF OBJECT_ID(N'[dbo].[GymClasses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GymClasses];
GO
IF OBJECT_ID(N'[dbo].[ClassBookings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClassBookings];
GO
IF OBJECT_ID(N'[dbo].[MemberLogs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MemberLogs];
GO
IF OBJECT_ID(N'[dbo].[BookedBies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BookedBies];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Activities'
CREATE TABLE [dbo].[Activities] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ActivityName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Rooms'
CREATE TABLE [dbo].[Rooms] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RoomName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'GymClasses'
CREATE TABLE [dbo].[GymClasses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [Duration] smallint  NOT NULL,
    [ActivityId] int  NOT NULL,
    [RoomId] int  NOT NULL
);
GO

-- Creating table 'ClassBookings'
CREATE TABLE [dbo].[ClassBookings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MembershipNo] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [Email] int  NOT NULL
);
GO

-- Creating table 'MemberLogs'
CREATE TABLE [dbo].[MemberLogs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ActivityId] int  NOT NULL,
    [Duration] smallint  NOT NULL,
    [Date] datetime  NOT NULL,
    [ProfileMembershipNo] nvarchar(max)  NOT NULL,
    [ProfileId] int  NOT NULL
);
GO

-- Creating table 'BookedBies'
CREATE TABLE [dbo].[BookedBies] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MembershipNo] nvarchar(max)  NOT NULL,
    [GymClassId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Activities'
ALTER TABLE [dbo].[Activities]
ADD CONSTRAINT [PK_Activities]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [PK_Rooms]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GymClasses'
ALTER TABLE [dbo].[GymClasses]
ADD CONSTRAINT [PK_GymClasses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ClassBookings'
ALTER TABLE [dbo].[ClassBookings]
ADD CONSTRAINT [PK_ClassBookings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MemberLogs'
ALTER TABLE [dbo].[MemberLogs]
ADD CONSTRAINT [PK_MemberLogs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BookedBies'
ALTER TABLE [dbo].[BookedBies]
ADD CONSTRAINT [PK_BookedBies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ActivityId] in table 'GymClasses'
ALTER TABLE [dbo].[GymClasses]
ADD CONSTRAINT [FK_ActivityGymClass]
    FOREIGN KEY ([ActivityId])
    REFERENCES [dbo].[Activities]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ActivityGymClass'
CREATE INDEX [IX_FK_ActivityGymClass]
ON [dbo].[GymClasses]
    ([ActivityId]);
GO

-- Creating foreign key on [RoomId] in table 'GymClasses'
ALTER TABLE [dbo].[GymClasses]
ADD CONSTRAINT [FK_RoomGymClass]
    FOREIGN KEY ([RoomId])
    REFERENCES [dbo].[Rooms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RoomGymClass'
CREATE INDEX [IX_FK_RoomGymClass]
ON [dbo].[GymClasses]
    ([RoomId]);
GO

-- Creating foreign key on [ActivityId] in table 'MemberLogs'
ALTER TABLE [dbo].[MemberLogs]
ADD CONSTRAINT [FK_ActivityMemberLog]
    FOREIGN KEY ([ActivityId])
    REFERENCES [dbo].[Activities]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ActivityMemberLog'
CREATE INDEX [IX_FK_ActivityMemberLog]
ON [dbo].[MemberLogs]
    ([ActivityId]);
GO

-- Creating foreign key on [GymClassId] in table 'BookedBies'
ALTER TABLE [dbo].[BookedBies]
ADD CONSTRAINT [FK_GymClassBookedBy]
    FOREIGN KEY ([GymClassId])
    REFERENCES [dbo].[GymClasses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GymClassBookedBy'
CREATE INDEX [IX_FK_GymClassBookedBy]
ON [dbo].[BookedBies]
    ([GymClassId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------