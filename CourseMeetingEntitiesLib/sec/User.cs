using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;


namespace CourseMeetingEntitiesLib.sec
{
    public class User : IdentityUser
    {
        public string RID { get; set; }
    }
}
