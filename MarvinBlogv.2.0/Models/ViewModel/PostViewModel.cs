﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarvinBlogv._2._0.Models.ViewModel
{
    public class PostViewModel
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public DateTime? PublishedOn { get; set; }
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public List<PostCategory> Categories { get; set; }
        public List<Review> Reviews { get; set; }
        public string PostURL { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public bool Status { get; set; }
    }

    public class CreatePostViewModel 
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public DateTime? PublishedOn { get; set; }
        public int Id { get; set; }
        public string CreatedBy { get; set; }

        [Required(ErrorMessage = "Post Title is required")]
        [Display(Name = "Title:")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Post Content is required")]
        [Display(Name = "Content:")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Descibe more about your post here")]
        public string Description { get; set; }
        public string FeaturedImageURL { get; set; }
        public string PostURL { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
        public int UseId { get; set; }

        [Required(ErrorMessage = "Select at least one Category")]
        public string[] Categories { get; set; }
        public IEnumerable<SelectListItem> CategorySelectListItem { get; set; }

    }

    public class UpdatePostViewModel
    {
        [Required(ErrorMessage = "Post Title required")]
        [Display(Name = "Title:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Post Content required")]
        [Display(Name = "Content:")]
        public string Content { get; set; }
        public string Description { get; set; }
    }
}
