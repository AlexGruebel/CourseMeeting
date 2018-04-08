CREATE TABLE [dbo].[CourseMeetings]
(
	[MID] INT IDENTITY(0,1) PRIMARY KEY
   ,[CID] INT FOREIGN KEY REFERENCES Courses (CID)
   ,[DateOfTheMeeting] datetime2 not null
   ,[MaxParticipants] int not null
)
