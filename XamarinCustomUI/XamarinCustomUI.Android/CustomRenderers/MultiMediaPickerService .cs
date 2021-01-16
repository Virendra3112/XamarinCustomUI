using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinCustomUI.Helpers;
using XamarinCustomUI.Models;

namespace XamarinCustomUI.Droid.CustomRenderers
{
    public class MultiMediaPickerService : IMultiMediaPickerService
    {
        public event EventHandler<MediaFile> OnMediaPicked;
        public event EventHandler<IList<MediaFile>> OnMediaPickedCompleted;

        public void Clean()
        {
            throw new NotImplementedException();
        }

        public Task<IList<MediaFile>> PickPhotosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<MediaFile>> PickVideosAsync()
        {
            throw new NotImplementedException();
        }
    }
}