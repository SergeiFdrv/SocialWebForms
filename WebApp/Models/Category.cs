using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Required]
        [MaxLength(50)]
        // Unique
        public string CategoryName { get; set; }

        [Required]
        [MaxLength(50)]
        // Unique
        public string CategorySlug { get; set; }

        //[Required]
        public string CategoryDescription { get; set; }

        public Category CategoryParent { get; set; }

        public virtual ICollection<Category> ChildCategories { get; set; }
    }
}