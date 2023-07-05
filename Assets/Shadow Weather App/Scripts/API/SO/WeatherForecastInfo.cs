using UnityEngine;
using ExtraPerry.Shadow.WeatherApp.API.Model;

namespace ExtraPerry.Shadow.WeatherApp.API.SO
{
    [CreateAssetMenu(menuName = "Shadow Weather App/API SO/Weather Forecast Info")]
    public class WeatherForecastInfo : Info
    {
        public WeatherForecast data;
    }
}