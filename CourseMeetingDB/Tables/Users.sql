CREATE TABLE [dbo].[Users]
(
	[UID] INT IDENTITY(0,1) PRIMARY KEY
   ,[FirstName] [nvarchar](50) NOT NULL
   ,[LastName] [nvarchar](50) NOT NULL
   ,[RID] INT Foreign Key References Roles (RID)
   ,[email] [nvarchar](255) NOT NULL
   ,[emailConfirmed] [BIT] NOT NULL
   ,[PasswordHash] [nvarchar](500) NOT NULL
   ,[CreationDate] [datetime2] Default (getdate())
)