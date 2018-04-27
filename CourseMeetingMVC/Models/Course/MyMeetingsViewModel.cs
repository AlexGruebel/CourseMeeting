using CourseMeetingEntitiesLib.dbo;
namespace CourseMeetingMVC.Models.Course
{
    public class MyMeetingsViewModel
    {
        public CourseMeetingEntitiesLib.dbo.CourseMeeting[] CourseMeetings {get;set;}
    }
}