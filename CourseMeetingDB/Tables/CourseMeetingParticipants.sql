CREATE TABLE [dbo].[CourseMeetingParticipants]
(
	 [MID] INT FOREIGN KEY REFERENCES CourseMeetings (MID)
	,[UID] INT NOT NULL
)
