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
        [HttpGet]
        public IHttpActionResult GetPasswordHash(string login)
        {
            string lookupPassword;
            using (DBContext context = new DBContext())
            {
                try
                {
                    lookupPassword =
                        context.Users.First(u => u.UserLogin == login).UserPass;
                }
                catch (InvalidOperationException)
                {
                    return NotFound();
                }
            }
            return ResponseMessage(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(lookupPassword)
            });
        }

        [HttpPost]
        public void SignUp(User user)
        {
            using (var context = new DBContext())
            {
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