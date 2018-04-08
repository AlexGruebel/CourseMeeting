using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace CourseMeetingEntitiesLib.sec
{
    public class Role : IdentityRole
    {
        public int RID { get; set; }
        public string RName { get; set; }
        public string RDescription { get; set; }

        public User User {get;set;}
    }
}
