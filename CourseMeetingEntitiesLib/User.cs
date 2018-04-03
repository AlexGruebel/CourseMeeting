using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;


namespace CourseMeetingEntitiesLib
{
    public class User : IdentityUser
    {
        public int RID { get; set; }
        public Role Role {get;set;}
        public IList<CourseMeetingParticipant> Courses;
    }
}
