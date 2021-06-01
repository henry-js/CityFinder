using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CityFinder
{
    public static class CityProcessor
    {
        private static HttpClient _client = new();
        public static async Task<CityInfo> FindCity(string countryCode, string zipCode)
        {
            string baseUrl = $"https://app.zipcodebase.com/api/v1/search?apikey=b66577a0-bed0-11eb-804a-255206b8a299&country={countryCode}&codes={zipCode}";

            var response = await _client.GetFromJsonAsync<CityModel>(baseUrl);
            // Console.WriteLine($"{response}");
            // response.AdditionalData["results"].To
            if(!response.Results.TryGetValue(zipCode, out var cities))
            {
                Console.WriteLine($"Did you enter a valid postcode?");
                return null;
            }
            return cities[0];
        }
    }
}
