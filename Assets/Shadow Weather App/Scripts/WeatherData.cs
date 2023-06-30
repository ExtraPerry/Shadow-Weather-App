using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class WeatherData : ApiData
{
    public Location location;
    public Weather weather;
}

[System.Serializable]
public struct Location
{
    public readonly string city;
    public readonly string region;
    public readonly string country;
    public readonly float lat;
    public readonly float lon;
    public readonly string timezoneId;
    public readonly int localEpoch;
    public readonly string localTime;

    public Location(string city, string region, string country, float lat, float lon, string timezoneId, int localEpoch, string localTime)
    {
        this.city = city;
        this.region = region;
        this.country = country;
        this.lat = lat;
        this.lon = lon;
        this.timezoneId = timezoneId;
        this.localEpoch = localEpoch;
        this.localTime = localTime;
    }
}

public enum Direction
{
    Undefined,
    N,
    NNE,
    NE,
    ENE,
    E,
    ESE,
    SE,
    SSE,
    S,
    SSW,
    SW,
    WSW,
    W,
    WNW,
    NW,
    NNW
}

[System.Serializable] 
public struct Weather
{
    public readonly int lastUpdatedEpoch;
    public readonly string lastUpdated;
    public readonly float temp_c;
    public readonly float temp_f;
    public readonly bool isDay;
    public readonly string condition;
    public readonly string icon;
    public readonly int code;
    public readonly float wind_mph;
    public readonly float wind_kph;
    public readonly int wind_degree;
    public readonly Direction wind_direction;
    public readonly float pressure_mb;
    public readonly float pressure_in;
    public readonly float precip_mm;
    public readonly float precip_in;
    public readonly int humidity;
    public readonly int cloud;
    public readonly float feelslike_c;
    public readonly float feelslike_f;
    public readonly float vis_km;
    public readonly float vis_miles;
    public readonly float uv;
    public readonly float gust_mph;
    public readonly float gust_kph;
    public readonly AirQuality air_quality;

    public Weather(int lastUpdatedEpoch, string lastUpdated, float temp_c, float temp_f, bool isDay, string condition, string icon, int code, float wind_mph, float wind_kph, int wind_degree, Direction wind_direction, float pressure_mb, float pressure_in, float precip_mm, float precip_in, int humidity, int cloud, float feelslike_c, float feelslike_f, float vis_km, float vis_miles, float uv, float gust_mph, float gust_kph, AirQuality air_quality)
    {
        this.lastUpdatedEpoch = lastUpdatedEpoch;
        this.lastUpdated = lastUpdated;
        this.temp_c = temp_c;
        this.temp_f = temp_f;
        this.isDay = isDay;
        this.condition = condition;
        this.icon = icon;
        this.code = code;
        this.wind_mph = wind_mph;
        this.wind_kph = wind_kph;
        this.wind_degree = wind_degree;
        this.wind_direction = wind_direction;
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
}

public struct AirQuality
{
    public readonly float co;
    public readonly float no2;
    public readonly float o3;
    public readonly float so2;
    public readonly float pm2_5;
    public readonly float pm10;
    public readonly int us_epa_index;
    public readonly int gb_defra_index;

    public AirQuality(float co, float no2, float o3, float so2, float pm2_5, float pm10, int us_epa_index, int gb_defra_index)
    {
        this.co = co;
        this.no2 = no2;
        this.o3 = o3;
        this.so2 = so2;
        this.pm2_5 = pm2_5;
        this.pm10 = pm10;
        this.us_epa_index = us_epa_index;
        this.gb_defra_index = gb_defra_index;
    }
}