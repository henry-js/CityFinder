using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace CityFinder
{
    public class Program
    {

        static async Task Main(string[] args)
        {
            // Set up api request
            List<String> worldCountries = GetCountryCodes();

            while (true)
            {
                Console.Write($"Please enter 2-letter ISO country code (https://www.countrycode.org/) \n-> ");
                // Get user input
                string countryCode = Console.ReadLine().ToUpper();

                if (!worldCountries.Contains(countryCode))
                {
                    Console.WriteLine($"Country code is incorrect. Try again.");
                    continue;
                }
                Console.Write($"Please enter alphanumeric zip/postal code\n-> ");

                string zipCode = Console.ReadLine();
                if (!Regex.IsMatch(zipCode, "^[a-zA-Z0-9]*$"))
                {
                    Console.WriteLine($"Your input contained invalid characters");
                    continue;
                }

                var response = await CityProcessor.FindCity(countryCode, zipCode);
                Console.WriteLine($"{response.CityEn}");
                Console.WriteLine($"Press any key to try again.");
                Console.ReadLine();
                Console.Clear();
                continue;
            }

        }

        private static List<String> GetCountryCodes()
        {
            List<CultureInfo> worldCountries = CultureInfo.GetCultures(CultureTypes.SpecificCultures).ToList<CultureInfo>();
            List<String> listOfCountryCodes = new List<string>();
            foreach (var country in worldCountries)
            {
                listOfCountryCodes.Add(new RegionInfo(country.LCID).TwoLetterISORegionName);
            }
            listOfCountryCodes = listOfCountryCodes.Distinct().ToList();
            listOfCountryCodes.Sort();
            listOfCountryCodes.RemoveAll(code => code.Length > 2);
            return listOfCountryCodes;
        }
    }
}
