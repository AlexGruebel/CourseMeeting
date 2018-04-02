CREATE TABLE [dbo].[CourseSecundaryTeachers]
(
	 [CID] int FOREIGN KEY REFERENCES Courses (CID)
	,[TUID] int not null
)
