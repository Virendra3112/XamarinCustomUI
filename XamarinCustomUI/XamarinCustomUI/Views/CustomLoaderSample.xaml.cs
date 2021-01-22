using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinCustomUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomLoaderSample : ContentPage
    {
        public CustomLoaderSample()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            previewImage.Source = "https://homepages.cae.wisc.edu/~ece533/images/fruits.png";
        }
    }
}