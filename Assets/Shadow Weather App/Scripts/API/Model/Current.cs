using System;
using Newtonsoft.Json;

namespace ExtraPerry.Shadow.WeatherApp.API.Model
{
    [Serializable]
    public struct Current
    {
        public Current(int last_updated_epoch, string last_updated, double temp_c, double temp_f, int is_day, Condition condition, double wind_mph, double wind_kph, int wind_degree, string wind_dir, double pressure_mb, double pressure_in, double precip_mm, double precip_in, int humidity, int cloud, double feelslike_c, double feelslike_f, double vis_km, double vis_miles, double uv, double gust_mph, double gust_kph, AirQuality air_quality)
        {
            this.last_updated_epoch = last_updated_epoch;
            this.last_updated = last_updated;
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
            this.vis_km = vis_km;
            this.vis_miles = vis_miles;
            this.uv = uv;
            this.gust_mph = gust_mph;
            this.gust_kph = gust_kph;
            this.air_quality = air_quality;
        }

        [JsonProperty("last_updated_epoch")]
        public long last_updated_epoch;

        [JsonProperty("last_updated")]
        public string last_updated;

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

        [JsonProperty("vis_km")]
        public double vis_km;

        [JsonProperty("vis_miles")]
        public double vis_miles;

        [JsonProperty("uv")]
        public double uv;

        [JsonProperty("gust_mph")]
        public double gust_mph;

        [JsonProperty("gust_kph")]
        public double gust_kph;

        [JsonProperty("air_quality")]
        public AirQuality air_quality;
    }
}