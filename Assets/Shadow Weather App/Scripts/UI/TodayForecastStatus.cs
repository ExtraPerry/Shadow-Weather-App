using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TodayForecastStatus : UpdatableMono
{
    [SerializeField]
    private WeatherForecastInfo weatherForecastInfo;
    [SerializeField]
    private HourForecastStatusSection[] sections = new HourForecastStatusSection[6];

    private Hour[] hourlyForecast;
    [SerializeField][Range(0, 17)]
    private int offset = 0;

    private void Awake()
    {
        foreach (HourForecastStatusSection section in sections)
        {
            section.title.text = "NA:NA";
            section.icon.sprite = WeatherApiUtility.GetIconSprite(1000, true);
            section.info.text = "NA";
        }
    }

    public override void TriggerUpdate(Component sender, object data)
    {
        if (sender is WeatherForecastRequester)
        {
            ResetRetryAttempts();
            TriggerUpdate();
        }
    }

    public override void TriggerUpdate()
    {
        if (weatherForecastInfo is null)
        {
            Debug.LogError("\"Weather Forecast Info\" is not assigned in \"" + gameObject.name + "\" inspector window.");
            return;
        }
        if (!weatherForecastInfo.IsCompletedOnce())
        {
            StartCoroutine(RetryAttempt());
            return;
        }

        // In this use case the weather api always provides Lists ordered from : past -> future.
        List<Forecastday> data = weatherForecastInfo.data.forecast.forecastday;
        long currentEpoch = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        List<Hour> forecast48H = new List<Hour>();

        int count = 1;
        foreach (Forecastday day in data)
        {
            List<Hour> hours = day.hour;
            foreach (Hour hour in hours)
            {
                if (hour.time_epoch * 1000 >= currentEpoch)
                {
                    forecast48H.Add(hour);
                }
            }
            // I'm only interested in the next 48h starting from today 00h00 to tomorrow 23h00 in order to make a 24H forecast. But exclude hours that have past.
            if (count >= 2) break;
            count++;
        }

        hourlyForecast = forecast48H.ToArray();
        UpdateDisplays();
    }

    private void UpdateDisplays()
    {
        if (hourlyForecast is null || hourlyForecast.Length == 0) return;

        for(int i = 0; i < sections.Length; i++)
        {
            Hour hour;
            try
            {
                hour = hourlyForecast[i + offset];
            }
            catch(Exception e)
            {
                Debug.LogError(e);
                return;
            }
            
            sections[i].title.text = hour.time.Substring(10);
            sections[i].icon.sprite = WeatherApiUtility.GetIconSprite(hour.condition.code, hour.is_day == 1);
            sections[i].info.text = hour.temp_c + " C°";
        }
    }

    public void UpdateOffsetSlider(float target)
    {
        int oldOffset = offset;
        int newOffset = (int)Mathf.Lerp(0, 17, target);
        Debug.Log("Target : " + target + " | Old : " + oldOffset + " | New : " + newOffset);
        if (oldOffset == newOffset) return;
        offset = newOffset;
        UpdateDisplays();
    }

    public void UpdateOffsetButton(int amount)
    {
        offset += amount;
        if (offset < 0) offset = 0;
        if (offset > 17) offset = 17;
        UpdateDisplays();
    }

#if UNITY_EDITOR
    // This is only meant to refresh the offset.
    // You'll still need to press the update button to get the latests paged api data.
    // Note : the paged api data will only update itself if you update the relative api requester.
    private void OnValidate()
    {
        UpdateDisplays();
    }
#endif
}

[Serializable]
public class HourForecastStatusSection
{
    public TMP_Text title;
    public Image icon;
    public TMP_Text info;
}
