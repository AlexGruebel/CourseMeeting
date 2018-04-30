using System.Collections.Generic;

namespace CourseMeetingEntitiesLib.dbo
{
    public class Teacher : DUser
    {
        public IList<CourseMeeting> CourseMeetings { get; set; }
    }
}