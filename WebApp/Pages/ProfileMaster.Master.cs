using System;
using System.Linq;
using System.Web.UI;
using WebApp.DataClassLibrary;
using WebApp.DataClassLibrary.Models;

namespace WebApp.Pages
{
    public partial class ProfileMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (DBContext context = new DBContext())
            {
                CurrentUser = context.Set<User>()
                    .FirstOrDefault(u => u.UserLogin == Page.User.Identity.Name);
            }
        }

        protected User CurrentUser { get; set; }
    }
}