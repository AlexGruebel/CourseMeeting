/*
Deployment script for CourseMeetingDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "CourseMeetingDB"
:setvar DefaultFilePrefix "CourseMeetingDB"
:setvar DefaultDataPath ""
:setvar DefaultLogPath ""

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

CREATE DATABASE CourseMeetingDB

Use CourseMeetingDB

GO
PRINT N'Creating [dbo].[CourseMeetingParticipants]...';


GO
CREATE TABLE [dbo].[CourseMeetingParticipants] (
    [MID]  INT NULL,
    [SUID] INT NOT NULL
);


GO
PRINT N'Creating [dbo].[CourseMeetings]...';


GO
CREATE TABLE [dbo].[CourseMeetings] (
    [MID]              INT           IDENTITY (0, 1) NOT NULL,
    [CID]              INT           NULL,
    [DateOfTheMeeting] DATETIME2 (7) NOT NULL,
    [MaxParticipants]  INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([MID] ASC)
);


GO
PRINT N'Creating [dbo].[Courses]...';


GO
CREATE TABLE [dbo].[Courses] (
    [CID]          INT         IDENTITY (0, 1) NOT NULL,
    [CName]        NCHAR (20)  NOT NULL,
    [CDescription] NCHAR (400) NULL,
    [PTUID]        INT         NOT NULL,
    PRIMARY KEY CLUSTERED ([CID] ASC)
);


GO
PRINT N'Creating [dbo].[CourseSecundaryTeachers]...';


GO
CREATE TABLE [dbo].[CourseSecundaryTeachers] (
    [CID]   INT NULL,
    [STUID] INT NOT NULL
);


GO
PRINT N'Creating [dbo].[Roles]...';


GO
CREATE TABLE [dbo].[Roles] (
    [RID]          INT            NOT NULL,
    [RName]        NVARCHAR (20)  NOT NULL,
    [RDescription] NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([RID] ASC)
);


GO
PRINT N'Creating [dbo].[Users]...';


GO
CREATE TABLE [dbo].[Users] (
    [UID]            INT            IDENTITY (0, 1) NOT NULL,
    [UserName]       NVARCHAR (50)  NOT NULL,
    [RID]            INT            NULL,
    [email]          NVARCHAR (256) NOT NULL,
    [emailConfirmed] BIT            NOT NULL,
    [PasswordHash]   NVARCHAR (500) NOT NULL,
    [CreationDate]   DATETIME2 (7)  NULL,
    PRIMARY KEY CLUSTERED ([UID] ASC)
);


GO
PRINT N'Creating unnamed constraint on [dbo].[Users]...';


GO
ALTER TABLE [dbo].[Users]
    ADD DEFAULT (getdate()) FOR [CreationDate];


GO
PRINT N'Creating unnamed constraint on [dbo].[CourseMeetingParticipants]...';


GO
ALTER TABLE [dbo].[CourseMeetingParticipants]
    ADD FOREIGN KEY ([MID]) REFERENCES [dbo].[CourseMeetings] ([MID]);


GO
PRINT N'Creating unnamed constraint on [dbo].[CourseMeetings]...';


GO
ALTER TABLE [dbo].[CourseMeetings]
    ADD FOREIGN KEY ([CID]) REFERENCES [dbo].[Courses] ([CID]);


GO
PRINT N'Creating unnamed constraint on [dbo].[CourseSecundaryTeachers]...';


GO
ALTER TABLE [dbo].[CourseSecundaryTeachers]
    ADD FOREIGN KEY ([CID]) REFERENCES [dbo].[Courses] ([CID]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Users]...';


GO
ALTER TABLE [dbo].[Users]
    ADD FOREIGN KEY ([RID]) REFERENCES [dbo].[Roles] ([RID]);


GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Update complete.';


GO
