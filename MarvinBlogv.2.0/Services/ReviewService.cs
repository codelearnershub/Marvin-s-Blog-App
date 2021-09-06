using MarvinBlogv._2._0.Interfaces;
using MarvinBlogv._2._0.Models;
using System;
using System.Collections.Generic;

namespace MarvinBlogv._2._0.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IUserService _userService;
        private readonly IPostService _postService;

        public ReviewService(IReviewRepository reviewRepository, IUserService userService, IPostService postService)
        {
            _reviewRepository = reviewRepository;
            _userService = userService;
            _postService = postService;
        }

        public Review AddReview(int userId, bool reaction, int postId)
        {
            Review review = new Review
            {
                CreatedAt = DateTime.Now,
                UserId = userId,
                Reaction = reaction,
                PostId = postId,
            };

            _reviewRepository.AddReview(review);

            return review;
        }

        public void Delete(int id)
        {
            _reviewRepository.Delete(id);
        }

        public Review FindReviewById(int? id)
        {
           return _reviewRepository.FindReviewById(id);
        }

        public Review FindReviewer(int reviewerId)
        {
            return _reviewRepository.FindReviewer(reviewerId);
        }

        public Review UpdateReview(int id, DateTime reviewedOn, int userId, bool reaction, int postId, string comment)
        {
            var review = _reviewRepository.FindReviewById(id);

            review.CreatedAt = DateTime.Now;

            review.UserId = userId;

            review.Reaction = reaction;

            review.PostId = postId;

            review.Comment = comment;

            return _reviewRepository.UpdateReview(review);
        }

        public int ReviewCount(int postId)
        {
            return _reviewRepository.ReviewCount(postId);
        }

        public List<Review> FindByPostId(int PostId) 
        {
            return _reviewRepository.FindByPostId(PostId);
        }

        //public int LikeCount(int postId) 
        //{
        //    var reviews = _reviewRepository.FindByPostId(postId);
        //    int sum = 0;

        //    if (reviews.Count == 0)
        //    {
        //        return 0;
        //    }

        //    foreach (var review in reviews)
        //    {
        //        sum += review.Reaction;
        //    }
           
        //    return sum;
        //}
    }
}
