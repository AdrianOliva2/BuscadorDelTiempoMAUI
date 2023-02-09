using BuscadorDelTiempoMAUI.MVVM.Views;

namespace BuscadorDelTiempoMAUI;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new WeatherPage();
	}
}
