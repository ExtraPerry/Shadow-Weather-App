using System;
using Newtonsoft.Json;

namespace ExtraPerry.Shadow.WeatherApp.API.Model
{
    [Serializable]
    public struct Location
    {
        public Location(string name, string region, string country, double lat, double lon, string tz_id, int localtime_epoch, string localtime)
        {
            this.name = name;
            this.region = region;
            this.country = country;
            this.lat = lat;
            this.lon = lon;
            this.tz_id = tz_id;
            this.localtime_epoch = localtime_epoch;
            this.localtime = localtime;
        }

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

        [JsonProperty("tz_id")]
        public string tz_id;

        [JsonProperty("localtime_epoch")]
        public long localtime_epoch;

        [JsonProperty("localtime")]
        public string localtime;
    }
}