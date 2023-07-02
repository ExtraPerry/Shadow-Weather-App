using System;
using Newtonsoft.Json;

[Serializable]
public class Alert
{
    [JsonProperty("headline")]
    public string headline { get; set; }

    [JsonProperty("msgtype")]
    public string msgtype { get; set; }

    [JsonProperty("severity")]
    public string severity { get; set; }

    [JsonProperty("urgency")]
    public string urgency { get; set; }

    [JsonProperty("areas")]
    public string areas { get; set; }

    [JsonProperty("category")]
    public string category { get; set; }

    [JsonProperty("certainty")]
    public string certainty { get; set; }

    [JsonProperty("event")]
    public string @event { get; set; }

    [JsonProperty("note")]
    public string note { get; set; }

    [JsonProperty("effective")]
    public DateTime effective { get; set; }

    [JsonProperty("expires")]
    public DateTime expires { get; set; }

    [JsonProperty("desc")]
    public string desc { get; set; }

    [JsonProperty("instruction")]
    public string instruction { get; set; }
}