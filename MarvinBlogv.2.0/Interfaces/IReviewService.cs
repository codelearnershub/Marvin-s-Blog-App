﻿using MarvinBlogv._2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvinBlogv._2._0.Interfaces
{
    public interface IReviewService
    {
        public Review AddReview(int userId, bool reaction, int postId);
        public Review FindReviewer(int reviewerId);
        public Review FindReviewById(int? id);
        public Review UpdateReview(int id, DateTime reviewedOn, int userId, bool reaction, int postId, string comment);
        public void Delete(int id);
        public int ReviewCount(int userId);
        public List<Review> FindByPostId(int PostId);
        //public int LikeCount(int postId);
    }
}
