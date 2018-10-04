using CourseMeetingEntitiesLib.dbo;
namespace CourseMeetingMVC.Models.Course
{
    public class MyCoursesViewModel
    {
        
        //The Courses the Teacher created
        public CourseMeetingEntitiesLib.dbo.Course[] Courses {get;set;}

        //The Meetings the Teacher created
        public CourseMeeting[] CourseMeetings{get;set;}       

    }
}