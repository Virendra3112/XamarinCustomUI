using Xamarin.Forms;
using XamarinCustomUI.Controls;
using XamarinCustomUI.Droid.CustomRenderers;
using XamarinCustomUI.Resources;

[assembly: Dependency(typeof(ThemeHelper))]
namespace XamarinCustomUI.Droid.CustomRenderers
{
    public class ThemeHelper : IAppTheme
    {
        public void SetAppTheme(Theme theme)
        {
            if (theme == Theme.Dark)
            {
                if (App.AppTheme == Theme.Dark)
                    return;
                App.Current.Resources = new DarkTheme();
            }
            else
            {
                if (App.AppTheme != Theme.Dark)
                    return;
                App.Current.Resources = new LightTheme();
            }
            App.AppTheme = theme;
        }
    }
}