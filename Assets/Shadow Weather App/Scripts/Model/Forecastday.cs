using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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
    public string date { get; set; }

    [JsonProperty("date_epoch")]
    public long date_epoch { get; set; }

    [JsonProperty("day")]
    public Day day { get; set; }

    [JsonProperty("astro")]
    public Astro astro { get; set; }

    [JsonProperty("hour")]
    public List<Hour> hour { get; set; }
}