using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinCustomUI.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SegmentedButtonGroup : Frame
    {
        public static readonly BindableProperty SegmentedButtonsProperty = BindableProperty.Create(nameof(SegmentedButtons), returnType: typeof(SegmentedButtonCollection), declaringType: typeof(SegmentedButtonCollection), defaultValue: new SegmentedButtonCollection());
        public SegmentedButtonCollection SegmentedButtons
        {
            get
            {
                return (SegmentedButtonCollection)GetValue(SegmentedButtonsProperty);
            }
            set
            {
                SetValue(SegmentedButtonsProperty, value);
            }
        }

        public static readonly BindableProperty SelectedIndexProperty = BindableProperty.Create(nameof(SelectedIndex), returnType: typeof(int), declaringType: typeof(int), defaultValue: -1);
        public int SelectedIndex
        {
            get
            {
                return (int)GetValue(SelectedIndexProperty);
            }
            set
            {
                if (value == SelectedIndex)
                    return;

                if (value > SegmentedButtons.Count)
                    SetValue(SelectedIndexProperty, -1);
                else
                    SetValue(SelectedIndexProperty, value);
            }
        }

        public static readonly BindableProperty ActiveIconProperty = BindableProperty.Create(nameof(ActiveIcon), returnType: typeof(ImageSource), declaringType: typeof(ImageSource), defaultValue: null);
        public ImageSource ActiveIcon
        {
            get
            {
                return (ImageSource)GetValue(ActiveIconProperty);
            }
            set
            {
                SetValue(ActiveIconProperty, value);
            }
        }

        public static readonly BindableProperty ActiveTextColorProperty = BindableProperty.Create(nameof(ActiveTextColor), returnType: typeof(Color), declaringType: typeof(Color), defaultValue: Color.FromHex("3541FF"));
        public Color ActiveTextColor
        {
            get
            {
                return (Color)GetValue(ActiveTextColorProperty);
            }
            set
            {
                SetValue(ActiveTextColorProperty, value);
            }
        }

        public static readonly BindableProperty InactiveIconProperty = BindableProperty.Create(nameof(InactiveIcon), returnType: typeof(ImageSource), declaringType: typeof(ImageSource), defaultValue: null);
        public ImageSource InactiveIcon
        {
            get
            {
                return (ImageSource)GetValue(InactiveIconProperty);
            }
            set
            {
                SetValue(InactiveIconProperty, value);
            }
        }

        public static readonly BindableProperty InactiveTextColorProperty = BindableProperty.Create(nameof(InactiveTextColor), returnType: typeof(Color), declaringType: typeof(Color), defaultValue: Color.FromHex("9BA5B0"));
        public Color InactiveTextColor
        {
            get
            {
                return (Color)GetValue(InactiveTextColorProperty);
            }
            set
            {
                SetValue(InactiveTextColorProperty, value);
            }
        }

        public static readonly BindableProperty DividerColorProperty = BindableProperty.Create(nameof(DividerColor), returnType: typeof(Color), declaringType: typeof(Color), defaultValue: Color.FromHex("F2F6FD"));
        public Color DividerColor
        {
            get
            {
                return (Color)GetValue(DividerColorProperty);
            }
            set
            {
                SetValue(DividerColorProperty, value);
            }
        }

        public SegmentedButtonGroup()
        {
            InitializeComponent();
            this.PropertyChanged += SegmentedButtonGroup_PropertyChanged;

            RenderControl();
        }

        private void SegmentedButtonGroup_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == SegmentedButtonsProperty.PropertyName ||
                e.PropertyName == ActiveIconProperty.PropertyName ||
                e.PropertyName == ActiveTextColorProperty.PropertyName ||
                e.PropertyName == InactiveIconProperty.PropertyName ||
                e.PropertyName == InactiveTextColorProperty.PropertyName)
            {
                RenderControl();
            }
            else if (e.PropertyName == SelectedIndexProperty.PropertyName)
            {
                SetActiveButton(SelectedIndex);
            }
        }

        private void RenderControl()
        {
            if (SegmentedButtons == null)
                return;

            slContainer.Children.Clear();
            foreach (var item in SegmentedButtons)
            {
                item.HorizontalOptions = LayoutOptions.FillAndExpand;
                item.VerticalOptions = LayoutOptions.FillAndExpand;
                item.Clicked += (sender, e) => SetActiveButton(sender as SegmentedButton);
                slContainer.Children.Add(item);
                slContainer.Children.Add(CreateVerticalDivider());
            }

            if (slContainer.Children.Count > 1)
            {
                slContainer.Children.RemoveAt(slContainer.Children.Count - 1);
                SetActiveButton(0);
            }
        }

        private void SetActiveButton(SegmentedButton activeButton)
        {
            if (SegmentedButtons == null)
                return;
            foreach (var item in SegmentedButtons)
            {
                if (item == activeButton)
                {
                    item.TextColor = ActiveTextColor;
                    item.Icon = ActiveIcon;
                    this.SelectedIndex = SegmentedButtons.ToList().IndexOf(activeButton);
                }
                else
                {
                    item.TextColor = InactiveTextColor;
                    item.Icon = InactiveIcon;
                }
            }
        }

        private BoxView CreateVerticalDivider()
        {
            return new BoxView()
            {
                BackgroundColor = DividerColor,
                WidthRequest = 1
            };
        }

        private void SetActiveButton(int index)
        {
            if (index < 0 || index > SegmentedButtons.Count - 1)
            {
                SetActiveButton(null);
                return;
            }
            else
            {
                var activeButton = SegmentedButtons.ToList().ElementAt(index);
                SetActiveButton(activeButton);
            }

        }
    }
}