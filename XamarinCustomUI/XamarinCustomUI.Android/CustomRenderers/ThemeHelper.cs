using Xamarin.Forms;
using XamarinCustomUI.Controls;
using XamarinCustomUI.Droid.CustomRenderers;

[assembly: Dependency(typeof(ThemeHelper))]
namespace XamarinCustomUI.Droid.CustomRenderers
{
    public class ThemeHelper : IAppTheme
    {
        public void SetAppTheme(Theme theme)
        {
            throw new System.NotImplementedException();
        }
    }
}