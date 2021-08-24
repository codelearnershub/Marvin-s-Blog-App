using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvinBlogv._2._0.Models.ViewModel
{
    public class ReviewViewModel
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public DateTime? PublishedOn { get; set; }
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public int CreatedById { get; set; }
        public int? Reaction { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }
        public string Comment { get; set; }
    }

    public class UpdateReviewViewModel 
    {
       
    }
}
