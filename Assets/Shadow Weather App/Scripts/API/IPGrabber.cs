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

public class IPGrabber : UpdatableMono
{
    [SerializeField]
    private IPInfo ipData;

    private void Awake()
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

        Debug.Log("Ip address has been retrieved => " + ipData.data.query);
    }
}
