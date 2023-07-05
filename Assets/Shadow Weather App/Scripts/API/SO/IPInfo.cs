using UnityEngine;
using ExtraPerry.Shadow.WeatherApp.API.Model;

namespace ExtraPerry.Shadow.WeatherApp.API.SO
{
    [CreateAssetMenu(menuName = "Shadow Weather App/API SO/IP Info")]
    public class IPInfo : Info
    {
        public IP data;
    }
}