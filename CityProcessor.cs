using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CityFinder
{
    public static class CityProcessor
    {
        public static async Task<String> FindCity(string countryCode, string zipCode)
        {
            string baseUrl = $"https://app.zipcodebase.com/api/v1/search?apikey=b66577a0-bed0-11eb-804a-255206b8a299&country={countryCode}&codes={zipCode}";

            var response = await ApiHelper.client.GetFromJsonAsync<CityModel>(baseUrl);
            string test = "test";
            // Console.WriteLine($"{response}");
            // response.AdditionalData["results"].To
            JsonElement results = response.AdditionalData["results"];
            // Console.WriteLine($"{results}");
            var postcode = new JsonElement();
            results.TryGetProperty(zipCode,out postcode);
            var CityInfo = JsonSerializer.Deserialize<CityInfo>(postcode[0].ToString(), new JsonSerializerOptions{
                PropertyNameCaseInsensitive = true
            });
            return CityInfo.City;
        }
    }
}
