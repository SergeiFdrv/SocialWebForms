using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.DataClassLibrary.Models
{
    public class Post
    {
        public int PostID { get; set; }

        public int? PostAuthorID { get; set; }

        [ForeignKey("PostAuthorID")]
        public User PostAuthor { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime PostDateUTC { get; set; } = DateTime.UtcNow;

        public DateTime PostEditedUTC { get; set; }

        public int? PostCategoryID { get; set; }
        //public virtual Category PostCategory { get; set; }

        [Required]
        public string PostContent { get; set; }

        [Required]
        public int PostRP { get; set; }

        [Required]
        [MaxLength(255)]
        public string PostTitle { get; set; }

        public string Slug => DBContext.GenerateSlug(PostTitle);

        //[Required]
        //[MaxLength(255)]
        // Unique
        //public string PostSlug { get; set; }

        [EnumDataType(typeof(ApprovementStatus))]
        [Required]
        public ApprovementStatus PostApprovement { get; set; }
            = ApprovementStatus.Awaiting;

        public virtual ICollection<PostTagPair> PostTagPairs { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}