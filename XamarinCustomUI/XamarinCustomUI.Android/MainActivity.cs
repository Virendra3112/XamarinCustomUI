
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android;

namespace XamarinCustomUI.Droid
{
    [Activity(Label = "XamarinCustomUI", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);
            Xamarin.FormsMaps.Init(this, savedInstanceState);

            LoadApplication(new App());
        }


        const int RequestLocationId = 0;
        readonly string[] AppPermission =
        {
            Manifest.Permission.WriteExternalStorage
        };

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        }

        protected override void OnStart()
        {
            base.OnStart();

            if ((int)Build.VERSION.SdkInt >= 23)
            {
                if (CheckSelfPermission(Manifest.Permission.WriteExternalStorage) != Permission.Granted)
                {
                    RequestPermissions(AppPermission, 0);
                }
                else
                {
                    // Permissions already granted - display a message.
                }
            }

        }
    }
}