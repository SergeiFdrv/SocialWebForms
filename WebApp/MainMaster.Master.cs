using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Data;
using WebApp.Models;

namespace WebApp
{
    public partial class MainMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (DBContext context = new DBContext())
            {
                string lookupLogin = HttpContext.Current.User?.Identity.Name;
                CurrentUser
                    = context.Set<User>().FirstOrDefault(u => u.UserLogin == lookupLogin);
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
            = Data.Categories.All.ToList();

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