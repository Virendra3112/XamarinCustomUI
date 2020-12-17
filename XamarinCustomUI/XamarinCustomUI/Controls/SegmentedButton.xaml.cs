using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinCustomUI.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SegmentedButton : ContentView
    {
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), returnType: typeof(Color), declaringType: typeof(Color), defaultValue: Color.Black);
        public Color TextColor
        {
            get
            {
                return (Color)GetValue(TextColorProperty);
            }
            set
            {
                SetValue(TextColorProperty, value);
            }
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), returnType: typeof(string), declaringType: typeof(string), defaultValue: string.Empty);
        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), returnType: typeof(ImageSource), declaringType: typeof(ImageSource), defaultValue: null);
        public ImageSource Icon
        {
            get
            {
                return (ImageSource)GetValue(IconProperty);
            }
            set
            {
                SetValue(IconProperty, value);
            }
        }

        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), returnType: typeof(string), declaringType: typeof(string), defaultValue: string.Empty);
        public string FontFamily
        {
            get
            {
                return (string)GetValue(FontFamilyProperty);
            }
            set
            {
                SetValue(FontFamilyProperty, value);
            }
        }

        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), returnType: typeof(double), declaringType: typeof(double), defaultValue: 16.0);
        public double FontSize
        {
            get
            {
                return (double)GetValue(FontSizeProperty);
            }
            set
            {
                SetValue(FontSizeProperty, value);
            }
        }

        public static readonly BindableProperty FontAttributesProperty = BindableProperty.Create(nameof(FontAttributes), returnType: typeof(FontAttributes), declaringType: typeof(FontAttributes), defaultValue: FontAttributes.None);
        public FontAttributes FontAttributes
        {
            get
            {
                return (FontAttributes)GetValue(FontAttributesProperty);
            }
            set
            {
                SetValue(FontAttributesProperty, value);
            }
        }

        public event EventHandler Clicked;

        public SegmentedButton()
        {
            InitializeComponent();
            this.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    this.Clicked?.Invoke(this, EventArgs.Empty);
                })
            });
        }
    }
}