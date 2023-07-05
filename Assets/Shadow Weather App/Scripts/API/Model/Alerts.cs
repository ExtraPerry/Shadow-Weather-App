using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ExtraPerry.Shadow.WeatherApp.API.Model
{
    [Serializable]
    public struct Alerts
    {
        public Alerts(List<Alert> alert)
        {
            this.alert = alert;
        }

        [JsonProperty("alert")]
        public List<Alert> alert { get; set; }
    }
}