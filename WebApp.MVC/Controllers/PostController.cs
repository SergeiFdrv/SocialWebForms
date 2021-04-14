using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.DataClassLibrary;
using WebApp.DataClassLibrary.Models;
using WebApp.MVC.Models;

namespace WebApp.MVC.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index(int id, string name = "")
        {
            using (DBContext context = new DBContext())
            {
                var post = context.Posts.Include(p => p.Comments).Include(p => p.PostTagPairs)
                    .Include(p => p.PostAuthor).ThenInclude(u => u.Posts)
                    .FirstOrDefault(p => p.PostID == id);
                return View(post);
            }
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            ViewResult res = null;
            using (DBContext context = new DBContext())
            {
                var post = context.Posts.Find(id);
                if (post != null/* && post.PostAuthor.UserLogin == ""*/)
                {
                    PostModel model = new PostModel
                    {
                        Title = post.PostTitle,
                        Content = post.PostContent,
                        CategoryID = post.PostCategoryID
                    };
                    res = View(model);
                }
            }
            return res ?? View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PostModel model)
        {
            if (ModelState.IsValid)
            {
                using (DBContext context = new DBContext())
                {
                    var post = new Post
                    {
                        PostTitle = model.Title,
                        PostContent = model.Content,
                        PostCategoryID = model.CategoryID,
                        PostAuthor = context.Users.Find(model.Author)
                    };
                    try
                    {
                        context.Update(post);
                    }
                    catch (Exception x)
                    {
                        ModelState.AddModelError(x.Message, x);
                    }
                    return RedirectToAction("Index", "Post", new { id = post.PostID });
                }
            }
            return View(model);
        }
    }
}