using System;
using Newtonsoft.Json;

namespace ExtraPerry.Shadow.WeatherApp.API.Model
{
    [Serializable]
    public struct WeatherFuture
    {
        public WeatherFuture(Location location, Forecast forecast)
        {
            this.location = location;
            this.forecast = forecast;
        }

        [JsonProperty("location")]
        public Location location { get; set; }

        [JsonProperty("forecast")]
        public Forecast forecast { get; set; }
    }
}