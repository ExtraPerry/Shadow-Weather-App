using System;
using Newtonsoft.Json;

[Serializable]
public struct WeatherCurrent
{
    public WeatherCurrent(Location location, Current current)
    {
        this.location = location;
        this.current = current;
    }

    [JsonProperty("location")]
    public Location location { get; set; }

    [JsonProperty("current")]
    public Current current { get; set; }
}