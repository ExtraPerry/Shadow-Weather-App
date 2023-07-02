using System;
using System.Collections.Generic;
using Newtonsoft.Json;

[Serializable]
public struct Alerts
{
    [JsonProperty("alert")]
    public List<Alert> alert { get; set; }
}