using System.Linq;
using Endava.iAcademy.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Endava.iAcademy.Web.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        public IActionResult Index(int id)
        {
            var courseRepository = new CourseRepository();
            var course = courseRepository.GetAllCourses().First(c => c.Id == id);
            return View(course);
        }
    }
}
