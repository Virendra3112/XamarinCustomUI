using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinCustomUI.Models;

namespace XamarinCustomUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomGalleryView : ContentPage, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


            
        private ObservableCollection<GalleryModel> _galleryList;

        public ObservableCollection<GalleryModel> GalleryList
        {
            get { return _galleryList; }
            set { _galleryList = value; NotifyPropertyChanged(); }
        }

        private bool _isLongPressed;
        public bool IsLongPressed
        {
            get
            {
                return _isLongPressed;
            }
            set
            {
                _isLongPressed = value;
                NotifyPropertyChanged();
            }
        }

        private bool _isImageChecked;
        public bool IsImageChecked
        {
            get
            {
                return _isImageChecked;
            }
            set
            {
                _isImageChecked = value;
                NotifyPropertyChanged();
            }
        }


        public ICommand OnLongPressedCommand { get; set; }

        public ICommand ImageClickedCommand { get; set; }

        public CustomGalleryView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            GalleryList = new ObservableCollection<GalleryModel>();

            ImageClickedCommand = new Command(OnImageClicked);
            OnLongPressedCommand = new Command(OnLongPressed);

        }

        private void OnLongPressed(object obj)
        {
            //throw new NotImplementedException();
        }

        private void OnImageClicked(object obj)
        {
            //throw new NotImplementedException();
        }
    }
}