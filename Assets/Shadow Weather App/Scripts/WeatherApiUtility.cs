using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public static class WeatherApiUtility
{
    public static List<WeatherIconData> iconRefs = JsonConvert.DeserializeObject<List<WeatherIconData>>(Resources.Load<TextAsset>("Sprites/Weather_Ref").text);

    public static Sprite GetIconSprite(int code, bool isDay)
    {
        string cycle = isDay ? "day" : "night";
        string iconNum = GetIconNumFromCode(code).ToString();

        Debug.Log("Fetching Ressource => Sprites/" + cycle + "/" + iconNum);
        return Resources.Load<Sprite>("Sprites/" + cycle + "/" + iconNum);
    }

    private static int GetIconNumFromCode(int code)
    {
        for (int i = 0; i < iconRefs.Count; i++)
        {
            if (iconRefs[i].code == code)
            {
                return iconRefs[i].icon;
            }
        }
        return 0;
    }

    public static Sprite GetImageSprite(int code, bool isDay)
    {
        string match = "";
        for (int i = 0; i < iconRefs.Count; i++)
        {
            if (iconRefs[i].code == code)
            {
                match = iconRefs[i].image;
                break;
            }
        }

        if (!isDay)
        {
            switch (match)
            {
                case "Sun":
                    match = "Moon";
                    break;
                case "SunAndCloud":
                    match = "Cloud";
                    break;
                case "SunAndRain":
                    match = "Rain";
                    break;
            }
        }

        Debug.Log("Fetching Ressource => Sprites/" + match);
        return Resources.Load<Sprite>("Sprites/" + match);
    }

    public static Sprite GetHotOrColdSprite(ColdHot choice)
    {
        string fileName = (choice == ColdHot.Cold) ? "Cold" : "Hot";

        Debug.Log("Fetching Ressource => Sprites/" + fileName);
        return Resources.Load<Sprite>("Sprites/" + fileName);
    }
}

[System.Serializable]
public class WeatherIconData
{
    public WeatherIconData(int code, string day, string night, int icon, string image)
    {
        this.code = code;
        this.day = day;
        this.night = night;
        this.icon = icon;
        this.image = image;
    }

    [JsonProperty("code")]
    public int code { get; set; }

    [JsonProperty("day")]
    public string day { get; set; }

    [JsonProperty("night")]
    public string night { get; set; }

    [JsonProperty("icon")]
    public int icon { get; set; }

    [JsonProperty("image")]
    public string image { get; set; }
}

public enum ColdHot
{
    Cold,
    Hot
}