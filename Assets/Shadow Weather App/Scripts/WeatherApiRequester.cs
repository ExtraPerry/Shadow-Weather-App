using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using Newtonsoft.Json;

/** Notes :
 * 
 * Newtonsoft.Json has a few issues with unity :/
 * https://stackoverflow.com/questions/71664312/using-unity-plastic-newtonsoft-json-not-found-in-rider
 * https://discussions.unity.com/t/json-newtonsoft-the-type-or-namespace-name-plastic-does-not-exist-in-the-namespace-unity/256898/2
 *
*/

public class WeatherApiRequester : UpdatableMono
{
    [SerializeField]
    private IpInfo ipInfo;
    [SerializeField]
    private WeatherInfo weatherInfo;

    [SerializeField]
    private CustomEvent dataSync;
    public string apiKey;
    private const float appRefresh = 600; // 600s <=> 10min
    private float time = 0;

    private WeatherData lastData;

    private void Awake()
    {
        TriggerUpdate();
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
        Debug.Log("WeatherApiRequester preparing to fetch api data.");
        StartCoroutine(GetWeather());

        time = appRefresh;
        dataSync.Raise(this);
    }

    private IEnumerator GetWeather()
    {
        var response = new UnityWebRequest("https://api.weatherapi.com/v1/current.json?key=" + apiKey + "&q=" + ipInfo.data.city + "&aqi=yes")
        {
            downloadHandler = new DownloadHandlerBuffer()
        };
        yield return response.SendWebRequest();

        if (response.result == UnityWebRequest.Result.ConnectionError || response.result == UnityWebRequest.Result.ProtocolError)
        {
            switch (response.responseCode)
            {
                case 400:
                    Debug.LogError("Url request for \"weatherapi.com\" was invalid");
                    break;
                case 401:
                    Debug.LogError("Api key is not valid for \"weatherapi.com\". Please provide a valid api key for : \"" + gameObject.name + "\" GameObject in the \"WeatherApiRequester\" script.");
                    break;
                case 403:
                    Debug.LogError("Api key is has exeeded quota or is disabled for \"weatherapi.com\". Please provide a valid api key for : \"" + gameObject.name + "\" GameObject in the \"WeatherApiRequester\" script.");
                    break;
                default:
                    Debug.LogError("Unexpected error for \"weatherapi.com\" => http " + response.responseCode + ".");
                    break;
            }
            yield break;
        }

        weatherInfo.data = JsonConvert.DeserializeObject<WeatherData>(response.downloadHandler.text);
        Debug.Log("Finished parsing requested weather data. => " + weatherInfo.data.current.condition.text);
    }
}
