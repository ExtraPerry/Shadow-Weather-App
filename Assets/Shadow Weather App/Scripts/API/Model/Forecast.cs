using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ExtraPerry.Shadow.WeatherApp.API.Model
{
    [Serializable]
    public struct Forecast
    {
        public Forecast(List<Forecastday> forecastday)
        {
            this.forecastday = forecastday;
        }

        [JsonProperty("forecastday")]
        public List<Forecastday> forecastday;
    }
}