using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Security;
using System.Web.UI;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitUserData()
        {
            if (userpassword.Value != userpasswordconfirm.Value) return;
            User user = new User
            {
                UserLogin = userlogin.Value,
                UserName = username.Value,
                UserPass = BCrypt.Net.BCrypt.HashPassword(userpassword.Value),
                UserEMail = useremail.Value
            };
            HTTPClient.Instance.BaseAddress =
                new Uri(Page.Request.Url.Scheme + "://" + Page.Request.Url.Authority);
            HttpResponseMessage message = HTTPClient.Instance
                .PostAsXmlAsync("api/user/signup", user).Result;
            message.EnsureSuccessStatusCode();
            /*
            using (var context = new DBContext())
            {
                User user = new User
                {
                    UserLogin = userlogin.Value,
                    UserName = username.Value,
                    UserPass = BCrypt.Net.BCrypt.HashPassword(userpassword.Value),
                    UserEMail = useremail.Value
                };
                context.Add(user);
                try
                {
                    context.SaveChanges();
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
                {
                    if (e.InnerException.Message.Contains("Login"))
                    {
                        userlogin.Value = string.Empty;
                    }
                    else if (e.InnerException.Message.Contains("EMail"))
                    {
                        useremail.Value = string.Empty;
                    }
                    else throw e;
                    return;
                }
            };*/
            FormsAuthentication.SetAuthCookie(userlogin.Value, true);
            string returnURL = Page.Request.Params["ReturnUrl"];
            if (!string.IsNullOrWhiteSpace(returnURL))
            {
                Response.Redirect(returnURL);
            }
            else Response.Redirect("/");
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            SubmitUserData();
        }
    }
}