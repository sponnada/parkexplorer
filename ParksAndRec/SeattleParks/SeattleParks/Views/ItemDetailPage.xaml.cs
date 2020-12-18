using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SeattleParks.Models;
using SeattleParks.ViewModels;
using System.Net;
using SeattleParks.Data;
using Plugin.Share;
using Plugin.Share.Abstractions;

namespace SeattleParks.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Item
            {
                Text = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        void ShareClicked(object sender, System.EventArgs e)
        {
            CrossShare.Current.Share(new ShareMessage
            {
                Title = "Seattle Park Explorer",
                Text = viewModel.Item.Text,
                Url = viewModel.Item.Url
            });
        }

        void OnOpenInMapsClicked(object sender, System.EventArgs e)
        {
            var address = this.viewModel.Item.Address;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    Device.OpenUri(
                      new Uri(string.Format("http://maps.apple.com/?q={0}", WebUtility.UrlEncode(address))));
                    break;
                case Device.Android:
                    Device.OpenUri(
                      new Uri(string.Format("geo:0,0?q={0}", WebUtility.UrlEncode(address))));
                    break;
                case Device.UWP:
                    Device.OpenUri(
                      new Uri(string.Format("bingmaps:?where={0}", Uri.EscapeDataString(address))));
                    break;
            }
        }

        private void FavoriteClicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, Events.ToggleFavorite, this.viewModel.Item);
        }
    }
}