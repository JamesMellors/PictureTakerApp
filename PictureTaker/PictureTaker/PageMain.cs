using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PictureTaker
{
	public class PageMain : ContentPage
	{
		public PageMain()
		{
            Padding = new Thickness(
               20,
               Device.OnPlatform(40, 20, 0),
               10,
               20);

            var theButton = new Button
            {
                Text = "Take Pic"
            };

            theButton.Clicked += (sender, e) =>
            {
                // Take the picture
                IPictureTaker pictureTaker = DependencyService.Get<IPictureTaker>();
                pictureTaker.TakePic();
            };

            var theImage = new Image
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            MessagingCenter.Subscribe<IPictureTaker, string>(this, "pictureTaken", (sender, arg) =>
            {
                theImage.Source = ImageSource.FromFile(arg);
            });

            Content = new StackLayout
            {
                Spacing = 10,
                Children = { theButton, theImage }
            };
        }
	}
}