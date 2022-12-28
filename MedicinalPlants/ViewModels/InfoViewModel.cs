using System.Windows.Input;

namespace MedicinalPlants.ViewModels
{
    public class InfoViewModel : BaseViewModel
    {
        public InfoViewModel()
        {
            Title = "Info";
        }

        public ICommand TapLinkCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
    }
}
