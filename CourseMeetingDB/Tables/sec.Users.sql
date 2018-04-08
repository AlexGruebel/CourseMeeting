CREATE TABLE [sec].[Users]
(
	[UID] [nvarchar](500) NOT NULL,
    [AccessFailedCount] [int] NOT NULL,
    [ConcurrencyStamp] [text] NOT NULL,
    [email] [nvarchar](256) NOT NULL,
    [emailConfirmed] bit NULL,
    [LockoutEnabled] bit NULL,
    [LockoutEnd] [datetime] NULL,
    [NormalizedEmail] [nvarchar](256) NULL,
    [NormalizedUserName] [nvarchar](256) NULL,
    [PasswordHash] [nvarchar](500) NOT NULL,
    [PhoneNumber] [nvarchar](20) NULL,
    [PhoneNumberConfirmed] BIT NULL,
    [SecurityStamp] [varchar](500) NULL,
    [TwoFactorEnabled] bit NULL,
    [UserName] [nvarchar](50) NOT NULL,
    [RID] [int] NULL,
    [CreationDate] [datetime2](7) NULL
)