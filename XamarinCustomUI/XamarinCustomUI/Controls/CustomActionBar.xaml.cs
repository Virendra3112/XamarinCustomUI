using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinCustomUI.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomActionBar : ContentView
    {
        #region Title
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), returnType: typeof(string), declaringType: typeof(string), defaultValue: "");

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }

        }
        #endregion

        #region BackgroundImage
        public static readonly BindableProperty BackgroundImageProperty = BindableProperty.Create(nameof(BackgroundImage),
            returnType: typeof(ImageSource), declaringType: typeof(ImageSource), defaultValue: null);


        public ImageSource BackgroundImage
        {

            get { return (ImageSource)GetValue(BackgroundImageProperty); }
            set { SetValue(BackgroundImageProperty, value); }

        }
        #endregion

        #region LeftIcon

        public static readonly BindableProperty LeftIconProperty = BindableProperty.Create(nameof(LeftIcon), returnType: typeof(ImageSource), declaringType: typeof(ImageSource), defaultValue: null);
        public ImageSource LeftIcon
        {

            get { return (ImageSource)GetValue(LeftIconProperty); }
            set { SetValue(LeftIconProperty, value); }

        }

        #endregion


        #region LeftIcon Tapped

        public static readonly BindableProperty LeftTappedCommandProperty = BindableProperty.Create(nameof(LeftTappedCommand),
            returnType: typeof(ICommand), declaringType: typeof(ICommand), defaultValue: null);

        public ICommand LeftTappedCommand
        {

            get { return (ICommand)GetValue(LeftTappedCommandProperty); }
            set { SetValue(LeftTappedCommandProperty, value); }

        }

        #endregion

        #region LeftContentProperty


        public static readonly BindableProperty LeftContentProperty = BindableProperty.Create(nameof(LeftContent), returnType: typeof(View), declaringType: typeof(View), defaultValue: null);

        public View LeftContent
        {

            get { return (View)GetValue(LeftContentProperty); }
            set { SetValue(LeftContentProperty, value); }

        }


        #endregion


        #region Right Content


        #region RightIcon

        public static readonly BindableProperty RightIconProperty = BindableProperty.Create(nameof(RightIcon), returnType: typeof(ImageSource), declaringType: typeof(ImageSource), defaultValue: null);
        public ImageSource RightIcon
        {

            get { return (ImageSource)GetValue(RightIconProperty); }
            set { SetValue(RightIconProperty, value); }

        }

        #endregion


        #region RightIcon Tapped

        public static readonly BindableProperty RightTappedCommandProperty = BindableProperty.Create(nameof(RightTappedCommand), returnType: typeof(Command), declaringType: typeof(Command), defaultValue: null);

        public Command RightTappedCommand
        {

            get { return (Command)GetValue(RightTappedCommandProperty); }
            set { SetValue(RightTappedCommandProperty, value); }

        }

        #endregion



        #region RightContentProperty


        public static readonly BindableProperty RightContentProperty = BindableProperty.Create(nameof(RightContent), returnType: typeof(View), declaringType: typeof(View), defaultValue: null);

        public View RightContent
        {

            get { return (View)GetValue(RightContentProperty); }
            set { SetValue(RightContentProperty, value); }

        }


        #endregion


        #endregion


        public static readonly BindableProperty IsContentVisibleProperty = BindableProperty.Create(nameof(IsContentVisible), returnType: typeof(bool), declaringType: typeof(bool), defaultValue: null);

        public bool IsContentVisible
        {

            get { return (bool)GetValue(IsContentVisibleProperty); }
            set { SetValue(IsContentVisibleProperty, value); }

        }


        private int safeAreaTopInset;

        public int SafeAreaTopInset
        {

            get { return safeAreaTopInset; }
            set
            {
                safeAreaTopInset = value;
                OnPropertyChanged("SafeAreaTopInset");

            }

        }


        public CustomActionBar()
        {
            InitializeComponent();
            this.PropertyChanged += HeaderBar_PropertyChanged;
        }


        private void HeaderBar_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == RightContentProperty.PropertyName)
            {
                RightContent = new Image() { Source = RightIcon };
            }
        }


    }
}
