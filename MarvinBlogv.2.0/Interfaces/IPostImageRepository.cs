using MarvinBlogv._2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvinBlogv._2._0.Interfaces
{
    public interface IPostImageRepository
    {
        public PostImages AddPostImage(PostImages postImages);
        public void DeletePostImage(int id);
        public PostImages FindPostImage(int? id);
        public PostImages UpdatePostImage(PostImages postImages);
    }
}
