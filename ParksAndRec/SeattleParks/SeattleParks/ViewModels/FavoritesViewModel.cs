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
    public class FavoritesViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Favorites { get; set; }

        public Command LoadItemsCommand { get; set; }

        public FavoritesViewModel()
        {
            Title = "Favorites";
            Favorites = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<ItemDetailPage, Item>(this, Events.ToggleFavorite, async (obj, item) =>
            {
                var newItem = item as Item;

                var exitingFavorite = await App.Database.GetItemAsync(item.Id);

                if (exitingFavorite != null)
                {
                    await App.Database.DeleteItemAsync(exitingFavorite);

                    Favorites.Remove(item);
                    item.IsFavorite = false;
                }
                else
                {
                    var favorite = new Favorite()
                    {
                        Id = item.Id
                    };

                    await App.Database.AddItemAsync(favorite);
                    Favorites.Add(newItem);
                    item.IsFavorite = true;
                }
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Favorites.Clear();

                List<Favorite> favoriteIds = await App.Database.GetItemsAsync();

                var items = await DataStore.GetItemsAsync(true);

                var favorites = items.Join(favoriteIds, x => x.Id, y => y.Id, (x, y) => x);

                foreach (var favorite in favorites)
                {
                    Favorites.Add(favorite);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}