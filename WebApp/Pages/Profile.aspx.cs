using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebApp.Models;

namespace WebApp.Pages
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (Data.DBContext context = new Data.DBContext())
            {
                CurrentUser = context.Set<User>()
                    .Include(u => u.Posts).Include(u => u.Comments)
                    .FirstOrDefault(u => u.UserLogin == User.Identity.Name);
                PostTiles.Posts = CurrentUser.Posts;
            }
        }

        protected User CurrentUser { get; set; }
    }
}