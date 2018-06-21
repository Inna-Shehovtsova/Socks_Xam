using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Socks.DataService;
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Socks
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

			MainPage = new NavigationPage(new Socks.View.StartPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
