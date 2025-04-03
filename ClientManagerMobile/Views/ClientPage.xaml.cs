using ClientManagerMobile.ViewModels;

namespace ClientManagerMobile.Views;

public partial class ClientPage : ContentPage
{
    public ClientPage(ClientViewModel clientViewModel)
    {
        InitializeComponent();
        BindingContext = clientViewModel;
    }
}