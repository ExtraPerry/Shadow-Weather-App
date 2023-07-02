using System;
using Newtonsoft.Json;

[Serializable]
public struct WeatherFuture
{
    [JsonProperty("location")]
    public Location location { get; set; }

    [JsonProperty("forecast")]
    public Forecast forecast { get; set; }
}
