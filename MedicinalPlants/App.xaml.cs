namespace MedicinalPlants;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

#pragma warning disable S125 // Sections of code should not be commented out
        //MainPage = new AppShell();
#pragma warning restore S125 // Sections of code should not be commented out
        MainPage = new NavigationPage(new SplashScreen());
    }
}
