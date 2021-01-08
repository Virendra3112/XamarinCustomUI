using System;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V4.Content;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinCustomUI.Controls;
using XamarinCustomUI.Droid.CustomRenderers;

[assembly: ExportRenderer(typeof(CustomDatePickerControl), typeof(CustomDatePickerRenderer))]
namespace XamarinCustomUI.Droid.CustomRenderers
{
    public class CustomDatePickerRenderer : DatePickerRenderer
    {
        CustomDatePickerControl element;
        public CustomDatePickerRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.DatePicker> e)
        {
            base.OnElementChanged(e);
            element = (CustomDatePickerControl)this.Element;

            if (Control != null && element != null)
            {
                Control.Background = AddPickerStyles();

                Control.SetPadding(0, 0, 0, 0);

                if (element.Date.Date == DateTime.Now.Date)
                    Control.Text = "";
            }
        }

        public LayerDrawable AddPickerStyles()
        {
            Drawable[] layers = { GetDrawable() };
            LayerDrawable layerDrawable = new LayerDrawable(layers);
            return layerDrawable;
        }

        private BitmapDrawable GetDrawable()
        {
            int resID = Resources.GetIdentifier("calendar", "drawable", this.Context.PackageName);
            var drawable = ContextCompat.GetDrawable(this.Context, resID);
            var bitmap = ((BitmapDrawable)drawable).Bitmap;
            var result = new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(bitmap, 20, 20, true));
            result.Gravity = Android.Views.GravityFlags.Right;
            return result;
        }
    }
}
