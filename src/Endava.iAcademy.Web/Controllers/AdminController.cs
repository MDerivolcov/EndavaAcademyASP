using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Endava.iAcademy.Domain;
using Endava.iAcademy.Repository;
using System.Diagnostics;
using Endava.iAcademy.Web.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Endava.iAcademy.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using(EndavaAcademyDbContext dbContext = new EndavaAcademyDbContext())
            {
                if(Request.Cookies["myCookie"] == "admin") 
                {
                    return View(dbContext.Courses.ToList());
                }
                return RedirectToAction("Index","Home");
            }
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            using(EndavaAcademyDbContext dbContext = new EndavaAcademyDbContext())
            {
                var c = from i in dbContext.Courses
                             where i.Id == id
                             select i;

                var course = c.FirstOrDefault(); 

                course.Lessons = dbContext.Lessons.Where(x => x.CourseId == id).ToList<Lesson>();
                return View(course);
            }
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            try
            {
                using (EndavaAcademyDbContext db = new EndavaAcademyDbContext())
                {
                    db.Courses.Add(course);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            using (EndavaAcademyDbContext dbContext = new EndavaAcademyDbContext())
            {
                var c = from i in dbContext.Courses
                                         where i.Id == id
                                         select i;

                var course = c.FirstOrDefault();

                course.Lessons = dbContext.Lessons.Where(x => x.CourseId == id).ToList<Lesson>();
                
                return View(course);
            }
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Course course)
        {
            try
            {
                using(EndavaAcademyDbContext dbContext = new EndavaAcademyDbContext())
                {
                    dbContext.Entry(course).State = EntityState.Modified;
                    dbContext.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            using (EndavaAcademyDbContext dbContext = new EndavaAcademyDbContext())
            {
                return View(dbContext.Courses.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                using(EndavaAcademyDbContext dbContext = new EndavaAcademyDbContext())
                {
                    Course course = dbContext.Courses.Where(x => x.Id == id).FirstOrDefault();
                    dbContext.Courses.Remove(course);
                    dbContext.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: Admin/CreateLesson
        public ActionResult CreateLesson()
        {
            return View();
        }

        // POST: Admin/CreateLesson
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateLesson(Lesson lesson)
        {
            try
            {
                using (EndavaAcademyDbContext db = new EndavaAcademyDbContext())
                {
                    db.Lessons.Add(lesson);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Admin/Delete/5
        public ActionResult DeleteLesson()
        {
            return View();
        }

        // POST: Admin/DeleteLesson/5
        [HttpPost]
        public ActionResult DeleteLesson(int id)
        {
            try
            {
                using (EndavaAcademyDbContext dbContext = new EndavaAcademyDbContext())
                {
                    Lesson lesson = dbContext.Lessons.Where(x => x.Id == id).FirstOrDefault();
                    dbContext.Lessons.Remove(lesson);
                    dbContext.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
