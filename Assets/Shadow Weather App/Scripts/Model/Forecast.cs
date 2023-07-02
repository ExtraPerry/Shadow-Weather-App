using System;
using System.Collections.Generic;
using Newtonsoft.Json;

[Serializable]
public struct Forecast
{
    [JsonProperty("forecastday")]
    public List<Forecastday> forecastday { get; set; }
}