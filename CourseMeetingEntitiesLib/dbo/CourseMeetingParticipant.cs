//using CourseMeetingEntitiesLib.sec;
namespace CourseMeetingEntitiesLib.dbo
{
    public class CourseMeetingParticipant
    {
        public int MID{ get; set; }
        public CourseMeeting CourseMeeting { get; set; }
        public string SUID { get; set; }
        //public User Student { get; set; }
    }
}
