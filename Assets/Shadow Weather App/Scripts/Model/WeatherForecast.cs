using System;
using Newtonsoft.Json;

[Serializable]
public struct WeatherForecast
{
    [JsonProperty("location")]
    public Location location { get; set; }

    [JsonProperty("current")]
    public Current current { get; set; }

    [JsonProperty("forecast")]
    public Forecast forecast { get; set; }

    [JsonProperty("alerts")]
    public Alerts alerts { get; set; }
}
