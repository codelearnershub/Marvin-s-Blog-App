using MarvinBlogv._2._0.Interfaces;
using MarvinBlogv._2._0.Models;
using System;

namespace MarvinBlogv._2._0.Services
{
    public class FollowerService : IFollowerService
    {
        private readonly IUserService _userService;
        private readonly IFollowerRepository _followerRepository;

        public FollowerService(IUserService userService, IFollowerRepository followerRepository)
        {
            _userService = userService;
            _followerRepository = followerRepository;
        }

        public Follower AddFollower(int id, DateTime statedFollowing, int followeId)
        {
            Follower follower = new Follower
            {
                Id = id,
                CreatedAt = DateTime.Now,
                User = _userService.FindUserById(followeId),
            };

            _followerRepository.AddFollower(follower);

            return follower;
        }

        public void Unfollow(int id)
        {
            _followerRepository.Unfollow(id);
        }
    }
}
