using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using XamarinCustomUI.Controls;
using XamarinCustomUI.Views;

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

        private bool setDarkMode;

        public bool SetDarkMode
        {
            get
            {
                return setDarkMode;
            }
            set
            {
                setDarkMode = value;
                NotifyPropertyChanged();

                SetTheme(setDarkMode);
            }
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

            CategoryList.Add(new Item { Name = "Action Bar", Image = "icon.png" });

            CategoryList.Add(new Item { Name = "Charts", Image = "icon.png" });

            CategoryList.Add(new Item { Name = "Map", Image = "icon.png" });

            CategoryList.Add(new Item { Name = "Mulilingual", Image = "icon.png" });

            CategoryList.Add(new Item { Name = "CustomTabs", Image = "icon.png" });

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
                            Navigation.PushAsync(new CustomLabelsPage());

                            break;
                        }

                    case "Entry":
                        {
                            Navigation.PushAsync(new CustomEntryPage());

                            break;
                        }

                    case "Action Bar":
                        {
                            Navigation.PushAsync(new CustomActionBarSample());

                            break;
                        }

                    case "Charts":
                        {
                            Navigation.PushAsync(new SampleChartsPage());

                            break;
                        }

                    case "Map":
                        {
                            Navigation.PushAsync(new GoogleMapSample());

                            break;
                        }

                    case "Mulilingual":
                        {
                            Navigation.PushAsync(new SelectLanguage());

                            break;
                        }

                    case "CustomTabs":
                        {
                            Navigation.PushAsync(new CustomTabsSample());

                            break;
                        }

                    default:
                        break;



                }
            }

        }



        public void SetTheme(bool status)
        {
            Theme themeRequested;
            if (status)
            {
                var backColor = (Color)Application.Current.Resources["DrawerPrimaryColor"];


                themeRequested = Theme.Dark;
            }
            else
            {
                var backColor = (Color)Application.Current.Resources["DrawerPrimaryColor"];


                themeRequested = Theme.Light;
            }

            DependencyService.Get<IAppTheme>().SetAppTheme(themeRequested);
        }
    }


    public class Item
    {
        public string Name { get; set; }

        public string Image { get; set; }

    }
}
