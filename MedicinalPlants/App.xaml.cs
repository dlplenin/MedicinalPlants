using MedicinalPlants.Repository;

namespace MedicinalPlants;

public partial class App : Application
{
    private static PlantDatabase _database;

    // Create the _database connection as a singleton.
    public static PlantDatabase Database => _database ??= new PlantDatabase();

    public App()
	{
		InitializeComponent();

#pragma warning disable S125 // Sections of code should not be commented out
        //MainPage = new AppShell();
#pragma warning restore S125 // Sections of code should not be commented out
        MainPage = new NavigationPage(new SplashScreen());
    }
}
