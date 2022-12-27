using MedicinalPlants.ViewModels;

namespace MedicinalPlants.Views;

public partial class PlantDetailPage : ContentPage
{
	public PlantDetailPage()
	{
		InitializeComponent();
        BindingContext = new PlantDetailViewModel();
    }
}