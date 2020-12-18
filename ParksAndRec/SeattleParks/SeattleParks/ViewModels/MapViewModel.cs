using SeattleParks.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SeattleParks.ViewModels
{
    public class MapViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Parks { get; set; }

        public Command LoadParksCommand { get; set; }

        public MapViewModel()
        {
            Title = "Map";
            Parks = new ObservableCollection<Item>();
            LoadParksCommand = new Command(async () => await ExecuteLoadParksCommand());
        }

        async Task ExecuteLoadParksCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Parks.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Parks.Add(item);
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
