using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinCustomUI.Helpers;
using XamarinCustomUI.Models;

namespace XamarinCustomUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MultipleImagePicker : ContentPage
    {
        IMultiMediaPickerService _multiMediaPickerService;

        public ObservableCollection<MediaFile> Media { get; set; }
        public ICommand SelectImagesCommand { get; set; }
        public ICommand SelectVideosCommand { get; set; }
        public MultipleImagePicker()
        {
            InitializeComponent();

            _multiMediaPickerService = DependencyService.Get<IMultiMediaPickerService>();//.PickPhotosAsync();

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var hasPermission = await CheckPermissionsAsync();
            if (hasPermission)
            {
                Media = new ObservableCollection<MediaFile>();

                await _multiMediaPickerService.PickPhotosAsync();

                _multiMediaPickerService.OnMediaPicked += (s, a) =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Media.Add(a);

                    });
                };
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var hasPermission = await CheckPermissionsAsync();
            if (hasPermission)
            {
                await _multiMediaPickerService.PickVideosAsync();
            }
        }

        async Task<bool> CheckPermissionsAsync()
        {
            var retVal = false;
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Plugin.Permissions.Abstractions.Permission.Storage))
                    {
                        await App.Current.MainPage.DisplayAlert("Alert", "Need Storage permission to access to your photos.", "Ok");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Storage });
                    status = results[Plugin.Permissions.Abstractions.Permission.Storage];
                }

                if (status == PermissionStatus.Granted)
                {
                    retVal = true;

                }
                else if (status != PermissionStatus.Unknown)
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "Permission Denied. Can not continue, try again.", "Ok");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                await App.Current.MainPage.DisplayAlert("Alert", "Error. Can not continue, try again.", "Ok");
            }

            return retVal;

        }
    }
}