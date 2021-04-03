using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    /// <summary>
    /// Manage user authentication
    /// </summary>
    public class UserController : ApiController
    {
        // https://localhost:44397/api/user/login?login=serg&password=admin&persistentcookie=true
        [HttpGet]
        public string Login(string login, string password, bool persistentCookie = true)
        {
            if (ValidateUser(login, password))
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
                //return Authenticate(login, persistentCookie);
                return "OK";
            }
            return "Validation failed";
        }

        private static bool ValidateUser(string userName, string passWord, bool hashPassword = false)
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

        [HttpPost]
        public void SignUp(User user)
        {
            using (var context = new DBContext())
            {
                //user.UserPass = BCrypt.Net.BCrypt.HashPassword(user.UserPass);
                context.Add(user);
                try
                {
                    context.SaveChanges();
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                {
                    throw;
                }
            };
        }

        [HttpPatch, HttpGet]
        public string Authenticate(string login, bool persistentCookie = true)
        {
            System.Diagnostics.Trace.WriteLine(User);
            FormsAuthentication.SetAuthCookie(login, persistentCookie);
            if (User.Identity.IsAuthenticated)
            {
                using (DBContext context = new DBContext())
                {
                    User user = context.Set<User>().First(u => u.UserLogin == login);
                    user.UserLastLoginUTC = DateTime.UtcNow;
                    context.Set<User>().Update(user);
                    context.SaveChanges();
                }
                return "OK";
            }
            return "Authentication failed";
        }

        [HttpGet]
        private static bool Authenticate(User user, bool persistentCookie = true)
        {
            FormsAuthentication.SetAuthCookie(user.UserLogin, persistentCookie);
            using (DBContext context = new DBContext())
            {
                user.UserLastLoginUTC = DateTime.UtcNow;
                context.Set<User>().Update(user);
                context.SaveChanges();
            }
            return true;
        }

        // GET api/user
        public IEnumerable<User> Get()
        {
            List<User> res;
            using (DBContext context = new DBContext())
            {
                res = context.Set<User>().ToList();
            }
            return res;
        }

        // GET api/user/5
        public User Get(int id)
        {
            using (DBContext context = new DBContext())
            {
                return context.Set<User>().FirstOrDefault(u => u.UserID == id);
            }
        }

        // POST api/user
        public void Post([FromBody] string value)
        {
        }

        // PUT api/user/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/user/5
        public void Delete(int id)
        {
        }
    }
}