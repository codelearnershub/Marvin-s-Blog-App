﻿using MarvinBlogv._2._0.Context;
using MarvinBlogv._2._0.Interfaces;
using MarvinBlogv._2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvinBlogv._2._0.Repositories
{
    public class PostCategoryRepository : IPostCategoryRepository
    {
        private readonly BlogDbContext _dbContext;

        public PostCategoryRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PostCategory AddPostCategory(PostCategory postCategory)
        {
            _dbContext.PostCategories.Add(postCategory);
            _dbContext.SaveChanges();
            return postCategory;
        }

        public void Delete(int id)
        {
            var postCategory = FindPostCategory(id);
            {
                if (postCategory != null)
                {
                    _dbContext.PostCategories.Remove(postCategory);
                    _dbContext.SaveChanges();
                }
            }
        }

        public PostCategory FindPostCategory(int id)
        {
            return _dbContext.PostCategories.Find(id);
        }

        public PostCategory UpdatePostCategory(PostCategory postCategory)
        {
            _dbContext.PostCategories.Update(postCategory);
            _dbContext.SaveChanges();
            return postCategory;
        }
    }
}
