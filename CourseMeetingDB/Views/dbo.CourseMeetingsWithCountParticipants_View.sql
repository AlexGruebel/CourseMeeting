Create View [dbo].[CourseMeetingsWithCountParticipants_View] as
SELECT m.[MID]
      ,m.[CID]
      ,m.[TUID]
      ,t.[UserName] as TName
      ,m.[DateOfTheMeeting]
      ,m.[MaxParticipants]
      ,ISNULL(p.Participants,0) as Participants
FROM [CourseMeetingDB].[dbo].[CourseMeetings] m
left join (select count(SUID) as Participants, MID from CourseMeetingDB.dbo.CourseMeetingParticipants Group by MID) p on m.MID = p.MID
join [CourseMeetingDB].[sec].[Users] t on t.UID = m.TUID


