using UnityEngine;
using ExtraPerry.Shadow.WeatherApp.API.Model;

namespace ExtraPerry.Shadow.WeatherApp.API.SO
{
    [CreateAssetMenu(menuName = "Shadow Weather App/API SO/Weather Future Info")]
    public class WeatherFutureInfo : Info
    {
        public WeatherFuture data;
    }
}