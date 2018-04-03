using System;
using System.Collections.Generic;
using System.Text;

namespace CourseMeetingEntitiesLib
{
    public class CourseSecundaryTeacher
    {
        public int CID { get; set; }
        //secundary Teacher UID
        public int STUID { get; set; }
        public User STeacher { get; set; }
    }
}
