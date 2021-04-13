using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.MVC.Models
{
    public class PostModel
    {
        [Required]
        public string Author { get; set; }

        public int? CategoryID { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}