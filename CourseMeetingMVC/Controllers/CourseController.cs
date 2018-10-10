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

        private string _UserID;

        public CourseController(CourseMeetingDb CourseMeetingDb, UserManager<User> userManager){
            this._db = CourseMeetingDb;
            this._UserManger = userManager;
            //this._UserID = userManager.GetUserId(User);
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

        [HttpGet]
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


        [HttpGet]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> MyMeetings()
        {
            this._UserID = await this._UserManger.GetUserIdAsync(await this._UserManger.GetUserAsync(User));
            var model = new MyMeetingsViewModel{
                CourseMeetings = await this._db.CourseMeetings.Include(c => c.Course).Join( (_db.CourseMeetingParticipants.Where(p => p.SUID == this._UserID))
                                           ,c => c.MID
                                           ,p => p.MID
                                           ,(c, p) => c)
                                           .Include(c => c.Teacher)
                                           .ToArrayAsync(),
            };                                           
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> Unsubscribe(int id)
        {
            this._UserID = await this._UserManger.GetUserIdAsync(await this._UserManger.GetUserAsync(User));            
            var mp = await _db.CourseMeetingParticipants.Where(m => m.MID == id && m.SUID == this._UserID)
                    .FirstOrDefaultAsync();
            this._db.CourseMeetingParticipants
                .Remove(mp);

            await _db.SaveChangesAsync();
            return Ok();
        }


        [HttpGet]
        [Authorize(Roles="Teacher")]
        public async Task<IActionResult> MyCourses(){
            this._UserID = await this._UserManger.GetUserIdAsync(await this._UserManger.GetUserAsync(User));            

            var model = new MyCoursesViewModel{
                Courses = await this._db.Courses
                                    .Where(c => c.PTUID == this._UserID)
                                    .ToArrayAsync(),
                CourseMeetings = await this._db.CourseMeetings
                                            .Where(c => c.TUID == this._UserID)
                                            .ToArrayAsync(),
            };
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles="Teacher")]
        public IActionResult CreateCourse()
        {
            
            return View();
        }

        [HttpPost]
        [Authorize(Roles="Teacher")]
        public async Task<Task<IActionResult>> CreateCourse(Course course){
            course.PTUID = await this._UserManger.GetUserIdAsync(await this._UserManger.GetUserAsync(User));            
            await this._db.AddAsync(course);
            await this._db.SaveChangesAsync();
            return MyCourses();
        }

        [HttpPut]
        [Authorize(Roles="Teacher")]
        public async Task<IActionResult> UpdateCourse(Course course){
            course.PTUID = await this._UserManger.GetUserIdAsync(await this._UserManger.GetUserAsync(User));            
            this._db.Courses.Update(course);
            await this._db.SaveChangesAsync();
            return Ok();
        }
    }
}