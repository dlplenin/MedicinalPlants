using System.Reflection;

namespace MedicinalPlants.Utils
{
    public class PictureUtil
    {
        public static ImageSource GetImageSource<T>(string imagePath)
        {
            var assembly = typeof(T).GetTypeInfo().Assembly;
            var imagesOfPlants = assembly.GetManifestResourceNames()
                .Where(image => image.Contains("PicturesOfPlants"))
                .ToList();

            var defaultImageToShow = ImageSource.FromFile("no_image_available.png");

            return imagesOfPlants.Any(image => image.Contains(imagePath)) ? ImageSource.FromResource($"MedicinalPlants.PicturesOfPlants.{imagePath}") : defaultImageToShow;
        }
    }
}
