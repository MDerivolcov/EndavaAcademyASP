using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Endava.iAcademy.Domain;
using Endava.iAcademy.Repository;
using Endava.iAcademy.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Web;

namespace Endava.iAcademy.Web.Controllers
{
    public class AccountController : Controller
    {
        private DataContext db;
        public AccountController(DataContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            using (EndavaAcademyDbContext dbContext = new EndavaAcademyDbContext())
            {
                if (ModelState.IsValid)
                {
                User user = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                    {
                        await Authenticate(model.Email);

                        if(model.Email == "admin@mail.ru")
                        {
                            //test add cookie
                            Response.Cookies.Append("myCookie", "admin");
                        }
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("", "Incorrect login and (or) password");
                }
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //using (EndavaAcademyDbContext dbContext = new EndavaAcademyDbContext())
                //{
                    User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                    if (user == null)
                    {
                        // добавляем пользователя в бд
                        db.Users.Add(new User { Email = model.Email, Password = model.Password });
                        await db.SaveChangesAsync();

                        await Authenticate(model.Email); // аутентификация

                        return RedirectToAction("Index", "Home");
                    }
                    else
                        ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                //}
            }
            return View(model);
        }
        private async Task Authenticate(string userName)
        {
            // create one claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // Create objectClaimsIdentuty
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // ustanovca autentificationih kuki
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        public async Task<IActionResult> Logout()
        {
            /*   if (HttpContext.Request.Cookies.Count > 0)
               {
                   var siteCookies = HttpContext.Request.Cookies.Where(c => c.Key.Contains(".AspNetCore.") || c.Key.Contains("Microsoft.Authentication"));
                   foreach (var cookie in siteCookies)
                   {
                       Response.Cookies.Delete(cookie.Key);
                   }
               }

               await HttpContext.SignOutAsync(
               CookieAuthenticationDefaults.AuthenticationScheme);
               //HttpContext.Session.Clear();
               return RedirectToAction("Login", "Account");
            */

            if (Request.Cookies["myCookie"] != null)
            {
                Response.Cookies.Delete("myCookie");
            }
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
