﻿using System;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                ErrorMessage.InnerText = Resources.Language.LoginFailedYouDoNotExist;
            }
        }

        private bool ValidateUser(string userName, string passWord)
        {
            string lookupPassword = null;

            // Check for invalid userName.
            // userName must not be null and must be between 1 and 15 characters.
            if (string.IsNullOrWhiteSpace(userName)/* || (userName.Length > 15)*/)
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of userName failed.");
                return false;
            }

            // Check for invalid passWord.
            // passWord must not be null and must be between 1 and 25 characters.
            if (string.IsNullOrWhiteSpace(passWord)/* || (passWord.Length > 25)*/)
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of passWord failed.");
                return false;
            }

            try
            {
                using (DBContext context = new DBContext())
                {
                    lookupPassword =
                        context.Set<User>().First(u => u.UserLogin == userName).UserPass;
                }
            }
            catch (Exception ex)
            {
                // Add error handling here for debugging.
                // This error message should not be sent back to the caller.
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Exception " + ex.Message);
            }

            // If no password found, return false.
            if (null == lookupPassword)
            {
                // You could write failed login attempts here to event log for additional security.
                return false;
            }

            // Compare lookupPassword and input passWord, using a case-sensitive comparison.
            return string.Equals(lookupPassword, passWord, StringComparison.Ordinal)
                || BCrypt.Net.BCrypt.Verify(passWord, lookupPassword); // TODO: delete this line
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            //HTTPClient.Instance.BaseAddress =
            //    new Uri(Page.Request.Url.Scheme + "://" + Page.Request.Url.Authority);
            var response = HTTPClient.Instance
                .GetAsync("api/user/login?login=" + userlogin.Value
                + "&password=" + /*BCrypt.Net.BCrypt.HashPassword(*/userpassword.Value/*)*/
                + "&persistentcookie=" + chkPersistCookie.Checked.ToString()).Result;
            if (response.IsSuccessStatusCode &&
                response.Content.ReadAsStringAsync().Result == "\"OK\"")
            //if (ValidateUser(userlogin.Value, userpassword.Value))
            {
                /*
                FormsAuthenticationTicket tkt;
                string cookiestr;
                HttpCookie ck;
                tkt = new FormsAuthenticationTicket(1, txtUserName.Value, DateTime.Now,
                DateTime.Now.AddMinutes(30), chkPersistCookie.Checked, "your custom data");
                cookiestr = FormsAuthentication.Encrypt(tkt);
                ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                if (chkPersistCookie.Checked)
                    ck.Expires=tkt.Expiration;
                ck.Path = FormsAuthentication.FormsCookiePath;
                Response.Cookies.Add(ck);

                string strRedirect;
                strRedirect = Request["ReturnUrl"];
                if (strRedirect==null)
                    strRedirect = "default.aspx";
                Response.Redirect(strRedirect, true);
                */
                // FormsAuthentication.Authenticate(userlogin.Value, chkPersistCookie.Checked);
                /*response = HTTPClient.Instance
                    .GetAsync($"api/user/authenticate?login=" + userlogin.Value
                    + "&persistentcookie=" + chkPersistCookie.Checked)
                    .Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("bad status code: " + response.StatusCode);
                }
                if (response.Content.ReadAsStringAsync().Result != "\"OK\"")
                {
                    throw new Exception("not OK");
                }
                */
                FormsAuthentication.SetAuthCookie(userlogin.Value, chkPersistCookie.Checked);
                using (DBContext context = new DBContext())
                {
                    User user = context.Set<User>().First(u => u.UserLogin == userlogin.Value);
                    user.UserLastLoginUTC = DateTime.UtcNow;
                    context.Set<User>().Update(user);
                    context.SaveChanges();
                }
                string returnURL = Page.Request.Params["ReturnUrl"];
                if (!string.IsNullOrWhiteSpace(returnURL))
                {
                    Response.Redirect(returnURL);
                }
                else Response.Redirect("/");
            }
        }
    }
}