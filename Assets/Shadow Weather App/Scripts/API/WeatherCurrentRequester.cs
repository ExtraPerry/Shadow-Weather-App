using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using ExtraPerry.Shadow.WeatherApp.API.SO;
using ExtraPerry.Shadow.WeatherApp.API.Model;

/** Notes :
 * 
 * Newtonsoft.Json has a few issues with unity :/
 * https://stackoverflow.com/questions/71664312/using-unity-plastic-newtonsoft-json-not-found-in-rider
 * https://discussions.unity.com/t/json-newtonsoft-the-type-or-namespace-name-plastic-does-not-exist-in-the-namespace-unity/256898/2
 *
*/

namespace ExtraPerry.Shadow.WeatherApp.API
{
    public class WeatherCurrentRequester : WeatherRequester
    {
        [SerializeField]
        private IPInfo ipInfo;
        [SerializeField]
        private WeatherCurrentInfo weatherCurrentInfo;

        private void Start()
        {
            TriggerUpdate();
        }

        public override void TriggerUpdate()
        {
            Debug.Log("WeatherCurrentRequester preparing to fetch api data.");
            StartCoroutine(GetWeatherCurrent());
        }

        private IEnumerator GetWeatherCurrent()
        {
            var response = new UnityWebRequest("https://api.weatherapi.com/v1/current.json?key=" + apiKey + "&q=" + ipInfo.data.city + "&aqi=yes")
            {
                downloadHandler = new DownloadHandlerBuffer()
            };
            yield return response.SendWebRequest();

            if (response.result == UnityWebRequest.Result.ConnectionError || response.result == UnityWebRequest.Result.ProtocolError)
            {
                ParseHttpErrorToConsole(response.responseCode, response.error);
                yield break;
            }

            weatherCurrentInfo.data = JsonConvert.DeserializeObject<WeatherCurrent>(response.downloadHandler.text);
            weatherCurrentInfo.HasCompletedOnce();

            Debug.Log("Finished parsing requested current weather data. => " + weatherCurrentInfo.data.current.condition.text);

            StartCoroutine(RaiseDataSyncEvent());
        }
    }
}