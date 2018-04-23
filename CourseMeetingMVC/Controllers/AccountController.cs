using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CourseMeetingMVC.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using CourseMeetingEntitiesLib.sec;
using CourseMeetingDbContextLib;

namespace CourseMeetingMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly CourseMeetingSecDB _db;
        

        private void CollectErrorsI(IdentityResult result){
            foreach(var error in result.Errors)
            {ModelState.AddModelError("Error: ",error.Description);}
        }

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, CourseMeetingSecDB db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult>Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = model.UserName,
                    Email = model.Email,
                };
                
                var result = await _userManager.CreateAsync(user, model.Password);
                await _userManager.AddToRoleAsync(user, model.Role);
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
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            
            User user = new User{
                UserName = model.UserName,
                PasswordHash = model.Password,
            };

            Console.WriteLine($"IsAuthenticated {User.Identity.IsAuthenticated}");
            
            var result = await _signInManager.
                PasswordSignInAsync(model.UserName, model.Password,true,true);
            Console.WriteLine($"IsAuthenticated {User.Identity.IsAuthenticated}");
            Console.WriteLine(User.Identity.Name);
            
            if (result.Succeeded){
                Console.WriteLine("success");
                return Redirect("/Home/Index");
            }else{
                Console.WriteLine("failure");
                ModelState.AddModelError("Error: ", "invalid Login data");
                return View(model);
            }   
        }

        public async Task<IActionResult> SignOut()
        {
            
            await _signInManager.SignOutAsync();
            return Redirect("/Home/Index");
        }


        /*
        var queryJoin = categories.Join(products,
category => category.CategoryID,
product => product.CategoryID,
(c, p) => new { c.CategoryName, p.ProductName,
p.ProductID });
        
        
         */



        public async Task<IActionResult> Profil(){
            var user = await _userManager.GetUserAsync(User);
            _db.IdentityUserRole.Join(_db.Roles
                                        ,i => i.RoleId
                                        ,r => r.Id 
                                        ,(id, ro) => new {ro.Name, id.UserId})
                                .Where(i => i.UserId == user.Id);
                                
            var model = new ProfilViewModel{
                UserName = user.UserName,
                EMail = user.Email,
                PhoneNumber = user.PhoneNumber,
                
                Role = _db.IdentityUserRole.Join(_db.Roles
                                        ,i => i.RoleId
                                        ,r => r.Id 
                                        ,(id, ro) => new {ro.Name, id.UserId})
                                .Where(i => i.UserId == user.Id).Select(r => r.Name).FirstOrDefault().ToString(),               
            };
            
            
            return View(model);
        }

    }
}