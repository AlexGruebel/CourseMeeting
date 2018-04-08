using System;
using System.Collections.Generic;

namespace CourseMeetingEntitiesLib.dbo
{
    public class CourseMeeting
    {
        public int MID{ get; set; }
        public int CID { get; set; }
        public Course Course { get; set; }
        public DateTime DateOfTheMeeting { get; set; }
        public int MaxParticpants { get; set; }
        public IList<CourseMeetingParticipant> CourseMeetingParticipants { get; set; }
    }
}
