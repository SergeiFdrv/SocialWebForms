using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.DataClassLibrary.Models
{
    public class User
    {
        public int UserID { get; set; }

        [Required]
        [MaxLength(50)]
        // Unique
        public string UserLogin { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        public string Slug => DBContext.GenerateSlug(UserName);

        //[Required]
        //[MaxLength(50)]
        // Unique
        //public string UserSlug { get; set; }

        [Required]
        public string UserPass { get; set; }

        [Required]
        public string UserRole { get; set; } = "user";

        [Required]
        [MaxLength(50)]
        [EmailAddress]
        // Unique
        public string UserEMail { get; set; }

        [Url]
        public string UserWebsite { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime UserRegisteredUTC { get; set; } = DateTime.UtcNow;

        public DateTime UserLastLoginUTC { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}