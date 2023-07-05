using System;
using Newtonsoft.Json;

namespace ExtraPerry.Shadow.WeatherApp.API.Model
{
    [Serializable]
    public struct AirQuality
    {
        public AirQuality(double co, double no2, double o3, double so2, double pm2_5, double pm10, int usepaindex, int gbdefraindex)
        {
            this.co = co;
            this.no2 = no2;
            this.o3 = o3;
            this.so2 = so2;
            this.pm2_5 = pm2_5;
            this.pm10 = pm10;
            this.usepaindex = usepaindex;
            this.gbdefraindex = gbdefraindex;
        }

        [JsonProperty("co")]
        public double co { get; set; }

        [JsonProperty("no2")]
        public double no2 { get; set; }

        [JsonProperty("o3")]
        public double o3 { get; set; }

        [JsonProperty("so2")]
        public double so2 { get; set; }

        [JsonProperty("pm2_5")]
        public double pm2_5 { get; set; }

        [JsonProperty("pm10")]
        public double pm10 { get; set; }

        [JsonProperty("us-epa-index")]
        public int usepaindex { get; set; }

        [JsonProperty("gb-defra-index")]
        public int gbdefraindex { get; set; }
    }
}