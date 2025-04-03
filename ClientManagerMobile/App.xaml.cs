using ClientManagerMobile.Views;

namespace ClientManagerMobile;

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }
    }