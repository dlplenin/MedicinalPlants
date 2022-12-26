namespace MedicinalPlants;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("FrederickatheGreat-Regular.ttf", "FrederickatheGreatRegular");
				fonts.AddFont("KaushanScript-Regular.ttf", "KaushanScriptRegular");

			});

		return builder.Build();
	}
}
