using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages
{
    public partial class Article : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (DBContext context = new DBContext())
            {
                int id = Convert.ToInt32(RouteData.Values["id"]?.ToString());
                string slug = RouteData.Values["title"]?.ToString();
                var posts = context.Posts.ToList();
                Post = posts.FirstOrDefault(
                    p => p.PostID == id || p.Slug == slug);
                if (Post.PostCategoryID.HasValue)
                {
                    Category = Categories.GetCategory(Post.PostCategoryID.Value);
                }
            }
        }

        protected Post Post { get; set; }

        protected Category Category { get; set; }
    }
}