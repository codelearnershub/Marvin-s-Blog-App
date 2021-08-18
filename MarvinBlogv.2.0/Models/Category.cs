﻿using System.Collections.Generic;

namespace MarvinBlogv._2._0.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public List<PostCategory> AssociatedPosts { get; set; }
    }
}
