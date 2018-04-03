CREATE TABLE [dbo].[CourseSecundaryTeachers]
(
	 [CID] int FOREIGN KEY REFERENCES Courses (CID)
	,[STUID] int not null
)
