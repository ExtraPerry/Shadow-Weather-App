using System;
using Newtonsoft.Json;

namespace ExtraPerry.Shadow.WeatherApp.API.Model
{
    [Serializable]
    public struct SearchAutocomplete
    {
        public SearchAutocomplete(int id, string name, string region, string country, double lat, double lon, string url)
        {
            this.id = id;
            this.name = name;
            this.region = region;
            this.country = country;
            this.lat = lat;
            this.lon = lon;
            this.url = url;
        }

        [JsonProperty("id")]
        public int id;

        [JsonProperty("name")]
        public string name;

        [JsonProperty("region")]
        public string region;

        [JsonProperty("country")]
        public string country;

        [JsonProperty("lat")]
        public double lat;

        [JsonProperty("lon")]
        public double lon;

        [JsonProperty("url")]
        public string url;
    }
}