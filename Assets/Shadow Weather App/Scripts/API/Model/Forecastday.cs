using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ExtraPerry.Shadow.WeatherApp.API.Model
{
    [Serializable]
    public struct Forecastday
    {
        public Forecastday(string date, int date_epoch, Day day, Astro astro, List<Hour> hour)
        {
            this.date = date;
            this.date_epoch = date_epoch;
            this.day = day;
            this.astro = astro;
            this.hour = hour;
        }

        [JsonProperty("date")]
        public string date;

        [JsonProperty("date_epoch")]
        public long date_epoch;

        [JsonProperty("day")]
        public Day day;

        [JsonProperty("astro")]
        public Astro astro;

        [JsonProperty("hour")]
        public List<Hour> hour;
    }
}