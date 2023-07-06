using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using ExtraPerry.Shadow.WeatherApp.Synced;
using ExtraPerry.Shadow.WeatherApp.Event;
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
    public class IPGrabber : UpdatableMono
    {
        [SerializeField]
        private IPInfo ipData;
        [SerializeField]
        private SyncedString targetCity;
        [SerializeField]
        private CustomEvent ipGrabberFinished;

        private void Start()
        {
            TriggerUpdate();
        }

        public override void TriggerUpdate()
        {
            Debug.Log("IpGrabber preparing to fetch api data.");
            StartCoroutine(GrabIp());
        }

        private IEnumerator GrabIp()
        {
            var response = new UnityWebRequest("http://ip-api.com/json")
            {
                downloadHandler = new DownloadHandlerBuffer()
            };
            yield return response.SendWebRequest();

            if (response.result == UnityWebRequest.Result.ConnectionError || response.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("Something went wrong while trying to connect to the api. Htttp code : " + response.responseCode);
                yield break;
            }

            ipData.data = JsonConvert.DeserializeObject<IP>(response.downloadHandler.text);
            ipData.HasCompletedOnce();

            if (targetCity.value == null || targetCity.value == "") targetCity.value = ipData.data.city;

            ipGrabberFinished.Raise(this);
            Debug.Log("Ip address has been retrieved => " + ipData.data.query);
        }
    }
}