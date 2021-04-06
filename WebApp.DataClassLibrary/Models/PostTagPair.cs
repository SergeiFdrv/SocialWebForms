using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.DataClassLibrary.Models
{
    /// <summary>
    /// This POCO is designed to form a many-to-many relationship
    /// </summary>
    public class PostTagPair
    {
        public int PostTagPairID { get; set; }

        public int PostID { get; set; }

        [ForeignKey("PostID")]
        public Post Post { get; set; }

        public int HashtagID { get; set; }

        [ForeignKey("HashtagID")]
        public Hashtag Hashtag { get; set; }
    }
}