using Microsoft.Extensions.DependencyInjection;
using ClientManagerMobile.ViewModels;

namespace ClientManagerMobile.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnNavigateToClients(object sender, EventArgs e)
    {
        var clientViewModel = MauiProgram.Services.GetRequiredService<ClientViewModel>();
        await Navigation.PushAsync(new ClientPage(clientViewModel));
    }
}