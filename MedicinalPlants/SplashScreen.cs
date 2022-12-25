using Microsoft.Maui.Layouts;

namespace MedicinalPlants
{
    public class SplashScreen : ContentPage
    {
        public SplashScreen()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            var container = new AbsoluteLayout();
            _splashImage = new Image
            {
                Source = ImageSource.FromResource("MedicinalPlants.Resources.Images.growing_grow.png"),
            };
            AbsoluteLayout.SetLayoutFlags(_splashImage, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(_splashImage,
                new Rect(0.5, 1, (int)AbsoluteLayout.AutoSize, (int)AbsoluteLayout.AutoSize));
            container.Children.Add(_splashImage);
            this.Content = container;
        }

        private readonly Image _splashImage;

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _splashImage.ScaleTo(0.8, 1500);
            await _splashImage.ScaleTo(0.2, 1500, Easing.Linear);

            await Task.WhenAll
            (
                _splashImage.ScaleTo(6, 1200, Easing.Linear),
                _splashImage.FadeTo(0, 1150)
            );
            if (Application.Current != null) Application.Current.MainPage = new AppShell();
        }
    }
}
