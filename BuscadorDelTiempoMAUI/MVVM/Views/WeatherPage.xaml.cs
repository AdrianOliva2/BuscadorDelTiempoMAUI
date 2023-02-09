using BuscadorDelTiempoMAUI.MVVM.ViewModels;

namespace BuscadorDelTiempoMAUI.MVVM.Views;

public partial class WeatherPage : ContentPage
{
	public WeatherPage()
	{
		InitializeComponent();
		BindingContext = new WeatherPageViewModel();
	}
}