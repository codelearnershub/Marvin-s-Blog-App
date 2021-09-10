using MarvinBlogv._2._0.Interfaces;
using MarvinBlogv._2._0.Models;
using System;
using System.Collections.Generic;
using MarvinBlogv._2._0.Context;
using MarvinBlogv._2._0.DTO;

namespace MarvinBlogv._2._0.Services
{
    public class NotificationRepository : INotificationRepository
    {
    private readonly BlogDbContext _dbContext;
    
    public NotificationRepository(BlogDbContext dbContext)
    {
    _dbContext = dbContext;
    }
        public Notification AddNotification(Notification notification)
        {
            _dbContext.Add(notification);
            _dbContext.SaveChanges();
            return notification;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Notification Update(Notification notification)
        {
            throw new NotImplementedException();
        }

        public Notification FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Notification> GetUserNotificationByUserId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}