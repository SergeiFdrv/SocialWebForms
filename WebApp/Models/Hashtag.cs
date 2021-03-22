using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Hashtag
    {
        public int HashtagID { get; set; }

        [Required]
        [MaxLength(255)]
        public string TagName { get; set; }

        public string Slug => Data.DBContext.GenerateSlug(TagName);

        //[Required]
        //[MaxLength(255)]
        //public string TagSlug { get; set; }

        public virtual ICollection<PostTagPair> TagPostPairs { get; set; }
    }
}