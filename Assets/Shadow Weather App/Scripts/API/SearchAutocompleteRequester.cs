using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using ExtraPerry.Shadow.WeatherApp.UI;
using ExtraPerry.Shadow.WeatherApp.API.SO;
using ExtraPerry.Shadow.WeatherApp.API.Model;

namespace ExtraPerry.Shadow.WeatherApp.API
{
    public class SearchAutocompleteRequester : WeatherRequester
    {
        [SerializeField]
        private SearchAutocompleteInfo searchAutoInfo;

        public override void TriggerUpdate(Component sender, object data)
        {
            if (sender is SearchInputManager && data is string) TriggerUpdate((string)data);
        }

        public void TriggerUpdate(string input)
        {
            Debug.Log("SearchAutocompleteRequester preparing to fetch api data.");
            StartCoroutine(GetSearchAutocomplete(input));
        }

        private IEnumerator GetSearchAutocomplete(string input)
        {
            var response = new UnityWebRequest("https://api.weatherapi.com/v1/search.json?key=" + apiKey + "&q=" + input)
            {
                downloadHandler = new DownloadHandlerBuffer()
            };
            yield return response.SendWebRequest();

            if (response.result == UnityWebRequest.Result.ConnectionError || response.result == UnityWebRequest.Result.ProtocolError)
            {
                ParseHttpErrorToConsole(response.responseCode, response.error);
                yield break;
            }

            searchAutoInfo.data = JsonConvert.DeserializeObject<List<SearchAutocomplete>>(response.downloadHandler.text);
            searchAutoInfo.HasCompletedOnce();

            string debugOutput = "";
            if (searchAutoInfo.data.Count != 0)
            {
                foreach (SearchAutocomplete searchAuto in searchAutoInfo.data)
                {
                    debugOutput += "\"" + searchAuto.name + "\" ";
                }
                Debug.Log("Finished parsing requested autocompletion data. => " + debugOutput);
            }
            Debug.Log("Finished parsing requested autocompletion data. => No result");

            StartCoroutine(RaiseDataSyncEvent());
        }
    }
}