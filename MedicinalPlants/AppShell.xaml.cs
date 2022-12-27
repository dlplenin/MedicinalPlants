using MedicinalPlants.Views;

namespace MedicinalPlants;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(PlantDetailPage), typeof(PlantDetailPage));
    }
}
