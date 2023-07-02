using System;
using Newtonsoft.Json;

[Serializable]
public class Location
{
    public Location(string name, string region, string country, double lat, double lon, string tz_id, int localtime_epoch, string localtime)
    {
        this.name = name;
        this.region = region;
        this.country = country;
        this.lat = lat;
        this.lon = lon;
        this.tz_id = tz_id;
        this.localtime_epoch = localtime_epoch;
        this.localtime = localtime;
    }

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

    [JsonProperty("tz_id")]
    public string tz_id { get; set; }

    [JsonProperty("localtime_epoch")]
    public long localtime_epoch { get; set; }

    [JsonProperty("localtime")]
    public string localtime { get; set; }
}