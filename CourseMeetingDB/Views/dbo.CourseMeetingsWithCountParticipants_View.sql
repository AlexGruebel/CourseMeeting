Create View [dbo].[CourseMeetingsWithCountParticipants_View] as
SELECT m.[MID]
      ,[CID]
      ,[DateOfTheMeeting]
      ,[MaxParticipants]
      ,ISNULL(p.Participants,0) as Participants
FROM [CourseMeetingDB].[dbo].[CourseMeetings] m
left join (select count(SUID) as Participants, MID from CourseMeetingDB.dbo.CourseMeetingParticipants Group by MID) p on m.MID = p.MID


