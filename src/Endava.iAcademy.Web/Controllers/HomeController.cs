using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using Endava.iAcademy.Repository;
using Endava.iAcademy.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Endava.iAcademy.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Endava.iAcademy.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [AllowAnonymous]
        public IActionResult Index(string sortParam, string categoryParam, string searchParam)
        {   
            var courseRepository = new CourseRepository();
            var coursesViewModel = new CoursesViewModel();

            coursesViewModel.SortParam = sortParam;
            coursesViewModel.Category = categoryParam;

            coursesViewModel.Courses = courseRepository.GetAllCoursesHome(sortParam, categoryParam, searchParam);
            return View(coursesViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
