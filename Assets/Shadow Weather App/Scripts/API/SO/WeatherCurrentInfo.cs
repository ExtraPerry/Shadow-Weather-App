using UnityEngine;
using ExtraPerry.Shadow.WeatherApp.API.Model;

namespace ExtraPerry.Shadow.WeatherApp.API.SO
{
[CreateAssetMenu(menuName = "Shadow Weather App/API SO/Weather Current Info")]
    public class WeatherCurrentInfo : Info
    {
        public WeatherCurrent data;
    }
}