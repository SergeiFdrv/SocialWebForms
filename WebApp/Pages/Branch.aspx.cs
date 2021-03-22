using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages
{
    public partial class Branch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (DBContext context = new DBContext())
            {
                string slug = RouteData.Values["category"]?.ToString();
                MainCategory
                    //= context.Set<Category>().FirstOrDefault(
                    = Data.Categories.All.FirstOrDefault(
                    c => c.CategorySlug == slug) ??
                    Data.Categories.GetCategory(0);
                RecentPostTiles.Posts = context.Posts.Include(p => p.PostAuthor)
                    .Where(p => p.PostCategoryID == MainCategory.CategoryID).ToList();
            }
        }

        public Category MainCategory { get; set; }
    }
}