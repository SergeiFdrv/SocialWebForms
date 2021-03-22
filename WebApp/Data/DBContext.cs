using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Text;
using WebApp.Models;

namespace WebApp.Data
{
    public class DBContext : DbContext
    {
        public DBContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        //public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Hashtag> Hashtags { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostTagPair> PostTagPairs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* #region Category
            // index
            modelBuilder.Entity<Category>()
                .HasIndex(c => c.CategoryName).IsUnique();
            modelBuilder.Entity<Category>()
                .HasIndex(c => c.CategorySlug).IsUnique();
            // one-to-many
            modelBuilder.Entity<Category>().HasOne(c => c.CategoryParent).WithMany();
            #endregion*/
            #region Comment
            // one-to-many
            modelBuilder.Entity<Comment>().HasOne(c => c.CommentPost)
                .WithMany(p => p.Comments).HasForeignKey(c => c.CommentPostID);
            modelBuilder.Entity<Comment>().HasOne(c => c.CommentAuthor)
                .WithMany(u => u.Comments).HasForeignKey(c => c.CommentAuthorID);
            modelBuilder.Entity<Comment>().HasOne(c => c.CommentParent)
                .WithMany(c => c.ChildComments).HasForeignKey(c => c.CommentParentID);
            #endregion
            #region Hashtag
            // many-to-many
            modelBuilder.Entity<Hashtag>().HasMany(h => h.TagPostPairs)
                .WithOne(pair => pair.Hashtag).HasForeignKey(pair => pair.HashtagID);
            #endregion
            #region PostTagPair
            // index
            modelBuilder.Entity<PostTagPair>()
                .HasIndex(pair => pair.PostTagPairID).IsUnique();
            #endregion
            #region Post
            // index
            modelBuilder.Entity<Post>()
                .HasIndex(p => new { p.PostID, p.PostTitle }).IsUnique();
            // one-to-many
            modelBuilder.Entity<Post>().HasOne(p => p.PostAuthor)
                .WithMany(u => u.Posts).HasForeignKey(p => p.PostAuthorID);
            //modelBuilder.Entity<Post>().HasOne(p => p.PostCategory).WithMany();
            // many-to-many
            modelBuilder.Entity<Post>().HasMany(p => p.PostTagPairs)
                .WithOne(pair => pair.Post).HasForeignKey(pair => pair.PostID);
            #endregion
            #region User
            // index
            modelBuilder.Entity<User>().HasIndex(u => u.UserLogin).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.UserEMail).IsUnique();
            #endregion
        }

        public static string GenerateSlug(string name)
        {
            StringBuilder res = new StringBuilder(name.Length);
            foreach (char c in name)
            {
                if (char.IsLetterOrDigit(c)) res.Append(char.ToLower(c));
                else if (char.IsWhiteSpace(c)) res.Append('_');
                else if (c == '-' || c == '_') res.Append(c);
            }
            return res.ToString();
        }
    }
}