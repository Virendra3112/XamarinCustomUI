
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinCustomUI.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccordianView : Frame
    {
        private Thickness DefaultMargin { get; set; }
        public static readonly BindableProperty IsHeaderBarVisibleProperty = BindableProperty.Create(nameof(IsHeaderBarVisible), returnType: typeof(bool), declaringType: typeof(bool), defaultValue: true);
        public bool IsHeaderBarVisible
        {
            get
            {
                return (bool)GetValue(IsHeaderBarVisibleProperty);
            }
            set
            {
                SetValue(IsHeaderBarVisibleProperty, value);
            }
        }

        public AccordianView()
        {
            InitializeComponent();

            ToggleCommand = new Command(OnToggleCommand);
            IsExpanded = true;
            DefaultMargin = self.Padding;
        }

        public double HeaderHeight
        {
            get
            {
                return gridHeader.HeightRequest;
            }
            set
            {
                gridHeader.HeightRequest = value;
            }
        }

        public Color HeaderBackgroundColor
        {
            get
            {
                return gridHeader.BackgroundColor;
            }
            set
            {
                gridHeader.BackgroundColor = value;
            }
        }

        public View HeaderContent
        {
            get
            {
                return cvHeaderContent.Content;
            }
            set
            {
                cvHeaderContent.Content = value;
            }
        }

        public View BodyContent
        {
            get
            {
                return cvBodyContent.Content;
            }
            set
            {
                cvBodyContent.Content = value;
            }
        }

        public static readonly BindableProperty ToggleCommandProperty = BindableProperty.Create(nameof(ToggleCommand), returnType: typeof(Command), declaringType: typeof(Command), defaultValue: null);
        public Command ToggleCommand
        {
            get
            {
                return (Command)GetValue(ToggleCommandProperty);
            }
            set
            {
                SetValue(ToggleCommandProperty, value);
            }
        }

        public bool IsExpanded
        {
            get
            {
                return cvBodyContent.IsVisible;
            }
            set
            {
                cvBodyContent.IsVisible = value;
                btnToggle.Rotation = value ? 180 : 0;
            }
        }

        private void OnToggleCommand()
        {
            IsExpanded = !IsExpanded;
            if (IsExpanded)
            {
                self.Padding = DefaultMargin;
                self.CornerRadius = 10;
            }
            else
            {
                self.Padding = new Thickness(15, 15, 10, 10);
                self.CornerRadius = 25;
            }
        }
    }
}