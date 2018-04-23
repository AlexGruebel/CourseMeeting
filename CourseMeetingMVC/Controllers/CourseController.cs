using Microsoft.AspNetCore.Mvc;
using CourseMeetingDbContextLib;
using CourseMeetingMVC.Models.Course;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Linq;
using CourseMeetingEntitiesLib.dbo;
using CourseMeetingEntitiesLib.sec;
using Microsoft.AspNetCore.Identity;

namespace CourseMeetingMVC.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseMeetingDb _db;
        private readonly UserManager<User> _UserManger;

        public CourseController(CourseMeetingDb CourseMeetingDb, UserManager<User> userManager){
            this._db = CourseMeetingDb;
            this._UserManger = userManager;
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
        //[Authorize(Roles = "Student")]
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

        [HttpPost]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> SignInToCourseMeeting(int id){
            var participant = new CourseMeetingParticipant{
                    MID = id,
                    SUID = await _UserManger.GetUserIdAsync(await _UserManger.GetUserAsync(User)),
                };
            _db.CourseMeetingParticipants.Add(participant);
            await _db.SaveChangesAsync();
            return Redirect("/Course/Courses");
        }
    }
}