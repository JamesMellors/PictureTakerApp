using System;
using System.Collections.Generic;
using System.Text;
using PictureTaker;
using Xamarin.Forms;
using Xamarin.Media;

[assembly: Dependency(typeof(PictureTaker.iOS.PictureTaker_IOS))]
namespace PictureTaker.iOS
{
    class PictureTaker_IOS : IPictureTaker
    {

        public PictureTaker_IOS()
        {

        }
        public async void TakePic()
        {
            var picker = new MediaPicker();

            var mediaFile = await picker.PickPhotoAsync();
            System.Diagnostics.Debug.WriteLine(mediaFile.Path);

            MessagingCenter.Send<IPictureTaker, string>(this, "pictureTaken", mediaFile.Path);
        }
    }
}
