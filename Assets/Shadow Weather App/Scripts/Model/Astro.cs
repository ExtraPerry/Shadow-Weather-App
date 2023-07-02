using System;
using Newtonsoft.Json;

[Serializable]
public class Astro
{
    public Astro(string sunrise, string sunset, string moonrise, string moonset, string moon_phase, string moon_illumination, int is_moon_up, int is_sun_up)
    {
        this.sunrise = sunrise;
        this.sunset = sunset;
        this.moonrise = moonrise;
        this.moonset = moonset;
        this.moon_phase = moon_phase;
        this.moon_illumination = moon_illumination;
        this.is_moon_up = is_moon_up;
        this.is_sun_up = is_sun_up;
    }

    [JsonProperty("sunrise")]
    public string sunrise { get; set; }

    [JsonProperty("sunset")]
    public string sunset { get; set; }

    [JsonProperty("moonrise")]
    public string moonrise { get; set; }

    [JsonProperty("moonset")]
    public string moonset { get; set; }

    [JsonProperty("moon_phase")]
    public string moon_phase { get; set; }

    [JsonProperty("moon_illumination")]
    public string moon_illumination { get; set; }

    [JsonProperty("is_moon_up")]
    public int is_moon_up { get; set; }

    [JsonProperty("is_sun_up")]
    public int is_sun_up { get; set; }
}