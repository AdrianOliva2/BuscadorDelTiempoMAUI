using SkiaSharp.Views.Maui.Controls.Hosting;

namespace BuscadorDelTiempoMAUI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseSkiaSharp()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.ConfigureEssentials(essentials =>
             {
                 essentials.UseMapServiceToken("3apS2des4pUvPtuuYPVX~ps9fFHZlqbt4c3jUMdVYbQ~AnA-yefUhtiKG0ixWoTUmmPJCvuYMUu0Oa_wO6hBtGdZRZ-TXyVSCMcTNyCmaj6k");
             });

        return builder.Build();
	}
}
