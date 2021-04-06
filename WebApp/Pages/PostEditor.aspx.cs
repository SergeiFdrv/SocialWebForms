using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using WebApp.DataClassLibrary;
using WebApp.DataClassLibrary.Models;

namespace WebApp.Pages
{
    public partial class PostEditor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (DBContext context = new DBContext())
            {
                CurrentUser = context.Set<User>()
                    .FirstOrDefault(u => u.UserLogin == User.Identity.Name);
                Categories = DataClassLibrary.Categories.All;
                if (int.TryParse(RouteData.Values["id"]?.ToString(), out int postID))
                {
                    CurrentPost = context.Set<Post>().FirstOrDefault(p => p.PostID == postID);
                    PostTitle.Value = CurrentPost.PostTitle;
                }
            }
        }

        protected User CurrentUser { get; set; }

        protected List<Category> Categories { get; set; }

        protected Post CurrentPost { get; set; }

        protected void Submit_Click(object sender, EventArgs e)
        {
            int categoryID = Convert.ToInt32(Request.Form["categoryList"]);
            Category category = Categories.FirstOrDefault(c => c.CategoryID == categoryID);
            string content = Request.Form["ckeditor"];
            using (DBContext context = new DBContext())
            {
                if (CurrentPost is null) CurrentPost = new Post();
                CurrentPost.PostAuthor = context.Set<User>()
                    .FirstOrDefault(u => u.UserLogin == User.Identity.Name);
                CurrentPost.PostTitle = PostTitle.Value;
                CurrentPost.PostContent = content;
                CurrentPost.PostCategoryID = categoryID;
                CurrentPost.PostEditedUTC = DateTime.UtcNow;
                context.Update(CurrentPost);
                try
                {
                    context.SaveChanges();
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException x)
                {
                    if (x.InnerException.Message.Contains("Title"))
                    {
                        PostTitle.Value = string.Empty;
                    }
                    else if (x.InnerException.Message.Contains("Content"))
                    {
                        //Request.Form["ckeditor"] = string.Empty;
                    }
                    else throw x;
                    return;
                }
            }
            Response.Redirect(
                GetRouteUrl("category-posts", new { category = category.CategorySlug }));
        }

        protected void DeleteYes_Click(object sender, EventArgs e)
        {
            using (DBContext context = new DBContext())
            {
                context.Remove(CurrentPost);
                context.SaveChanges();
            }
            Response.Redirect(GetRouteUrl("user-writepost", null));
        }
    }
}