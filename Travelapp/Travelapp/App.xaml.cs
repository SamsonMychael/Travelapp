using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Travelapp
{
    public partial class App : Application
    {
        public static string Databaselocation = string.Empty;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public  App(string databasepath)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            Databaselocation = databasepath;
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
