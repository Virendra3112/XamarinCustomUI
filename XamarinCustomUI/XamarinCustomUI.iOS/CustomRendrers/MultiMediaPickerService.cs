using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using UIKit;
using XamarinCustomUI.Helpers;
using XamarinCustomUI.Models;

namespace XamarinCustomUI.iOS.CustomRendrers
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