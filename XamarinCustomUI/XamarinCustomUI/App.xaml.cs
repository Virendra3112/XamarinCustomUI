using System;
using System.Globalization;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinCustomUI
{
    public partial class App : Application
    {
        public static Theme AppTheme { get; set; }

        public App()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InstalledUICulture;

            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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

    public enum Theme
    {
        Light,
        Dark
    }
}
