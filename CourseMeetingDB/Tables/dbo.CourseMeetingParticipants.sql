CREATE TABLE [dbo].[CourseMeetingParticipants]
(
	 [MID] INT FOREIGN KEY REFERENCES CourseMeetings (MID)
	,[SUID] varchar(100) NOT NULL
)
