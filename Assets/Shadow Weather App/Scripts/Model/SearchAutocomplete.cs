using System;
using Newtonsoft.Json;

[Serializable]
public class SearchAutocomplete
{
    [JsonProperty("id")]
    public int id { get; set; }

    [JsonProperty("name")]
    public string name { get; set; }

    [JsonProperty("region")]
    public string region { get; set; }

    [JsonProperty("country")]
    public string country { get; set; }

    [JsonProperty("lat")]
    public double lat { get; set; }

    [JsonProperty("lon")]
    public double lon { get; set; }

    [JsonProperty("url")]
    public string url { get; set; }
}
