﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var ctxt = new DBContext())
            {
                Tags = ctxt.Hashtags.ToList();
                Posts = ctxt.Posts.Include(p => p.PostAuthor).ToList();
                RecentPostTiles.Posts = Posts;
            }
        }

        public List<Hashtag> Tags { get; set; }

        public List<Post> Posts { get; set; }
    }
}