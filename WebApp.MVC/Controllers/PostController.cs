using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.MVC.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }

        // GET: Post
        public ActionResult Index(int id)
        {
            return View(id);
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View(id);
        }

        // TODO: [HttpPost] public ActionResult Edit(Post post)
    }
}