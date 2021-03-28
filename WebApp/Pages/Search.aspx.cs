using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Data;

namespace WebApp.Pages
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SearchSubmit_Click(object sender, EventArgs e)
        {
            using (DBContext context = new DBContext())
            {
                RelevantPosts.Posts = context.Posts
                    .Where(p => p.PostTitle.Contains(SearchBoxInput.Text)).ToList();
            }
        }
    }
}