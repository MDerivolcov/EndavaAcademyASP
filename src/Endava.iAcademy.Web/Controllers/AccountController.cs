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
                        if (user.Role == "admin")
                        {
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
            using (EndavaAcademyDbContext dbContext = new EndavaAcademyDbContext())
            {
                if (ModelState.IsValid)
                {

                    User user = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                    if (user == null)
                    {
                        dbContext.Users.Add(new User { Email = model.Email, Password = model.Password, Role = model.Role });
                        await dbContext.SaveChangesAsync();

                        await Authenticate(model.Email);

                        return RedirectToAction("Login", "Account");
                    }
                    else
                        ModelState.AddModelError("", "Incorrect login and (or) password");
                }
                return View(model);
            }
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
            if (Request.Cookies["myCookie"] != null)
            {
                Response.Cookies.Delete("myCookie");
            }
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
