using Geocoding.Google;
using Geocoding;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using udemyMAUI1.MVVM.Models;
using System.Globalization;
using udemyMAUI1.Helper;

namespace udemyMAUI1.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class WeatherViewModel
    {

        public WeatherData WeatherData { get; set; }
        public string PlaceName { get; set; }
        public DateTime Date { get; set; } =
             DateTime.Now;

        public bool IsVisible { get; set; }
        public bool IsLoading { get; set; }

        private HttpClient client;

        public WeatherViewModel()
        {
            client = new HttpClient();
        }

        public ICommand SearchCommand =>
             new Command(async (searchText) =>
             {
                 var location =
                        await GetCoordinatesAsync(searchText.ToString());
                 PlaceName = "";
                 if (location != null)
                 {
                     PlaceName = location.FormattedAddress;
                     await GetWeather(location);
                 }
             });


        private async Task GetWeather(Address location)
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";

            var url =
                 $"https://api.open-meteo.com/v1/forecast?latitude={location.Coordinates.Latitude.ToString(nfi)}&longitude={location.Coordinates.Longitude.ToString(nfi)}&daily=weathercode,temperature_2m_max,temperature_2m_min&current_weather=true&timezone=America%2FChicago";

            IsLoading = true;

            var response =
              await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var data = await JsonSerializer
                         .DeserializeAsync<WeatherData>(responseStream);
                    WeatherData = data;

                    for (int i = 0; i < WeatherData.daily.time.Length; i++)
                    {
                        var daily2 = new Daily2
                        {
                            time = WeatherData.daily.time[i],
                            temperature_2m_max = WeatherData.daily.temperature_2m_max[i],
                            temperature_2m_min = WeatherData.daily.temperature_2m_min[i],
                            weathercode = WeatherData.daily.weathercode[i]
                        };
                        WeatherData.daily2.Add(daily2);
                    }
                    IsVisible = true;
                }
            }
            IsLoading = false;
        }

        private async Task<Address> GetCoordinatesAsync(string address)
        {
            IGeocoder geocoder = ServiceHelper.GetService<GoogleGeocoder>();
            IEnumerable<Address> locations = await geocoder.GeocodeAsync(address);

            Address location = locations?.FirstOrDefault();

            if (location != null)
                Console
                     .WriteLine($"Latitude: {location.Coordinates.Latitude}, Longitude: {location.Coordinates.Longitude}");
            return location;
        }

    }
}
