using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SeattleParks.Data;
using SeattleParks.Models;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(SeattleParks.Services.MockDataStore))]
namespace SeattleParks.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            var favorites = new HashSet<int>((await App.Database.GetItemsAsync()).Select(x => x.Id));

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MockDataStore)).Assembly;
            var stream = assembly.GetManifestResourceStream("SeattleParks.Parks.json");
            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }

            var parks = JsonConvert.DeserializeObject<ICollection<ParkDto>>(text);

            items = parks.Select(x => new Item
            {
                Id = x.Id,
                Url = x.Url ?? string.Empty,
                Text = x.Title ?? string.Empty,
                Address = x.Address ?? string.Empty,
                Description = x.About ?? string.Empty,
                MainImage = x.MainImage ?? string.Empty,
                AmenitiesList = x.Amenities.Aggregate(string.Empty, (seed, next) => seed += Constants.FeatureIcons[next]),
                GalleryImages = x.GalleryImages.ToList(),
                Lat = x.Lat,
                Long = x.Long,
                IsFavorite = favorites.Contains(x.Id)
            }).ToList();

            return items;
        }
    }
}