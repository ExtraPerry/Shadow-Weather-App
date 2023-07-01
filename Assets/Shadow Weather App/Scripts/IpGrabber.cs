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

public class IpGrabber : UpdatableMono
{
    private IpInfo ipData;

    private void Awake()
    {
        TriggerUpdate();
    }

    public override void TriggerUpdate()
    {
        print("IpGrabber preparing to fetch api data.");
        StartCoroutine(GrabIp());
    }

    IEnumerator GrabIp()
    {
        var response = new UnityWebRequest("http://ip-api.com/json")
        {
            downloadHandler = new DownloadHandlerBuffer()
        };
        yield return response.SendWebRequest();

        if (response.result == UnityWebRequest.Result.ConnectionError || response.result == UnityWebRequest.Result.ProtocolError)
        {
            print("Something went wrong while trying to connect to the api.");
            yield break;
        }

        IpData myDeserializedClass = JsonConvert.DeserializeObject<IpData>(response.downloadHandler.text);
        ipData.data = myDeserializedClass;

        ipData.hasCompletedOnce();
        print("Ip address has been retrieved => " + ipData.data.query);
    }
}
