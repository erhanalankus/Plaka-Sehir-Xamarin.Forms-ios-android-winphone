using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace PlakaSehir
{
    public class DetailPage : ContentPage
    {
        public DetailPage(City selectedCity)
        {
            View advertisement;
            Label pageHeader;
            Label listViewSubHeader;
            ListView listView;
            Image image;

            CreateUI(out advertisement, selectedCity, out pageHeader, out listViewSubHeader, out listView, out image);

            listView.ItemTapped += (sender, args) =>
            {
                DisplayAlert("Cevap", ((Trivia)args.Item).Answer, "Tamam");
            };

            Content = new StackLayout
            {
                Children = {
                    advertisement,
                    pageHeader,
                    image,
                    listViewSubHeader,
                    listView
                }
            };
        }

        private void CreateUI(out View advertisement, City selectedCity, out Label pageHeader, out Label listViewSubHeader, out ListView listView, out Image image)
        {
            advertisement = new AdControl
            {
                VerticalOptions = LayoutOptions.Start
            };
            pageHeader = new Label
            {
                Text = selectedCity.Plate + " " + selectedCity.Name,
                FontAttributes = FontAttributes.Bold,
                FontSize = 30,
                HorizontalOptions = LayoutOptions.Center
            };
            image = new Image
            {
                Source = Device.OnPlatform(
                    iOS: ImageSource.FromFile("Sehirler/" + selectedCity.PictureAddress),
                    Android: ImageSource.FromFile(selectedCity.PictureAddress),
                    WinPhone: ImageSource.FromFile("Sehirler/" + selectedCity.PictureAddress)
                    ),                
                HorizontalOptions = LayoutOptions.Center
            };
            listViewSubHeader = new Label
            {
                Text="(Cevabı görmek için soruya dokun)",
                FontSize = 15,
                Opacity = 0.4,
                HorizontalOptions = LayoutOptions.Center
            };
            listView = new ListView
            {
                ItemsSource = selectedCity.TriviaList
            };
        }
    }
}
