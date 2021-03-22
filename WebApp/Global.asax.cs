using System;
using System.Web.Routing;

namespace WebApp
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        protected void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("category-posts", "category/{category}", "~/Pages/Branch.aspx");
            routes.MapPageRoute("user-login", "login", "~/Pages/Login.aspx");
            routes.MapPageRoute("user-register", "register", "~/Pages/Register.aspx");
            routes.MapPageRoute("user-profile", "profile", "~/Pages/Profile.aspx");
            routes.MapPageRoute("user-settings", "profile/settings", "~/Pages/ProfileSettings.aspx");
            routes.MapPageRoute("user-writepost", "profile/writepost", "~/Pages/PostEditor.aspx");
            routes.MapPageRoute("user-editpost", "profile/writepost/{id}", "~/Pages/PostEditor.aspx");
            routes.MapPageRoute("search-page", "search", "~/Pages/Search.aspx");
            routes.MapPageRoute("post-id", "post/{id}", "~/Pages/Article.aspx");
            routes.MapPageRoute("post-id-title", "post/{id}/{title}", "~/Pages/Article.aspx");
            routes.MapPageRoute("error", "error/{id}", "~/Pages/Error.aspx");
        }
    }
}