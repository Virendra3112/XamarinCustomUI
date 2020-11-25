using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Item SelectedItem = CategoryList.FirstOrDefault(itm => itm.Name == ((TappedEventArgs)e).Parameter.ToString());

            if (SelectedItem != null)
            {
                switch (SelectedItem.Name)
                {

                    case "Label":
                        {

                            break;
                        }

                    case "Entry":
                        {

                            break;
                        }

                    default:
                        break;



                }
            }

        }
    }


    public class Item
    {
        public string Name { get; set; }

        public string Image { get; set; }

    }
}
