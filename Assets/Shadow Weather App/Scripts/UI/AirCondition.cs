using UnityEngine;
using TMPro;

public class AirCondition : UpdatableMono
{
    [SerializeField]
    private WeatherCurrentInfo weatherCurrentInfo;
    [SerializeField]
    private WeatherForecastInfo weatherForecastInfo;

    [SerializeField]
    private TMP_Text realFeel;
    [SerializeField]
    private TMP_Text chanceOfRain;
    [SerializeField]
    private TMP_Text cloud;
    [SerializeField]
    private TMP_Text humidity;
    [SerializeField]
    private TMP_Text wind;
    [SerializeField]
    private TMP_Text windDirection;
    [SerializeField]
    private TMP_Text visibility;
    [SerializeField]
    private TMP_Text uvIndex;

    private void Awake()
    {
        string unknown = "NA";
        realFeel.text = unknown;
        cloud.text = unknown;
        humidity.text = unknown;
        wind.text = unknown;
        windDirection.text = unknown;
        visibility.text = unknown;
        uvIndex.text = unknown;
        chanceOfRain.text = unknown;
    }

    public override void TriggerUpdate(Component sender, object data)
    {
        if (sender is WeatherCurrentRequester)
        {
            ResetRetryAttempts();
            UpdateCurrentWeatherDisplays();
        }
        if (sender is WeatherForecastRequester)
        {
            ResetRetryAttempts();
            UpdateForecastWeatherDisplays();
        }
    }

    public override void TriggerUpdate()
    {
        UpdateCurrentWeatherDisplays();
        UpdateForecastWeatherDisplays();
    }

    private void UpdateCurrentWeatherDisplays()
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
        Current current = weatherCurrentInfo.data.current;
        realFeel.text = current.feelslike_c.ToString() + " C°";
        cloud.text = current.cloud.ToString() + " %";
        humidity.text = current.humidity.ToString() + " %";
        wind.text = current.wind_kph.ToString() + " kph";
        windDirection.text = current.wind_dir;
        visibility.text = current.vis_km.ToString() + " km";
        uvIndex.text = current.uv.ToString();
    }

    private void UpdateForecastWeatherDisplays()
    {
        if (weatherForecastInfo is null)
        {
            Debug.LogError("\"Weather Forecast Info\" is not assigned in \"" + gameObject.name + "\" inspector window.");
            return;
        }
        

        Forecastday today = null;
        foreach (Forecastday day in weatherForecastInfo.data.forecast.forecastday)
        {
            if (today is null || today.date_epoch > day.date_epoch) today = day;
        }
        Hour now = null;
        foreach (Hour hour in today.hour)
        {
            if (now is null || now.time_epoch > hour.time_epoch) now = hour;
        }
        chanceOfRain.text = now.will_it_rain.ToString() + " %";
    }
}
