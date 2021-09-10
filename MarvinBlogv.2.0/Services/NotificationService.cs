using MarvinBlogv._2._0.Interfaces;
using MarvinBlogv._2._0.Models;
using System;
using System.Collections.Generic;
using MarvinBlogv._2._0.DTO;

namespace MarvinBlogv._2._0.Services
{
    public class NotificationService : INotificationService
    {
        public Notification AddNotification(CreateNotificationDTO createNotificationDto)
        {
        //     Notification notification = new Notification()
        //     {
        //         Id = createNotificationDto.Id,
        //         CreatedAt = DateTime.Now,
        //         PostId = createNotificationDto.PostId,
        //     };
        //     return;
        throw new NotImplementedException();
        }

        public Notification UpdateNotification(CreateNotificationDTO updateDto)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Notification> GetNotificationByUserId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}