using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CourseMeetingEntitiesLib.sec;
using System.Threading.Tasks;


namespace CourseMeetingMVC.Controllers
{
    public class SharedController : Controller
    {
        private readonly SignInManager<User> _signinManger;

        public SharedController(SignInManager<User> signInManager)
        {
            this._signinManger = signInManager;
        }

        public async Task<IActionResult> SignOut()
        {
            
            await _signinManger.SignOutAsync();
            return Redirect("Home/Index");
        }
    }
}