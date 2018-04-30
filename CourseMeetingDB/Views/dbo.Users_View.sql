create VIEW [dbo].[Users_View] AS
SELECT [UID]
      ,[UserName]
      ,[Email]
      ,[PhoneNumber]
FROM [CourseMeetingDB].[sec].[Users]
