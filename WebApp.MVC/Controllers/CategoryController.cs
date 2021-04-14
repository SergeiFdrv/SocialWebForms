using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.DataClassLibrary;
using WebApp.DataClassLibrary.Models;

namespace WebApp.MVC.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult Index(int id, string name)
        {
            Category category = Categories.GetCategory(id) ?? Categories.GetCategory(name);
            if (category == null)
            {
                Response.StatusCode = 404;
                return View();
            }
            return View(category);
        }
    }
}