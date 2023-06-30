using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class IpGrabber : UpdatableMono
{
    [SerializeField]
    private IpData ipData;

    private void Start()
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

        JSONNode ipJsonData = JSON.Parse(response.downloadHandler.text);
        if (ipJsonData["query"] == "fail")
        {
            print("Api failed but connection was succesful.");
            yield break;
        }
        // Assign json data to ipdata.
        ipData.ip = ipJsonData["query"];
        ipData.country = ipJsonData["country"];
        ipData.countryCode = ipJsonData["countryCode"];
        ipData.region = ipJsonData["region"];
        ipData.regionName = ipJsonData["regionName"];
        ipData.city = ipJsonData["city"];
        ipData.lat = ipJsonData["lat"];
        ipData.lon = ipJsonData["lon"];
        ipData.timezone = ipJsonData["timezone"];
        // Update the status of the ipData to : a valid set of information is available.
        ipData.hasCompletedOnce();
        print("Ip address has been retrieved => " + ipData.ip);
    }
}
