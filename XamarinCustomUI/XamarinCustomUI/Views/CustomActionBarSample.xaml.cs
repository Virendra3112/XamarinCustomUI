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
    public partial class CustomActionBarSample : ContentPage
    {
        public Command LeftButtonCommand { get; set; }
        public CustomActionBarSample()
        {
            InitializeComponent();

            LeftButtonCommand = new Command(OnLeftButtonTapped);
        }

        private void OnLeftButtonTapped(object obj)
        {
           // throw new NotImplementedException();
        }
    }
}