using System;
using Newtonsoft.Json;

[Serializable]
public class WeatherFuture
{
    [JsonProperty("location")]
    public Location location { get; set; }

    [JsonProperty("forecast")]
    public Forecast forecast { get; set; }
}
