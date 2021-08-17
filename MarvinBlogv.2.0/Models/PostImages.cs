using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvinBlogv._2._0.Models
{
    public class PostImages : BaseEntity
    {
        public string ImageURL { get; set; }
        public Post PostId { get; set; }
    }
}
