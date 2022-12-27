using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using MedicinalPlants.DTOs;
using MedicinalPlants.Models;
using MedicinalPlants.Views;

namespace MedicinalPlants.ViewModels
{
    public class PlantViewModel : BaseViewModel
    {
        private PlantDto _selectedItem;


        public ObservableCollection<PlantDto> Items { get; }
        public Command LoadItemsCommand { get; }
        //public Command AddItemCommand { get; }
        public Command<PlantDto> ItemTapped { get; }
        
        public PlantViewModel()
        {
            Title = "Plantas";
            Items = new ObservableCollection<PlantDto>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            
            ItemTapped = new Command<PlantDto>(OnItemSelected);

            //AddItemCommand = new Command(OnAddItem);
        }

        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                var assembly = typeof(Plant).GetTypeInfo().Assembly;
                var imagesOfPlants = assembly.GetManifestResourceNames()
                    .Where(imagePath => imagePath.Contains("PicturesOfPlants"))
                    .ToList();

                var defaultImageToShow = ImageSource.FromFile("no_image_available.png");

                Items.Clear();
                var recordsInDataBase = await App.Database.GetItemsAsync();

                foreach (var record in recordsInDataBase)
                {
                    var imageToShow = imagesOfPlants.Any(image => image.Contains(record.ImagePath)) ? ImageSource.FromResource($"MedicinalPlants.PicturesOfPlants.{record.ImagePath}") : defaultImageToShow;

                    var plantToAdd = new PlantDto
                    {
                        Id = record.Id,
                        CommonNames = record.CommonNames,
                        ImageSource = imageToShow,
                        Name = record.Name,
                        ScientificNames = record.ScientificNames,
                        Uses = record.Uses
                    };

                    Items.Add(plantToAdd);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public PlantDto SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        //private async void OnAddItem(object obj)
        //{
        //    await Shell.Current.GoToAsync(nameof(PlantAddPage));
        //}

        async void OnItemSelected(PlantDto item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            var pageToVisit = $"{nameof(PlantDetailPage)}?{nameof(PlantDetailViewModel.ItemId)}={item.Id}";
            await Shell.Current.GoToAsync(pageToVisit);
        }
    }
}