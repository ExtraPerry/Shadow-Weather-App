using System;
using Newtonsoft.Json;

namespace ExtraPerry.Shadow.WeatherApp.API.Model
{
    [Serializable]
    public struct Day
    {
        public Day(double maxtemp_c, double maxtemp_f, double mintemp_c, double mintemp_f, double avgtemp_c, double avgtemp_f, double maxwind_mph, double maxwind_kph, double totalprecip_mm, double totalprecip_in, double totalsnow_cm, double avgvis_km, double avgvis_miles, double avghumidity, int daily_will_it_rain, int daily_chance_of_rain, int daily_will_it_snow, int daily_chance_of_snow, Condition condition, double uv, AirQuality air_quality)
        {
            this.maxtemp_c = maxtemp_c;
            this.maxtemp_f = maxtemp_f;
            this.mintemp_c = mintemp_c;
            this.mintemp_f = mintemp_f;
            this.avgtemp_c = avgtemp_c;
            this.avgtemp_f = avgtemp_f;
            this.maxwind_mph = maxwind_mph;
            this.maxwind_kph = maxwind_kph;
            this.totalprecip_mm = totalprecip_mm;
            this.totalprecip_in = totalprecip_in;
            this.totalsnow_cm = totalsnow_cm;
            this.avgvis_km = avgvis_km;
            this.avgvis_miles = avgvis_miles;
            this.avghumidity = avghumidity;
            this.daily_will_it_rain = daily_will_it_rain;
            this.daily_chance_of_rain = daily_chance_of_rain;
            this.daily_will_it_snow = daily_will_it_snow;
            this.daily_chance_of_snow = daily_chance_of_snow;
            this.condition = condition;
            this.uv = uv;
            this.air_quality = air_quality;
        }

        [JsonProperty("maxtemp_c")]
        public double maxtemp_c;

        [JsonProperty("maxtemp_f")]
        public double maxtemp_f;

        [JsonProperty("mintemp_c")]
        public double mintemp_c;

        [JsonProperty("mintemp_f")]
        public double mintemp_f;

        [JsonProperty("avgtemp_c")]
        public double avgtemp_c;

        [JsonProperty("avgtemp_f")]
        public double avgtemp_f;

        [JsonProperty("maxwind_mph")]
        public double maxwind_mph;

        [JsonProperty("maxwind_kph")]
        public double maxwind_kph;

        [JsonProperty("totalprecip_mm")]
        public double totalprecip_mm;

        [JsonProperty("totalprecip_in")]
        public double totalprecip_in;

        [JsonProperty("totalsnow_cm")]
        public double totalsnow_cm;

        [JsonProperty("avgvis_km")]
        public double avgvis_km;

        [JsonProperty("avgvis_miles")]
        public double avgvis_miles;

        [JsonProperty("avghumidity")]
        public double avghumidity;

        [JsonProperty("daily_will_it_rain")]
        public int daily_will_it_rain;

        [JsonProperty("daily_chance_of_rain")]
        public int daily_chance_of_rain;

        [JsonProperty("daily_will_it_snow")]
        public int daily_will_it_snow;

        [JsonProperty("daily_chance_of_snow")]
        public int daily_chance_of_snow;

        [JsonProperty("condition")]
        public Condition condition;

        [JsonProperty("uv")]
        public double uv;

        [JsonProperty("air_quality")]
        public AirQuality air_quality;
    }
}