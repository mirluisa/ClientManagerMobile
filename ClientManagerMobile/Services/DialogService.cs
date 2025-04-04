namespace ClientManagerMobile.Services;

public class DialogService : IDialogService
{
    public Task ShowAlertAsync(string title, string message, string cancel)
    {
        if (Application.Current?.MainPage != null)
            return Application.Current.MainPage.DisplayAlert(title, message, cancel);

        return Task.CompletedTask;
    }
}