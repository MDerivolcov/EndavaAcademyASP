using System.Linq;
using Endava.iAcademy.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Endava.iAcademy.Web.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class CourseController : Controller
    {
        private EndavaAcademyDbContext dbContext;
        public CourseController(EndavaAcademyDbContext context)
        {
            dbContext = context;
        }

        public IActionResult Index(int id)
        {
            var courseRepository = new CourseRepository(dbContext);
            var course = courseRepository.GetAllCourses().First(c => c.Id == id);
            return View(course);
        }
    }
}
