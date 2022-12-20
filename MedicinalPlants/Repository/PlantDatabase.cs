using MedicinalPlants.Models;
using SQLite;
using System.Reflection;

namespace MedicinalPlants.Repository
{
    public class PlantDatabase
    {
        private static SQLiteAsyncConnection _database;
        public PlantDatabase()
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Plants.db");

            var assembly = typeof(PlantDatabase).GetTypeInfo().Assembly;

            var embeddedDatabaseStream = assembly.GetManifestResourceStream("MedicinalPlants.Repository.Plants.db");

            if (File.Exists(databasePath))
            {
                File.Delete(databasePath);
            }

            if (!File.Exists(databasePath))
            {
                using var fileStream = new FileStream(databasePath, FileMode.Create);
                embeddedDatabaseStream?.CopyTo(fileStream);
            }

            _database = new SQLiteAsyncConnection(databasePath);
            _database.CreateTableAsync<Plant>().Wait();
        }

        public Task<List<Plant>> GetItemsAsync()
        {
            return _database.Table<Plant>().ToListAsync();
        }

        public Task<Plant> GetItemAsync(int id)
        {
            return _database.Table<Plant>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> AddItemAsync(Plant item)
        {
            return _database.InsertAsync(item);
        }

        public Task<int> UpdateItemAsync(Plant item)
        {
            return _database.UpdateAsync(item);
        }

        public Task<int> DeleteItemAsync(string id)
        {
            return _database.DeleteAsync(id);
        }
    }
}
