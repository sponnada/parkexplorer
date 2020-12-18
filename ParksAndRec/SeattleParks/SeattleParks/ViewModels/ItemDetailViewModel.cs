using SeattleParks.Data;
using SeattleParks.Models;
using SeattleParks.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SeattleParks.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }

        Color favoriteButtonColor = Color.White;
        public Color FavoriteButtonColor { 
            get { return favoriteButtonColor; }
            set { SetProperty(ref favoriteButtonColor, value); } 
        }

        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
            FavoriteButtonColor = item.IsFavorite ? Color.Red : Color.White;

            MessagingCenter.Subscribe<ItemDetailPage, Item>(this, Events.ToggleFavorite, async (obj, i) =>
            {
                var newItem = i as Item;

                var exitingFavorite = await App.Database.GetItemAsync(i.Id);

                if (exitingFavorite != null)
                {
                    FavoriteButtonColor = Color.White;
                }
                else
                {
                    FavoriteButtonColor = Color.Red;
                }
            });
        }
    }
}
