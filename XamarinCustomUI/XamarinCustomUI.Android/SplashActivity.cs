
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;

namespace XamarinCustomUI.Droid
{
    [Activity(Theme = "@style/Theme.Splash",
          MainLauncher = true
         )]
    public class SplashActivity : Activity
    {
        //protected override void OnCreate(Bundle savedInstanceState)
        //{
        //    RequestWindowFeature(WindowFeatures.NoTitle);
        //    base.OnCreate(savedInstanceState);
        //    SetContentView(Resource.Layout.SplashLayout);
        //    if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
        //    {
        //        this.Window.SetFlags(WindowManagerFlags.LayoutNoLimits, WindowManagerFlags.LayoutNoLimits);
        //    }
        //}

        //protected override void OnResume()
        //{
        //    base.OnResume();
        //    Task startupWork = new Task(SimulateStartup);
        //    startupWork.Start();
        //}

        //private async void SimulateStartup()
        //{
        //    await Task.Delay(1000);
        //    StartActivityForResult(new Intent(this, typeof(MainActivity)), 0);
        //}

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            StartActivity(typeof(MainActivity));
        }
    }
}