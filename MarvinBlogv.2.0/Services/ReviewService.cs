using MarvinBlogv._2._0.Interfaces;
using MarvinBlogv._2._0.Models;
using System;

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

        public Review AddReview(int id, DateTime reviewedOn, int userId, int reaction, int postId, string comment)
        {
            Review review = new Review
            {
                Id = id,
                PublishedOn = DateTime.Now,
                User = _userService.FindUserById(userId),
                Reaction = reaction,
                Post = _postService.FindById(postId),
                Comment = comment.ToUpper(),
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

        public Review UpdateReview(int id, DateTime reviewedOn, int userId, int reaction, int postId, string comment)
        {
            var review = _reviewRepository.FindReviewById(id);

            review.CreatedAt = DateTime.Now;

            review.UserId = userId;

            review.Reaction = reaction;

            review.PostId = postId;

            review.Comment = comment.ToUpper();

            return _reviewRepository.UpdateReview(review);
        }
    }
}
