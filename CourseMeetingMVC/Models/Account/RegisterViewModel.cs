using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CourseMeetingMVC.Models.Account
{
    public class RegisterViewModel
    {
        public string UserName { get; set;}
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        [Compare("Password", ErrorMessage ="The two Passwords have to be equal!")]
        public string PasswordConfirmation { get; set; }
    }
}
