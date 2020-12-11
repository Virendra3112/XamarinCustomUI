using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinCustomUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectLanguage : ContentPage
    {
        public SelectLanguage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if(langPicker.SelectedItem!=null)
            {
                var language = CultureInfo.GetCultures(CultureTypes.NeutralCultures).ToList().First(es => es.EnglishName.Contains(langPicker.SelectedItem.ToString()));
                Thread.CurrentThread.CurrentCulture = language;

            }
        }
    }
}