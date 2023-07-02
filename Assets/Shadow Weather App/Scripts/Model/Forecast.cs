using System;
using System.Collections.Generic;
using Newtonsoft.Json;

[Serializable]
public class Forecast
{
    [JsonProperty("forecastday")]
    public List<Forecastday> forecastday { get; set; }
}