using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using WebApp.DataClassLibrary.Models;

namespace WebApp.Controls
{
    public partial class CategoryList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e) { }

        public IEnumerable<Category> Categories { get; set; }
            = DataClassLibrary.Categories.All;
    }
}