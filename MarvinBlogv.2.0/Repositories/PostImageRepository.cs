using MarvinBlogv._2._0.Context;
using MarvinBlogv._2._0.Interfaces;
using MarvinBlogv._2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvinBlogv._2._0.Repositories
{
    public class PostImageRepository : IPostImageRepository
    {
        private readonly BlogDbContext _dbContext;

        public PostImageRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PostImages AddPostImage(PostImages postImages)
        {
            _dbContext.PostImages.Add(postImages);
            _dbContext.SaveChanges();
            return postImages;
        }

        public void DeletePostImage(int id)
        {
            var postImages = FindPostImage(id);
            {
                if (postImages != null)
                {
                    _dbContext.PostImages.Remove(postImages);
                    _dbContext.SaveChanges();
                }
            }
        }

        public PostImages FindPostImage(int? id)
        {
           return _dbContext.PostImages.Find(id);
        }

        public PostImages UpdatePostImage(PostImages postImages)
        {
            _dbContext.PostImages.Update(postImages);
            _dbContext.SaveChanges();
            return postImages;
        }
    }
}
