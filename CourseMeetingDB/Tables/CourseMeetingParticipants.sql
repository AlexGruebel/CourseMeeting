CREATE TABLE [dbo].[CourseMeetingParticipants]
(
	 [MID] INT FOREIGN KEY REFERENCES CourseMeetings (MID)
	,[SUID] INT NOT NULL
)
