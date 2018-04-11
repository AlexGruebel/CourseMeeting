using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CourseMeetingMVC.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using CourseMeetingEntitiesLib.sec;

namespace CourseMeetingMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        private void CollectErrorsI(IdentityResult result){
            foreach(var error in result.Errors)
            {ModelState.AddModelError("Error: ",error.Description);}
        }

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    RID = 1,
                };
                
                var result = await _userManager.CreateAsync(user, model.Password);
                if(result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent:false);
                    return Redirect("/Home/Index");
                }
                CollectErrorsI(result);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            
            User user = new User{
                UserName = model.UserName,
                PasswordHash = model.Password,
            };
            
            var result = await _signInManager.
                PasswordSignInAsync(model.UserName, model.Password,false,true);        
            if(result.Succeeded){
                Console.WriteLine("success");
                return Redirect("/Home/Index");
            }else{
                Console.WriteLine("failure");
                ModelState.AddModelError("Error: ", "invalid Login data");
                return View(model);
            }   
        }
    }
}