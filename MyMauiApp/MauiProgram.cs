namespace MyMauiApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureEssentials()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});
		builder.Services.AddSingleton<IDataContext, MockDataContext>();
		builder.Services.AddSingleton<MainPageViewModel>();
		builder.Services.AddSingleton<CreatePageViewModel>();
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<CreatePage>();

		return builder.Build();
	}
}
