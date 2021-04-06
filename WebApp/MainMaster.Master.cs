using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.DataClassLibrary;
using WebApp.DataClassLibrary.Models;

namespace WebApp
{
    public partial class MainMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (DBContext context = new DBContext())
            {
                string lookupLogin = HttpContext.Current.User?.Identity.Name;
                if (!string.IsNullOrEmpty(lookupLogin))
                {
                    CurrentUser = context.Set<User>()
                        .First(u => u.UserLogin == lookupLogin);
                    CurrentUser.UserLastLoginUTC = DateTime.UtcNow;
                    context.Update(CurrentUser);
                    context.SaveChanges();
                }
            }
        }

        public static List<T> GetEntity<T>(string sortBy = "") where T : class
        {
            using (DBContext context = new DBContext())
            {
                var list = context.Set<T>();
                if (string.IsNullOrWhiteSpace(sortBy))
                {
                    return list.ToList();
                }
                return list.SortBy(sortBy).ToList();
            }
        }

        public List<Category> Categories { get; }
            // = GetEntity<Category>("CategoryName")
            //.Where(c => c.CategoryParent is null).ToList();
            = DataClassLibrary.Categories.All.ToList();

        public User CurrentUser { get; private set; }

        protected void LogOutButton_Click(object sender, EventArgs e)
        {
            SignOut();
        }

        protected void SignOut()
        {
            FormsAuthentication.SignOut();
            Page.Response.Redirect(Page.Request.RawUrl);
        }
    }
}