using System;
using System.Linq;
using System.Web.UI;
using WebApp.Models;

namespace WebApp.Pages
{
    public partial class ProfileMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (Data.DBContext context = new Data.DBContext())
            {
                CurrentUser = context.Set<User>()
                    .FirstOrDefault(u => u.UserLogin == Page.User.Identity.Name);
            }
        }

        protected User CurrentUser { get; set; }
    }
}