using System;
using System.Linq;
using WebApp.Models;

namespace WebApp.Pages
{
    public partial class ProfileSettings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (Data.DBContext context = new Data.DBContext())
            {
                CurrentUser = context.Set<User>()
                    .FirstOrDefault(u => u.UserLogin == User.Identity.Name);
            }
        }

        protected User CurrentUser { get; set; }
    }
}