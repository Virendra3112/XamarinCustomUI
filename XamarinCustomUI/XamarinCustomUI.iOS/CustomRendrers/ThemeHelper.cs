using System;
using Xamarin.Forms;
using XamarinCustomUI.Controls;
using XamarinCustomUI.iOS.CustomRendrers;

[assembly: Dependency(typeof(ThemeHelper))]
namespace XamarinCustomUI.iOS.CustomRendrers
{
    public class ThemeHelper : IAppTheme
    {
        public void SetAppTheme(Theme theme)
        {
            throw new NotImplementedException();
        }
    }
}