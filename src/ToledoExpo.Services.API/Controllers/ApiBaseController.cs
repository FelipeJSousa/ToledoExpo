using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToledoExpo.Services.API.ViewModels;
using ToledoExpo.Services.Core.Interfaces.Services;
using ToledoExpo.Services.Core.ValueObjects;

namespace ToledoExpo.Services.API.Controllers;

public abstract class ApiBaseController : ControllerBase
{
    private readonly IMapper _Mapper;
    protected readonly INotificationService Notifications;
    
    protected ApiBaseController(IServiceProvider serviceProvider)
    {
        _Mapper = serviceProvider.GetService<IMapper>();
        Notifications = serviceProvider.GetService<INotificationService>();
    }

    #region Mapper

    protected TDestination Mapear<TDestination>(object origem)
    {
        return _Mapper.Map<TDestination>(origem);
    }

    protected TDestination Merge<TDestination>(TDestination destino, object origem)
    {
        return _Mapper.Map(origem, destino);
    }

    protected TDestination MergeInto<TDestination>(TDestination destino, object origem)
    {
        return _Mapper.Map(origem, Mapear<TDestination>(destino));
    }

    #endregion

    #region Notification

    protected void NewNotification(string key, string message, NotificationType notificationType = NotificationType.Error)
    {
        Notifications.NewNotification(key, message, notificationType);
    }

    protected bool HasNotificationsErrors()
    {
        return Notifications.HasNotificationsErrors();
    }

    #endregion
    
    protected new IActionResult Response<T>(IEnumerable<T> obj) where T : class
    {
        return obj?.Any() == true
            ? Ok(new ApiResponse<IEnumerable<T>>(obj))
            : NoContent();
    }

    protected new IActionResult Response<T>(T obj) where T : class
    {
        return obj is not null ? Ok(new ApiResponse<T>(obj)) : NoContent();
    }

    protected IActionResult ResponseError(ApiResponseError obj)
    {
        return obj is not null ? Ok(new ApiResponse(obj)) : NoContent();
    }
}