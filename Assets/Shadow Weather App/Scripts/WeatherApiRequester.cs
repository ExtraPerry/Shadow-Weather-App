using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
public class WeatherApiRequester : UpdatableMono
{
    [SerializeField]
    private IpData ipData;
    [SerializeField]
    private WeatherData lastWeatherRequested;

    public string apiKey;
    public float appRefresh = 600; // 600s <=> 10min
    private float time;

    private void Start()
    {
        appRefresh = 0;
        time = appRefresh;
        StartCoroutine(GetWeather());
    }

    private void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            TriggerUpdate();
        }
    }

    public override void TriggerUpdate()
    {
        print("WeatherApiRequester preparing to fetch api data.");
        StartCoroutine(GetWeather());

        time = appRefresh;
    }

    private IEnumerator GetWeather()
    {
        var weatherAPI = new UnityWebRequest("http://api.weatherapi.com/v1/current.json?key=" + apiKey + "&q=" + ipData.city + "&aqi=yes")
        {
            downloadHandler = new DownloadHandlerBuffer()
        };
        yield return weatherAPI.SendWebRequest();

        if (weatherAPI.result == UnityWebRequest.Result.ConnectionError || weatherAPI.result == UnityWebRequest.Result.ProtocolError)
        {
            yield break;
        }

        JSONNode weatherData = JSON.Parse(weatherAPI.downloadHandler.text);

        Location location = new Location(
            weatherData["location"]["name"],
            weatherData["location"]["region"],
            weatherData["location"]["country"],
            float.Parse(weatherData["location"]["lat"]),
            float.Parse(weatherData["location"]["lon"]),
            weatherData["location"]["tz_id"],
            int.Parse(weatherData["location"]["localtime_epoch"]),
            weatherData["location"]["localtime"]
        );

        AirQuality airQuality = new AirQuality(
            float.Parse(weatherData["current"]["air_quality"]["co"]),
            float.Parse(weatherData["current"]["air_quality"]["no2"]),
            float.Parse(weatherData["current"]["air_quality"]["o3"]),
            float.Parse(weatherData["current"]["air_quality"]["so2"]),
            float.Parse(weatherData["current"]["air_quality"]["pm2_5"]),
            float.Parse(weatherData["current"]["air_quality"]["pm10"]),
            int.Parse(weatherData["current"]["air_quality"]["us-epa-index"]),
            int.Parse(weatherData["current"]["air_quality"]["gb-defra-index"])
        );

        Direction direction = ParseDirection(weatherData["current"]["wind_dir"]);
        bool isDay = weatherData["current"]["is_day"] == "1" ? true : false;

        Weather weather = new Weather(
            int.Parse(weatherData["current"]["last_updated_epoch"]),
            weatherData["current"]["last_updated"],
            float.Parse(weatherData["current"]["temp_c"]),
            float.Parse(weatherData["current"]["temp_f"]),
            isDay,
            weatherData["current"]["condition"]["text"],
            weatherData["current"]["condition"]["icon"],
            weatherData["current"]["condition"]["code"],
            float.Parse(weatherData["current"]["wind_mph"]),
            float.Parse(weatherData["current"]["wind_kph"]),
            int.Parse(weatherData["current"]["wind_degree"]),
            direction,
            float.Parse(weatherData["current"]["pressure_mb"]),
            float.Parse(weatherData["current"]["pressure_in"]),
            float.Parse(weatherData["current"]["precip_mm"]),
            float.Parse(weatherData["current"]["precip_in"]),
            int.Parse(weatherData["current"]["humidity"]),
            int.Parse(weatherData["current"]["cloud"]),
            float.Parse(weatherData["current"]["feelslike_c"]),
            float.Parse(weatherData["current"]["feelslike_f"]),
            float.Parse(weatherData["current"]["vis_km"]),
            float.Parse(weatherData["current"]["vis_miles"]),
            float.Parse(weatherData["current"]["uv"]),
            float.Parse(weatherData["current"]["gust_mph"]),
            float.Parse(weatherData["current"]["gust_kph"]),
            airQuality
        );

        lastWeatherRequested.location = location;
        lastWeatherRequested.weather = weather;

        print("Finished parsing requested weather data.");
    }

    private Direction ParseDirection(string input)
    {
        Direction direction = Direction.Undefined;
        switch (input)
        {
            case "N":
                direction = Direction.N;
                break;
            case "NNE":
                direction = Direction.NNE;
                break;
            case "NE":
                direction = Direction.NE;
                break;
            case "E":
                direction = Direction.E;
                break;
            case "ESE":
                direction = Direction.ESE;
                break;
            case "SE":
                direction = Direction.SE;
                break;
            case "SSE":
                direction = Direction.SSE;
                break;
            case "S":
                direction = Direction.S;
                break;
            case "SSW":
                direction = Direction.SSW;
                break;
            case "SW":
                direction = Direction.SW;
                break;
            case "WSW":
                direction = Direction.WSW;
                break;
            case "W":
                direction = Direction.W;
                break;
            case "WNW":
                direction = Direction.WNW;
                break;
            case "NN":
                direction = Direction.NW;
                break;
            case "NNW":
                direction = Direction.NNW;
                break;
        }
        return direction;
    }
}
