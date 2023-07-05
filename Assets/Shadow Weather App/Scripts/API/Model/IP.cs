using Newtonsoft.Json;
using System;

namespace ExtraPerry.Shadow.WeatherApp.API.Model
{
    [Serializable]
    public struct IP
    {
        public IP(string status, string country, string countryCode, string region, string regionName, string city, string zip, double lat, double lon, string timezone, string isp, string org, string orgFull, string query)
        {
            this.status = status;
            this.country = country;
            this.countryCode = countryCode;
            this.region = region;
            this.regionName = regionName;
            this.city = city;
            this.zip = zip;
            this.lat = lat;
            this.lon = lon;
            this.timezone = timezone;
            this.isp = isp;
            this.org = org;
            this.orgFull = orgFull;
            this.query = query;
        }

        [JsonProperty("status")]
        public string status;

        [JsonProperty("country")]
        public string country;

        [JsonProperty("countryCode")]
        public string countryCode;

        [JsonProperty("region")]
        public string region;

        [JsonProperty("regionName")]
        public string regionName;

        [JsonProperty("city")]
        public string city;

        [JsonProperty("zip")]
        public string zip;

        [JsonProperty("lat")]
        public double lat;

        [JsonProperty("lon")]
        public double lon;

        [JsonProperty("timezone")]
        public string timezone;

        [JsonProperty("isp")]
        public string isp;

        [JsonProperty("org")]
        public string org;

        [JsonProperty("as")]
        public string orgFull;

        [JsonProperty("query")]
        public string query;
    }
}