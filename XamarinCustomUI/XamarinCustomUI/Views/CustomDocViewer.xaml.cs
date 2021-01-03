
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinCustomUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomDocViewer : ContentPage
    {
        public CustomDocViewer()
        {
            InitializeComponent();

            //add url here
            var docurl = "";
            webView.Source = new UrlWebViewSource() { Url =  docurl };

        }

        protected override async void OnAppearing()
        {           
            base.OnAppearing();
            await progressBar.ProgressTo(0.9, 900, Easing.SpringIn);
        }

        void webviewNavigating(object sender, WebNavigatingEventArgs e)
        {
            progressBar.IsVisible = true;
        }

        void webviewNavigated(object sender, WebNavigatedEventArgs e)
        {
            progressBar.IsVisible = false;
        }
    }
}