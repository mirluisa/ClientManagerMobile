﻿namespace ClientManagerMobile.Services;

public interface IDialogService
{
    Task ShowAlertAsync(string title, string message, string cancel);
}