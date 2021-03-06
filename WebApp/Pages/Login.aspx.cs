using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;

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

        /// <summary>
        /// An alternative user authentication method
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="persistentCookie"></param>
        /// <returns></returns>
        /*private void Authenticate(string login, string password, bool persistentCookie = true)
        {
            FormsAuthenticationTicket tkt;
            string cookiestr;
            HttpCookie ck;
            tkt = new FormsAuthenticationTicket(1, login, DateTime.Now,
            DateTime.Now.AddMinutes(30), persistentCookie, "your custom data");
            cookiestr = FormsAuthentication.Encrypt(tkt);
            ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
            if (persistentCookie)
            {
                ck.Expires = tkt.Expiration;
            }
            ck.Path = FormsAuthentication.FormsCookiePath;
            Response.Cookies.Add(ck);
            string strRedirect;
            strRedirect = Request["ReturnUrl"];
            if (strRedirect == null)
            {
                strRedirect = "default.aspx";
            }
            Response.Redirect(strRedirect, true);
        }*/

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
                var response = HTTPClient.Instance
                    .GetAsync("api/user/getpasswordhash?login=" + userlogin.Value).Result;
                lookupPassword = response.Content.ReadAsStringAsync().Result;
                if (!response.IsSuccessStatusCode) return false;
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
            if (ValidateUser(userlogin.Value, userpassword.Value))
            {
                FormsAuthentication.SetAuthCookie(userlogin.Value, chkPersistCookie.Checked);
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