using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinCustomUI
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private ObservableCollection<Item> _categoryList;

        public ObservableCollection<Item> CategoryList
        {
            get { return _categoryList; }
            set { _categoryList = value; NotifyPropertyChanged(); }
        }
        public MainPage()
        {
            InitializeComponent();

           

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            CategoryList = new ObservableCollection<Item>();

            CategoryList.Add(new Item { Name = "Label", Image = "icon.png" });

            CategoryList.Add(new Item { Name = "Entry", Image = "icon.png" });

            CategoryList.Add(new Item { Name = "Test", Image = "icon.png" });
           
            //lstView.ItemsSource = CategoryList;
           // flexlayout.bi
        }

        
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    public class Item
    {
        public string Name { get; set; }

        public string Image { get; set; }

    }
}
