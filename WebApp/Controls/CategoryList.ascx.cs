using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using WebApp.Models;

namespace WebApp.Controls
{
    public partial class CategoryList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e) { }

        public List<Category> Categories { get; set; } = Data.Categories.All.ToList();
    }
}