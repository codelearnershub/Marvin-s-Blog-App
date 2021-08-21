using MarvinBlogv._2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvinBlogv._2._0.Interfaces
{
    public interface IPostImageService
    {
        public PostImages AddPostImage(int id, DateTime createdAt, string imageURL, int postId);
        public void DeletePostImage(int id);
        public PostImages FindPostImage(int? id);
        public PostImages UpdatePostImage(int id, DateTime createdAt, string imageURL, int postId);
    }
}
