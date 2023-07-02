using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeeklyForecastStatus : UpdatableMono
{
    [SerializeField]
    private WeatherForecastInfo weatherForecastInfo;
    [SerializeField]
    private DayForecastStatusSection[] sections = new DayForecastStatusSection[7];

    private SelectType selectType = SelectType.Average;

    private void Awake()
    {
        foreach (DayForecastStatusSection section in sections)
        {
            section.title.text = "NA:NA";
            section.icon.sprite = WeatherApiUtility.GetIconSprite(1000, true);
            section.info.text = "NA";
            section.info.text = "NA/NA";
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
        // Also since we are always requesting exactly 7 days of forecast the list is always 7 long.
        List<Forecastday> data = weatherForecastInfo.data.forecast.forecastday;

        int count = 0;
        foreach (Forecastday forecast in data)
        {
            DateTimeOffset time = new DateTimeOffset(DateTime.Now).AddDays(count);
            sections[count].title.text = (count == 0) ? "Today" : time.DayOfWeek.ToString();
            sections[count].icon.sprite = WeatherApiUtility.GetIconSprite(forecast.day.condition.code, true);
            sections[count].date.text = ((time.Day.ToString().Length == 1) ? "0" + time.Day : time.Day) + "/" + ((time.Month.ToString().Length == 1) ? "0" + time.Month : time.Month);

            switch (selectType)
            {
                case SelectType.Maximum:
                    sections[count].info.text = forecast.day.maxtemp_c + " C°";
                    break;
                case SelectType.Minimum:
                    sections[count].info.text = forecast.day.mintemp_c + " C°";
                    break;
                default:
                    sections[count].info.text = forecast.day.avgtemp_c + " C°";
                    break;
            }

            if (count >= 6) break;
            count++;
        }
    }

    public void SetSelectType(int selection)
    {
        selectType = (SelectType)selection;
        TriggerUpdate();
    }
}

[Serializable]
public class DayForecastStatusSection
{
    public TMP_Text title;
    public Image icon;
    public TMP_Text info;
    public TMP_Text date;
}

public enum SelectType
{
    Average,
    Maximum,
    Minimum
}
