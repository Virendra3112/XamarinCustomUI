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


        public Command OnLongPressedCommand { get; set; }

        public Command ImageClickedCommand { get; set; }

        public CustomGalleryView()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {

            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            GalleryList = new ObservableCollection<GalleryModel>();

            ImageClickedCommand = new Command(OnImageClicked);
            OnLongPressedCommand = new Command(OnLongPressed);

            GetData();
        }

        private void GetData()
        {
            IsLongPressed = false;
            IsImageChecked = false;
            GalleryList.Add(new GalleryModel { ImageId = 1, ImageUrl = "icon", IsDeleted = false, IsSelected = false });
            GalleryList.Add(new GalleryModel { ImageId = 2, ImageUrl = "icon", IsDeleted = false, IsSelected = false });
            GalleryList.Add(new GalleryModel { ImageId = 3, ImageUrl = "icon", IsDeleted = false, IsSelected = false });
            GalleryList.Add(new GalleryModel { ImageId = 4, ImageUrl = "icon", IsDeleted = false, IsSelected = false });
            GalleryList.Add(new GalleryModel { ImageId = 5, ImageUrl = "icon", IsDeleted = false, IsSelected = false });
            GalleryList.Add(new GalleryModel { ImageId = 6, ImageUrl = "icon", IsDeleted = false, IsSelected = false });
            GalleryList.Add(new GalleryModel { ImageId = 7, ImageUrl = "icon", IsDeleted = false, IsSelected = false });

        }

        private void OnLongPressed(object obj)
        {
            IsLongPressed = true;
            IsImageChecked = false;

        }

        private void OnImageClicked(object obj)
        {
            IsLongPressed = false;
            IsImageChecked = true;
        }

        private void Close_Tapped(object sender, EventArgs e)
        {

        }

        private void Delete_Tapped(object sender, EventArgs e)
        {

        }
    }
}