using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.DataClassLibrary.Models;

namespace WebApp.Controls
{
    public partial class CommentSection : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e) { }

        public IEnumerable<Comment> Comments { get; set; }
    }
}