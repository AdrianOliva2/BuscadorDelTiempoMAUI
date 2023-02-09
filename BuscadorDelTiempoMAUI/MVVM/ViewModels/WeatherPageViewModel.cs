using BuscadorDelTiempoMAUI.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BuscadorDelTiempoMAUI.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    internal class WeatherPageViewModel
    {
        public Weather Weather { get; set; }
        public ICommand SearchBarCommand { get; set; }
        public string LocationZone { get; set; }

        public WeatherPageViewModel()
        {
            Weather = new Weather();
            SearchBarCommand = new Command(async (locationZone) =>
            {
                LocationZone = locationZone.ToString();
                Location location = await GetCoordinatesAsync(locationZone.ToString());
                await GetWeather(location);
            });
        }

        private async Task<Location> GetCoordinatesAsync(string address)
        {
            var locations = await Geocoding.GetLocationsAsync(address);

            var location = locations?.FirstOrDefault();

            return location;
        }

        private async Task GetWeather(Location location)
        {
            string longitude = (Math.Round(location.Longitude, 2).ToString().Replace(",", "."));
            string latitude = (Math.Round(location.Latitude, 2).ToString().Replace(",", "."));

            var url = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&daily=weathercode,temperature_2m_max,temperature_2m_min&current_weather=true&timezone=Europe%2FBerlin";
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var data = await JsonSerializer.DeserializeAsync<Weather>(responseStream);
                    Weather = data;
                }
            }
        }

    }
}
