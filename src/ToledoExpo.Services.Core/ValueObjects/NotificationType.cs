using System.ComponentModel;

namespace ToledoExpo.Services.Core.ValueObjects;

public enum NotificationType
{
    [Description("Error")] Error,

    [Description("Warning")] Warning,

    [Description("Information")] Information
}