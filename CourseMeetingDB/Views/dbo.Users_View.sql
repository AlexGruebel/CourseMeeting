Create VIEW [dbo].[Users_View] AS
SELECT u.[UID]
      ,[UserName]
      ,r.[RoleID]
      ,[Email]
      ,[PhoneNumber]
FROM [CourseMeetingDB].[sec].[Users] u
join [CourseMeetingDB].[sec].[IdentityUserRole] r on u.UID = r.UserID
