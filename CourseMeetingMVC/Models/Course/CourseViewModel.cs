using CourseMeetingEntitiesLib.dbo;

namespace CourseMeetingMVC.Models.Course
{
    public class CourseViewModel
    {
        public  CourseMeetingEntitiesLib.dbo.Course Course {get;set;}
        public MeetingWithCountParticpants[] MWithCParticpants {get;set;}
    }
}