using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApp.DataClassLibrary;
using WebApp.DataClassLibrary.Models;
using WebApp.MVC.Models;

namespace WebApp.MVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User lookupUser;
                using (DBContext context = new DBContext())
                {
                    lookupUser = context.Users
                        .FirstOrDefault(u => u.UserLogin == model.Name);
                }
                if (lookupUser == null ||
                    !BCrypt.Net.BCrypt.Verify(model.Password,lookupUser.UserPass))
                {
                    ModelState.AddModelError("UserNotFound", Resources.Language.LoginFailedYouDoNotExist);
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(model.Name, model.PersistantCookie);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public RedirectResult LogOut(string returnUrl = "/")
        {
            FormsAuthentication.SignOut();
            return Redirect(returnUrl);
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(SignUpModel model)
        {
            if (ModelState.IsValid)
            {
                using (DBContext context = new DBContext())
                {
                    User lookupUser = context.Users.FirstOrDefault(u =>
                        u.UserLogin == model.Login || u.UserEMail == model.Email);
                    if (lookupUser == null)
                    {
                        context.Add(new User
                        {
                            UserLogin = model.Login,
                            UserName = model.Name,
                            UserPass = BCrypt.Net.BCrypt.HashPassword(model.Password),
                            UserEMail = model.Email
                        });
                        context.SaveChanges();
                        FormsAuthentication.SetAuthCookie(model.Login, true);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty,
                            "User with the same login or email already exists");
                    }
                }
            }
            return View(model);
        }
    }
}