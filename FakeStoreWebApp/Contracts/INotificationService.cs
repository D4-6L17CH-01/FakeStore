﻿namespace FakeStoreWebApp.Contracts;

public interface INotificationService
{
    ValueTask StatusNotification(string titulo, string mensaje, string tipo);
    ValueTask<bool> BoolNotification(string titulo, string mensaje);
    ValueTask ErrorNotification(Exception exception);
}

