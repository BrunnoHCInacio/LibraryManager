using Library.API.Business.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Business.Interfaces
{
    public interface INotifier : IDisposable
    {
        void Handle(Notification notification);
        bool HasNotification();
        List<Notification> GetNotifications();
    }
}
