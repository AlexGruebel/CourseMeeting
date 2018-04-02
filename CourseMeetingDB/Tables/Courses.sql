CREATE TABLE [dbo].[Courses]
(
	[CID] INT IDENTITY(0,1) PRIMARY KEY, 
    [CName] NCHAR(20) NOT NULL, 
    [CDescription] NCHAR(400) NULL, 
    [PTUID] INT NOT NULL
)
