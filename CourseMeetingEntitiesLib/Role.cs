using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace CourseMeetingEntitiesLib
{
    public class Role : IdentityRole
    {
        public int RID { get; set; }
        public string RName { get; set; }
        public string RDescription { get; set; }
    }
}
