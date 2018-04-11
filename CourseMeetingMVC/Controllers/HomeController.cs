using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CourseMeetingMVC.Models;
using CourseMeetingDbContextLib;
using CourseMeetingEntitiesLib.sec;

namespace CourseMeetingMVC.Controllers
{
    public class HomeController : Controller
    {

        //private CourseMeetingDb _db;

        /*
        public HomeController(CourseMeetingDb db)
        {
            _db = db;
        }
        */
        public IActionResult Index()
        {
            //var test = _db.Courses.OrderBy(c => c.CID).ToArray();
            //PTeacherId
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
