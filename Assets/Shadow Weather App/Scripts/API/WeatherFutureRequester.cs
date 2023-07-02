using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

/** Notes :
 * 
 * Newtonsoft.Json has a few issues with unity :/
 * https://stackoverflow.com/questions/71664312/using-unity-plastic-newtonsoft-json-not-found-in-rider
 * https://discussions.unity.com/t/json-newtonsoft-the-type-or-namespace-name-plastic-does-not-exist-in-the-namespace-unity/256898/2
 *
*/

public class WeatherFutureRequester : WeatherRequester
{
    [SerializeField]
    private IPInfo ipInfo;
    [SerializeField]
    private WeatherFutureInfo weatherFutureInfo;

    private void Awake()
    {
        TriggerUpdate();
    }

    public override void TriggerUpdate()
    {
        Debug.Log("WeatherFutureRequester preparing to fetch api data.");
        StartCoroutine(GetWeatherFuture());
    }

    private IEnumerator GetWeatherFuture()
    {
        DateTime nowIn14Days = DateTime.Now.AddDays(14);
        string dt = nowIn14Days.Year + "-" + nowIn14Days.Month + "-" + nowIn14Days.Day;
        var response = new UnityWebRequest("https://api.weatherapi.com/v1/future.json?key=" + apiKey + "&q=" + ipInfo.data.city + "&dt=" + dt)
        {
            downloadHandler = new DownloadHandlerBuffer()
        };
        yield return response.SendWebRequest();

        if (response.result == UnityWebRequest.Result.ConnectionError || response.result == UnityWebRequest.Result.ProtocolError)
        {
            ParseHttpErrorToConsole(response.responseCode, response.error);
            yield break;
        }

        weatherFutureInfo.data = JsonConvert.DeserializeObject<WeatherFuture>(response.downloadHandler.text);
        weatherFutureInfo.HasCompletedOnce();

        Debug.Log("Finished parsing requested future weather data. => " + weatherFutureInfo.data.location.name);

        StartCoroutine(RaiseDataSyncEvent());
    }
}
