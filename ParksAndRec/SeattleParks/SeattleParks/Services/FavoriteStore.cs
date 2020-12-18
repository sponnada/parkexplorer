using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using SeattleParks.Models;
using SeattleParks.Services;

namespace SeattleParks.Data
{
    public class FavoriteStore
    {
        readonly SQLiteAsyncConnection database;

        public FavoriteStore(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Favorite>().Wait();
        }

        public Task<List<Favorite>> GetItemsAsync()
        {
            return database.Table<Favorite>().ToListAsync();
        }
        public Task<Favorite> GetItemAsync(int id)
        {
            return database.Table<Favorite>().Where(i => i.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public Task<int> AddItemAsync(Favorite favorite)
        {
            return database.InsertAsync(favorite);
        }

        public Task<int> DeleteItemAsync(Favorite favorite)
        {
            return database.DeleteAsync(favorite);
        }
    }
}