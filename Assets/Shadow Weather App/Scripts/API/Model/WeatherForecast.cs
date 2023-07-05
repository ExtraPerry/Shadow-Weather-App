using System;
using Newtonsoft.Json;

namespace ExtraPerry.Shadow.WeatherApp.API.Model
{
    [Serializable]
    public struct WeatherForecast
    {
        public WeatherForecast(Location location, Current current, Forecast forecast, Alerts alerts)
        {
            this.location = location;
            this.current = current;
            this.forecast = forecast;
            this.alerts = alerts;
        }

        [JsonProperty("location")]
        public Location location;

        [JsonProperty("current")]
        public Current current;

        [JsonProperty("forecast")]
        public Forecast forecast;

        [JsonProperty("alerts")]
        public Alerts alerts;
    }
}