using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;
using System.Linq;
using SeattleParks.ViewModels;
using Xamarin.Forms.Xaml;

namespace SeattleParks.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        MapViewModel viewModel;

        public MapPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MapViewModel();
        }

        private void UpdatePins()
        {
            MyMap.Pins.Clear();

            foreach (var park in viewModel.Parks)
            {
                var pin = new Pin()
                {
                    Position = new Position(park.Lat, park.Long),
                    Label = park.Text,
                    Address = park.Address,
                };

                pin.Clicked += async (sender, e) =>
                {
                    await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(park)));

                };

                MyMap.Pins.Add(pin);
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Parks.Count == 0)
            {
                viewModel.LoadParksCommand.Execute(null);

                var locator = await Geolocation.GetLocationAsync(new GeolocationRequest());

                MyMap.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                        new Position(locator.Latitude, locator.Longitude), Distance.FromMiles(5)));

                UpdatePins();
            };
        }
    }
}
