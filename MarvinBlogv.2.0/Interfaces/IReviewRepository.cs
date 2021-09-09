using MarvinBlogv._2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvinBlogv._2._0.Interfaces
{
    public interface IReviewRepository
    {
        public Review AddReview(Review review);
        public Review AddComment(Review review);
        public Review FindReviewer(int reviewerId);
        public Review FindReviewById(int? id);
        public Review UpdateReview(Review review);
        public void Delete(int id);
        public List<Review> FindByPostId(int PostId);
        public List<Review> FindByUserId(int userId);
        public int ReviewCount(int postId);
        public int LikeCount(int userId);
    }
}
