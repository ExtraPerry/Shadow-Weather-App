using System;
using Newtonsoft.Json;

[Serializable]
public class Condition
{
    public Condition(string text, string icon, int code)
    {
        this.text = text;
        this.icon = icon;
        this.code = code;
    }

    [JsonProperty("text")]
    public string text { get; set; }

    [JsonProperty("icon")]
    public string icon { get; set; }

    [JsonProperty("code")]
    public int code { get; set; }
}