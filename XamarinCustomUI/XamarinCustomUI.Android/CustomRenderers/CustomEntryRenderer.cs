using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinCustomUI.Controls;
using XamarinCustomUI.Droid.CustomRenderers;

[assembly: ExportRenderer(typeof(BorderLessEntry), typeof(CustomEntryRenderer))]
namespace XamarinCustomUI.Droid.CustomRenderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackgroundColor(Android.Graphics.Color.Argb(0, 0, 0, 0));
            }
        }
    }
}