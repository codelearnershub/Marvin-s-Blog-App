using MarvinBlogv._2._0.Interfaces;
using MarvinBlogv._2._0.Models;
using System;
using System.Collections.Generic;
using MarvinBlogv._2._0.DTO;

namespace MarvinBlogv._2._0.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
           _notificationRepository = notificationRepository;
        }

        public Notification AddNotification(CreateNotificationDTO createNotificationDto)
        {
            Notification notification = new Notification()
            {
                Id = createNotificationDto.Id,
                CreatedAt = DateTime.Now,
                PostId = createNotificationDto.PostId,
                Message = createNotificationDto.Message,
                CreatedBy = createNotificationDto.CreatedBy
            };
            return _notificationRepository.AddNotification(notification);
            
        }

        public Notification UpdateNotification(CreateNotificationDTO updateDto)
        {
            var notification = _notificationRepository.FindById(updateDto.Id);

            updateDto.Message = notification.Message;

            updateDto.CreatedAt = notification.CreatedAt;

            updateDto.CreatedBy = notification.CreatedBy;

            return notification;
        }

        public void Delete(int id)
        {
            _notificationRepository.Delete(id);
        }

        public IEnumerable<Notification> GetNotificationByUserId(int userId)
        {
            return _notificationRepository.GetUserNotificationByUserId(userId);
        }
    }
}