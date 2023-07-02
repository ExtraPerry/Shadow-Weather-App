using System.Collections;
using UnityEngine;

public class WeatherRequester : UpdatableMono
{
    [SerializeField]
    private CustomEvent dataSync;
    public string apiKey;

    protected void ParseHttpErrorToConsole(long code, string error)
    {
        switch (code)
        {
            case 400:
                Debug.LogError("Url request for \"weatherapi.com\" was invalid.\n" + error);
                break;
            case 401:
                Debug.LogError("Api key is not valid for \"weatherapi.com\". Please provide a valid api key for : \"" + gameObject.name + "\" GameObject in the \"WeatherApiRequester\" script.\n" + error);
                break;
            case 403:
                Debug.LogError("Api key is has exeeded quota or is disabled for \"weatherapi.com\". Please provide a valid api key for : \"" + gameObject.name + "\" GameObject in the \"WeatherApiRequester\" script.\n" + error);
                break;
            default:
                Debug.LogError("Unexpected error for \"weatherapi.com\" => http " + code + ".\n" + error);
                break;
        }
    }

    protected IEnumerator RaiseDataSyncEvent()
    {
        yield return new WaitForSeconds(2f);
        dataSync.Raise(this);
    }
}
