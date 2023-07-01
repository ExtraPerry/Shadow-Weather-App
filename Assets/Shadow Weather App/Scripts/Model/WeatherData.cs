using System;
using Newtonsoft.Json;

/**
 * Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
 * string mySerializedText = JsonConvert.SerializeObject(weatherData);
*/

[Serializable]
public class WeatherData
{
    public WeatherData(Location location, Current current)
    {
        this.location = location;
        this.current = current;
    }

    [JsonProperty("location")]
    public Location location { get; set; }

    [JsonProperty("current")]
    public Current current { get; set; }
}

[Serializable]
public class AirQuality
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

[Serializable]
public class Condition
{
    public Condition(string text, string icon, int code)
    {
        this.text = text;
        this.icon = icon;
        this.code = code;
    }

    [JsonProperty("text")]
    public string text { get; set; }

    [JsonProperty("icon")]
    public string icon { get; set; }

    [JsonProperty("code")]
    public int code { get; set; }
}

[Serializable]
public class Current
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
    public int last_updated_epoch { get; set; }

    [JsonProperty("last_updated")]
    public string last_updated { get; set; }

    [JsonProperty("temp_c")]
    public double temp_c { get; set; }

    [JsonProperty("temp_f")]
    public double temp_f { get; set; }

    [JsonProperty("is_day")]
    public int is_day { get; set; }

    [JsonProperty("condition")]
    public Condition condition { get; set; }

    [JsonProperty("wind_mph")]
    public double wind_mph { get; set; }

    [JsonProperty("wind_kph")]
    public double wind_kph { get; set; }

    [JsonProperty("wind_degree")]
    public int wind_degree { get; set; }

    [JsonProperty("wind_dir")]
    public string wind_dir { get; set; }

    [JsonProperty("pressure_mb")]
    public double pressure_mb { get; set; }

    [JsonProperty("pressure_in")]
    public double pressure_in { get; set; }

    [JsonProperty("precip_mm")]
    public double precip_mm { get; set; }

    [JsonProperty("precip_in")]
    public double precip_in { get; set; }

    [JsonProperty("humidity")]
    public int humidity { get; set; }

    [JsonProperty("cloud")]
    public int cloud { get; set; }

    [JsonProperty("feelslike_c")]
    public double feelslike_c { get; set; }

    [JsonProperty("feelslike_f")]
    public double feelslike_f { get; set; }

    [JsonProperty("vis_km")]
    public double vis_km { get; set; }

    [JsonProperty("vis_miles")]
    public double vis_miles { get; set; }

    [JsonProperty("uv")]
    public double uv { get; set; }

    [JsonProperty("gust_mph")]
    public double gust_mph { get; set; }

    [JsonProperty("gust_kph")]
    public double gust_kph { get; set; }

    [JsonProperty("air_quality")]
    public AirQuality air_quality { get; set; }
}

[Serializable]
public class Location
{
    public Location(string name, string region, string country, double lat, double lon, string tz_id, int localtime_epoch, string localtime)
    {
        this.name = name;
        this.region = region;
        this.country = country;
        this.lat = lat;
        this.lon = lon;
        this.tz_id = tz_id;
        this.localtime_epoch = localtime_epoch;
        this.localtime = localtime;
    }

    [JsonProperty("name")]
    public string name { get; set; }

    [JsonProperty("region")]
    public string region { get; set; }

    [JsonProperty("country")]
    public string country { get; set; }

    [JsonProperty("lat")]
    public double lat { get; set; }

    [JsonProperty("lon")]
    public double lon { get; set; }

    [JsonProperty("tz_id")]
    public string tz_id { get; set; }

    [JsonProperty("localtime_epoch")]
    public int localtime_epoch { get; set; }

    [JsonProperty("localtime")]
    public string localtime { get; set; }
}
