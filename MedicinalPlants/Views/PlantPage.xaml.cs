using MedicinalPlants.ViewModels;

namespace MedicinalPlants.Views;

public partial class PlantPage : ContentPage
{
    private readonly PlantViewModel _viewModel;

    public PlantPage()
	{
		InitializeComponent();
        BindingContext = _viewModel = new PlantViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.OnAppearing();
    }
}
