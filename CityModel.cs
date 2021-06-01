using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CityFinder
{

    public class CityModel
    {
        public Query Query { get; set; }


       public Dictionary<string, List<CityInfo>> Results { get; set; }
    }

    public class Query
    {
        public string[] Codes { get; set; }

        public string Country { get; set; }
    }


    public class CityInfo
    {
        [JsonPropertyName("postal_code")]
        public string PostalCode { get; set; }

        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [JsonPropertyName("city_en")]
        public string CityEn { get; set; }

        [JsonPropertyName("state_en")]
        public string StateEn { get; set; }

        [JsonPropertyName("state_code")]
        public string StateCode { get; set; }

        public string Province { get; set; }

        [JsonPropertyName("province_code")]
        public string ProvinceCode { get; set; }
    }
}
