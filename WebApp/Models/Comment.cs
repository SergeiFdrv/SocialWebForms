using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class Comment
    {
        public int CommentID { get; set; }

        public int CommentPostID { get; set; }

        [Required]
        [ForeignKey("CommentPostID")]
        public Post CommentPost { get; set; }

        public int? CommentAuthorID { get; set; }

        [ForeignKey("CommentAuthorID")]
        public User CommentAuthor { get; set; }

        [Required]
        public string CommentContent { get; set; }

        [Required]
        public int CommentRP { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CommentPostedUTC { get; set; } = DateTime.UtcNow;

        public DateTime CommentEditedUTC { get; set; }

        public int? CommentParentID { get; set; }

        [ForeignKey("CommentParentID")]
        public Comment CommentParent { get; set; }

        [EnumDataType(typeof(Data.ApprovementStatus))]
        [Required]
        public Data.ApprovementStatus CommentApprovement { get; set; }
            = Data.ApprovementStatus.Awaiting;

        public virtual ICollection<Comment> ChildComments { get; set; }
    }
}