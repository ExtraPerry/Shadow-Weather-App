using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TodayCurrentStatus : UpdatableMono
{
    [SerializeField]
    private WeatherCurrentInfo weatherCurrentInfo;

    [SerializeField]
    private TMP_Text city;
    [SerializeField]
    private TMP_Text countryAndRegion;
    [SerializeField]
    private TMP_Text temp;
    [SerializeField]
    private Image image;

    private void Awake()
    {
        city.text = "Data not Available";
        countryAndRegion.text = "NA";
        temp.text = "NA";
        image.sprite = WeatherApiUtility.GetImageSprite(1000, true);
    }

    public override void TriggerUpdate(Component sender, object data)
    {
        if (sender is WeatherCurrentRequester)
        {
            ResetRetryAttempts();
            TriggerUpdate();
        }
    }

    public override void TriggerUpdate()
    {
        if (weatherCurrentInfo is null)
        {
            Debug.LogError("\"Weather Current Info\" is not assigned in \"" + gameObject.name + "\" inspector window.");
            return;
        }
        if (!weatherCurrentInfo.IsCompletedOnce())
        {
            StartCoroutine(RetryAttempt());
            return;
        }

        WeatherCurrent data = weatherCurrentInfo.data;
        city.text = data.location.name;
        countryAndRegion.text = data.location.country + " - " + data.location.region;
        temp.text = data.current.feelslike_c + " C°";
        image.sprite = WeatherApiUtility.GetImageSprite(data.current.condition.code, data.current.is_day == 1);
    }
}