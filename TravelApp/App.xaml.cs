namespace TravelApp;

public partial class App : Application
{
    private static DatabaseService database;

    public static DatabaseService DatabaseService
    {
        get
        {
            if(database == null)
            {
                database = new DatabaseService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "travel.db3"));
            }

            return database;
        }
    }

	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
        InitializeAppAsync();

    }

    private async void InitializeAppAsync()
    {
        await DatabaseService.Init();
        MainPage = new NavigationPage(new MainPage());
    }



}

