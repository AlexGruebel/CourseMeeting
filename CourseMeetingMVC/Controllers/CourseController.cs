using Microsoft.AspNetCore.Mvc;
using CourseMeetingDbContextLib;
using CourseMeetingMVC.Models.Course;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace CourseMeetingMVC.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseMeetingDb _db;

        public CourseController(CourseMeetingDb CourseMeetingDb){
            this._db = CourseMeetingDb;
        }

        [HttpGet]
        public async Task<IActionResult> Courses()
        {
            var model = new CoursesViewModel{
                Courses = await _db.Courses.OrderBy(c => c.CName).Take(20).ToArrayAsync(),
            };
            return View(model);
        }

        [HttpGet]   
        public async Task<IActionResult> Course(int id)
        {
            var model = new CourseViewModel
                {
                   Course = await _db.Courses
                                .Where(c => c.CID == id)
                                .FirstOrDefaultAsync(),

                   MWithCParticpants = await _db.MeetingWithCountParticpants
                                .Where(c => c.CID == id)
                                .OrderBy(c => c.DateOfTheMeeting)
                                .ToArrayAsync(),
                };
            return View(model);
        }
    }
}