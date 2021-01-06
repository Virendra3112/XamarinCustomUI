using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FFImageLoading.Svg.Forms;
using Xamarin.Forms;

namespace XamarinCustomUI.Controls
{
    public class CustomCachedImage_SVG : SvgCachedImage
    {
        public static readonly BindableProperty ImageColorProperty =
            BindableProperty.Create("ImageColor", typeof(Color), typeof(CustomCachedImage_SVG), Application.Current.Resources["secondaryColor"]);

        public Color ImageColor
        {
            get { return (Color)GetValue(ImageColorProperty); }
            set { SetValue(ImageColorProperty, value); }
        }

        public CustomCachedImage_SVG()
        {
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == "ImageColor")
            {
                SetColor();
            }
        }

        private void SetColor()
        {
            //Dictionary<string, string> imageStringMap = new Dictionary<string, string>()
            //{
            //    {
            //       AppConstants.CustomSvgCachedImage.DefaultFillColor,
            //       string.Format(AppConstants.CustomSvgCachedImage.FillColor, ImageColor.ToHex())
            //    }
            //};

            //ReplaceStringMap = imageStringMap;
            //Source = Source;
        }
    }
}

