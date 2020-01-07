using Library.API.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Business.Notifications
{
    public class Notifier : INotifier
    {
        public Notifier()
        {
            _notifications = new List<Notification>();
        }
        private List<Notification> _notifications { get; set; }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }
        public void Dispose()
        {
            _notifications = new List<Notification>();
        }
    }
}
