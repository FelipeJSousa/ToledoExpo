using System;
using System.Collections.Generic;
using System.Threading;
using ToledoExpo.Services.Core.ValueObjects;

namespace ToledoExpo.Services.Core.Interfaces.Services;

public interface INotificationService
{
    void Handle(Notification notification, CancellationToken cancellationToken);

    void NewNotification(string key, string message, NotificationType type);

    IEnumerable<Notification> GetAll();

    void Clear();

    IEnumerable<Notification> GetAllErrors();

    bool HasNotifications();

    bool HasNotificationsErrors();
}