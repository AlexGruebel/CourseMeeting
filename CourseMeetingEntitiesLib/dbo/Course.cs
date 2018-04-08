using System;
using System.Collections.Generic;
using System.Text;

namespace CourseMeetingEntitiesLib.dbo
{
    public class Course
    {
        public int CID { get; set; }
        public string CName { get; set; }
        public string CDescription { get; set; }
        //primary Teacher UID
        public int PTUID { get; set; }
        //public User PTeacher { get; set; }
        //secundary Teachers
        public IList<CourseSecundaryTeacher> STeachers {get;set;}
        public IList<CourseMeeting> CourseMeetings { get; set; }
    }
}
