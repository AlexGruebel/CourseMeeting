using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CourseMeetingEntitiesLib.sec;
using System.Threading.Tasks;
using CourseMeetingMVC.Models._Shared;

namespace CourseMeetingMVC.Controllers
{
    public class SharedController : Controller
    {
        private readonly SignInManager<User> _signinManger;

        public SharedController(SignInManager<User> signInManager)
        {
            this._signinManger = signInManager;
        }

        [HttpGet]
        public IActionResult _Layout(){
            _SharedViewModel model = new _SharedViewModel{
                UserName = User.Identity.Name,
                IsSomeoneLogined = false,
            };        
            return View(model);
        }
    }
}