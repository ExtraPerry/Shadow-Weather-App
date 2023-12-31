using System;
using Newtonsoft.Json;

namespace ExtraPerry.Shadow.WeatherApp.API.Model
{
    [Serializable]
    public struct Hour
    {
        public Hour(int time_epoch, string time, double temp_c, double temp_f, int is_day, Condition condition, double wind_mph, double wind_kph, int wind_degree, string wind_dir, double pressure_mb, double pressure_in, double precip_mm, double precip_in, int humidity, int cloud, double feelslike_c, double feelslike_f, double windchill_c, double windchill_f, double heatindex_c, double heatindex_f, double dewpoint_c, double dewpoint_f, int will_it_rain, int chance_of_rain, int will_it_snow, int chance_of_snow, double vis_km, double vis_miles, double gust_mph, double gust_kph, double uv, AirQuality air_quality)
        {
            this.time_epoch = time_epoch;
            this.time = time;
            this.temp_c = temp_c;
            this.temp_f = temp_f;
            this.is_day = is_day;
            this.condition = condition;
            this.wind_mph = wind_mph;
            this.wind_kph = wind_kph;
            this.wind_degree = wind_degree;
            this.wind_dir = wind_dir;
            this.pressure_mb = pressure_mb;
            this.pressure_in = pressure_in;
            this.precip_mm = precip_mm;
            this.precip_in = precip_in;
            this.humidity = humidity;
            this.cloud = cloud;
            this.feelslike_c = feelslike_c;
            this.feelslike_f = feelslike_f;
            this.windchill_c = windchill_c;
            this.windchill_f = windchill_f;
            this.heatindex_c = heatindex_c;
            this.heatindex_f = heatindex_f;
            this.dewpoint_c = dewpoint_c;
            this.dewpoint_f = dewpoint_f;
            this.will_it_rain = will_it_rain;
            this.chance_of_rain = chance_of_rain;
            this.will_it_snow = will_it_snow;
            this.chance_of_snow = chance_of_snow;
            this.vis_km = vis_km;
            this.vis_miles = vis_miles;
            this.gust_mph = gust_mph;
            this.gust_kph = gust_kph;
            this.uv = uv;
            this.air_quality = air_quality;
        }

        [JsonProperty("time_epoch")]
        public long time_epoch;

        [JsonProperty("time")]
        public string time;

        [JsonProperty("temp_c")]
        public double temp_c;

        [JsonProperty("temp_f")]
        public double temp_f;

        [JsonProperty("is_day")]
        public int is_day;

        [JsonProperty("condition")]
        public Condition condition;

        [JsonProperty("wind_mph")]
        public double wind_mph;

        [JsonProperty("wind_kph")]
        public double wind_kph;

        [JsonProperty("wind_degree")]
        public int wind_degree;

        [JsonProperty("wind_dir")]
        public string wind_dir;

        [JsonProperty("pressure_mb")]
        public double pressure_mb;

        [JsonProperty("pressure_in")]
        public double pressure_in;

        [JsonProperty("precip_mm")]
        public double precip_mm;

        [JsonProperty("precip_in")]
        public double precip_in;

        [JsonProperty("humidity")]
        public int humidity;

        [JsonProperty("cloud")]
        public int cloud;

        [JsonProperty("feelslike_c")]
        public double feelslike_c;

        [JsonProperty("feelslike_f")]
        public double feelslike_f;

        [JsonProperty("windchill_c")]
        public double windchill_c;

        [JsonProperty("windchill_f")]
        public double windchill_f;

        [JsonProperty("heatindex_c")]
        public double heatindex_c;

        [JsonProperty("heatindex_f")]
        public double heatindex_f;

        [JsonProperty("dewpoint_c")]
        public double dewpoint_c;

        [JsonProperty("dewpoint_f")]
        public double dewpoint_f;

        [JsonProperty("will_it_rain")]
        public int will_it_rain;

        [JsonProperty("chance_of_rain")]
        public int chance_of_rain;

        [JsonProperty("will_it_snow")]
        public int will_it_snow;

        [JsonProperty("chance_of_snow")]
        public int chance_of_snow;

        [JsonProperty("vis_km")]
        public double vis_km;

        [JsonProperty("vis_miles")]
        public double vis_miles;

        [JsonProperty("gust_mph")]
        public double gust_mph;

        [JsonProperty("gust_kph")]
        public double gust_kph;

        [JsonProperty("uv")]
        public double uv;

        [JsonProperty("air_quality")]
        public AirQuality air_quality;
    }
}