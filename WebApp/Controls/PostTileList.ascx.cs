using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Models;

namespace WebApp.Controls
{
    public partial class PostTileList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e) { }

        public IEnumerable<Post> Posts { get; set; }
    }
}