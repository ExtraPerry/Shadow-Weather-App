using Newtonsoft.Json;
using System;

[Serializable]
public class IP
{
    public IP(string status, string country, string countryCode, string region, string regionName, string city, string zip, double lat, double lon, string timezone, string isp, string org, string orgFull, string query)
    {
        this.status = status;
        this.country = country;
        this.countryCode = countryCode;
        this.region = region;
        this.regionName = regionName;
        this.city = city;
        this.zip = zip;
        this.lat = lat;
        this.lon = lon;
        this.timezone = timezone;
        this.isp = isp;
        this.org = org;
        this.orgFull = orgFull;
        this.query = query;
    }

    [JsonProperty("status")]
    public string status { get; set; }

    [JsonProperty("country")]
    public string country { get; set; }

    [JsonProperty("countryCode")]
    public string countryCode { get; set; }

    [JsonProperty("region")]
    public string region { get; set; }

    [JsonProperty("regionName")]
    public string regionName { get; set; }

    [JsonProperty("city")]
    public string city { get; set; }

    [JsonProperty("zip")]
    public string zip { get; set; }

    [JsonProperty("lat")]
    public double lat { get; set; }

    [JsonProperty("lon")]
    public double lon { get; set; }

    [JsonProperty("timezone")]
    public string timezone { get; set; }

    [JsonProperty("isp")]
    public string isp { get; set; }

    [JsonProperty("org")]
    public string org { get; set; }

    [JsonProperty("as")]
    public string orgFull { get; set; }

    [JsonProperty("query")]
    public string query { get; set; }
}
