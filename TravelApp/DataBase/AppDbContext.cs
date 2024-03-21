using System;
namespace TravelApp
{
    public class AppDbContext
    {
        static DatabaseService databaseService;

        public static DatabaseService Database
        {
            get
            {
                if (databaseService == null)
                {
                    string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Databases", "travelapp.db");
                    databaseService = new DatabaseService(dbPath);
                }
                return databaseService;
            }
        }


    }
}

