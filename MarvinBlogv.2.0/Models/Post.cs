using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarvinBlogv._2._0.Models
{
    public class Post : BaseEntity
    {
        [Required, MaxLength(50)]
        public string Title { get; set; }

        [Required, MaxLength(250)]
        public string Content { get; set; }

        [Required, MaxLength(50)]
        public string Description { get; set; }

        public List<Category> Categories { get;set; } 
        public List<Review> Reviews { get; set; }
        public string PostURL { get; set; }
        public User UserId { get; set; }
       
        public bool Status { get; set; }
    }
}
