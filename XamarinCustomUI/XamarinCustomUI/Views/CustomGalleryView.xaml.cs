using System.Collections.ObjectModel;
using System.ComponentModel;

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

        public CustomGalleryView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            GalleryList = new ObservableCollection<GalleryModel>();
        }
    }
}