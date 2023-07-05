using System;
using Newtonsoft.Json;

namespace ExtraPerry.Shadow.WeatherApp.API.Model
{
    [Serializable]
    public struct WeatherCurrent
    {
        public WeatherCurrent(Location location, Current current)
        {
            this.location = location;
            this.current = current;
        }

        [JsonProperty("location")]
        public Location location;

        [JsonProperty("current")]
        public Current current;
    }
}