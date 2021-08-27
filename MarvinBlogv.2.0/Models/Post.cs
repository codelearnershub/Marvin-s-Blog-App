﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarvinBlogv._2._0.Models
{
    public class Post : BaseEntity
    {
        [Required, MaxLength(250)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required, MaxLength(250)]
        public string Description { get; set; }

        public string FeaturedImageURL { get; set; }

        public string ImageURL { get;set; } 

        public List<Review> Reviews { get; set; }

        public string PostURL { get; set; }

        public User User{ get; set; }

        public int UserId { get; set; } 
        
        public bool Status { get; set; }

        public ICollection<PostCategory> PostCategories { get; set; } = new HashSet<PostCategory>();

    }
}
