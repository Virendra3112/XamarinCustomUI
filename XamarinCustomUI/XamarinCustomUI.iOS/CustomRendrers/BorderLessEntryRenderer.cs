using CoreAnimation;

using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinCustomUI.Controls;
using XamarinCustomUI.iOS.CustomRendrers;

[assembly: ExportRenderer(typeof(BorderLessEntry), typeof(CustomEntryRenderer))]
namespace XamarinCustomUI.iOS.CustomRendrers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        private CALayer _line;

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            try
            {

                base.OnElementChanged(e);
                _line = null;
                if (Control == null || e.NewElement == null)
                    return;
                Control.Layer.BorderWidth = 0;
                //Control.Layer.BorderWidth = 600;
                Control.BorderStyle = UITextBorderStyle.None;
                _line = new CALayer
                {
                    // BorderColor = UIColor.FromRGB(0, 40, 85).CGColor,
                    //BackgroundColor = UIColor.FromRGB(0, 40, 85).CGColor,
                    //Frame = new CGRect(0, Frame.Height / 2, Frame.Width * 2, 1f)
                    // BorderStyle
                    Frame = new CoreGraphics.CGRect(0, Frame.Height, UIScreen.MainScreen.Bounds.Size.Width, 1f)

                };
                Control.Layer.AddSublayer(_line);
            }
            catch (System.Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
