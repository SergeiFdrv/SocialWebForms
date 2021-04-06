using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.DataClassLibrary;
using WebApp.DataClassLibrary.Models;

namespace WebApp.Pages
{
    public partial class Article : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (DBContext context = new DBContext())
            {
                if (User != null)
                {
                    CurrentUser = context.Set<User>()
                        .FirstOrDefault(u => u.UserLogin == User.Identity.Name);
                }
                int postID = Convert.ToInt32(RouteData.Values["id"]?.ToString());
                string slug = RouteData.Values["title"]?.ToString();
                var posts = context.Posts
                    .Include(p => p.PostAuthor)
                    .Include(p => p.Comments).AsEnumerable();
                Post = posts.FirstOrDefault(
                    p => p.PostID == postID || p.Slug == slug);
                if (Post.PostCategoryID.HasValue)
                {
                    Category = Categories.GetCategory(Post.PostCategoryID.Value);
                    int categoryID = Category.CategoryID;
                    CategoryPostTiles.Posts = CategoryPosts =
                        posts.Where(p =>
                        p.PostCategoryID == categoryID && p.PostID != postID)
                        .ToList();
                }
                PostCommentSection.Comments = PostComments = Post.Comments;
                UserPostTiles.Posts = UserPosts = Post.PostAuthor?.Posts
                    .Where(p => p.PostID != postID);
            }
        }

        protected User CurrentUser { get; set; }

        protected Post Post { get; set; }

        protected Category Category { get; set; }

        protected IEnumerable<Comment> PostComments { get; set; }

        protected IEnumerable<Post> UserPosts { get; set; }

        protected IEnumerable<Post> CategoryPosts { get; set; }

        protected void CommentSubmit_Click(object sender, EventArgs e)
        {
            using (DBContext context = new DBContext())
            {
                Comment comment = new Comment
                {
                    CommentAuthor = CurrentUser,
                    CommentPost = Post,
                    CommentContent = Request.Form["ckeditor0"],
                    CommentEditedUTC = DateTime.UtcNow
                };
                context.Update(comment);
                try
                {
                    context.SaveChanges();
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException x)
                {
                    if (!x.InnerException.Message.Contains("Content")) throw x;
                    return;
                }
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}