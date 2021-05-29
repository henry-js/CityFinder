using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CityFinder
{

    public class CityModel
    {
        public Query Query { get; set; }


       [JsonExtensionData]
       public IDictionary<string, JsonElement> AdditionalData { get; set; }
    }

    public class Query
    {
        public string[] Codes { get; set; }

        public string Country { get; set; }
    }


    public  class CityInfo
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

    // public partial class CityModel
    // {
    //     public static CityModel FromJson(string json) => JsonConvert.DeserializeObject<CityModel>(json, QuickType.Converter.Settings);
    // }

    // public static class Serialize
    // {
    //     public static string ToJson(this CityModel self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
    // }

    // internal static class Converter
    // {
    //     public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    //     {
    //         MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
    //         DateParseHandling = DateParseHandling.None,
    //         Converters = {
    //             new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
    //         },
    //     };
    // }
}
