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

public class WeatherForecastRequester : WeatherRequester
{
    [SerializeField]
    private IPInfo ipInfo;
    [SerializeField]
    private WeatherForecastInfo weatherForecastInfo;

    private void Awake()
    {
        TriggerUpdate();
    }

    public override void TriggerUpdate()
    {
        Debug.Log("WeatherForecastRequester preparing to fetch api data.");
        StartCoroutine(GetWeatherForecast());
    }

    private IEnumerator GetWeatherForecast()
    {
        var response = new UnityWebRequest("https://api.weatherapi.com/v1/forecast.json?key=" + apiKey + "&q=" + ipInfo.data.city + "&days=7&aqi=yes&alerts=yes")
        {
            downloadHandler = new DownloadHandlerBuffer()
        };
        yield return response.SendWebRequest();

        if (response.result == UnityWebRequest.Result.ConnectionError || response.result == UnityWebRequest.Result.ProtocolError)
        {
            ParseHttpErrorToConsole(response.responseCode, response.error);
            yield break;
        }

        weatherForecastInfo.data = JsonConvert.DeserializeObject<WeatherForecast>(response.downloadHandler.text);
        weatherForecastInfo.HasCompletedOnce();

        Debug.Log("Finished parsing requested weather forecast data. => " + weatherForecastInfo.data.current.condition.text);

        StartCoroutine(RaiseDataSyncEvent());
    }
}
