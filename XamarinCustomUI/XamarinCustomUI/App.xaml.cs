using System;
using System.Globalization;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinCustomUI.Helpers;

namespace XamarinCustomUI
{
    public partial class App : Application
    {
        public static double ScreenWidth;
        public static double ScreenHeight;
        public static Theme AppTheme { get; set; }

        public App(IMultiMediaPickerService multiMediaPickerService)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InstalledUICulture;

            InitializeComponent();

           // FlowListView.Init();

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
