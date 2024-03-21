using SQLite;
using System.Collections.Generic;
using System.Linq;
using System;
namespace TravelApp
{
	public class DatabaseService
	{
       static SQLiteAsyncConnection db;
       private readonly string dbPath;


        public DatabaseService(string dbPath)
        {
            this.dbPath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");
        }

        public static async Task Init()
        {
            try
            {
                if (db != null)
                    return;

                var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");
               
                db = new SQLiteAsyncConnection(databasePath);
                await db.CreateTableAsync<InfoData>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception during database initialization: {ex.Message}");
            }
        }

        

        public static async Task AddInfoData(InfoData infoData)
        {
            await Init();

            try
            {
                await db.InsertAsync(infoData);
                Console.WriteLine("InfoData added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        public static async Task DeleteAllEntitiesAsync()
        {
            try
            {
                await Init();
                await db.DeleteAllAsync<InfoData>();
                Console.WriteLine("All entities deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception during deletion of all entities: {ex.Message}");
            }
        }


        public static async Task<List<InfoData>> GetInfoDataByCountryAsync(string country)
        {
            try
            {
                if (db == null)
                    await Init();
                return await db.Table<InfoData>().ToListAsync();

               // return await db.Table<InfoData>().Where(info => info.Country == country).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception during database query: {ex.Message}");
                return new List<InfoData>(); // Zwróć pustą listę w przypadku błędu
            }
        }


        public static async Task<IEnumerable<InfoData>> GetInfoData()
        {
            await Init();
            var infoData = await db.Table<InfoData>().ToListAsync();
            return infoData;
        }
    }
}

