using System;
using Newtonsoft.Json;

namespace ExtraPerry.Shadow.WeatherApp.API.Model
{
    [Serializable]
    public struct Alert
    {
        public Alert(string headline, string msgtype, string severity, string urgency, string areas, string category, string certainty, string @event, string note, DateTime effective, DateTime expires, string desc, string instruction)
        {
            this.headline = headline;
            this.msgtype = msgtype;
            this.severity = severity;
            this.urgency = urgency;
            this.areas = areas;
            this.category = category;
            this.certainty = certainty;
            this.@event = @event;
            this.note = note;
            this.effective = effective;
            this.expires = expires;
            this.desc = desc;
            this.instruction = instruction;
        }

        [JsonProperty("headline")]
        public string headline { get; set; }

        [JsonProperty("msgtype")]
        public string msgtype { get; set; }

        [JsonProperty("severity")]
        public string severity { get; set; }

        [JsonProperty("urgency")]
        public string urgency { get; set; }

        [JsonProperty("areas")]
        public string areas { get; set; }

        [JsonProperty("category")]
        public string category { get; set; }

        [JsonProperty("certainty")]
        public string certainty { get; set; }

        [JsonProperty("event")]
        public string @event { get; set; }

        [JsonProperty("note")]
        public string note { get; set; }

        [JsonProperty("effective")]
        public DateTime effective { get; set; }

        [JsonProperty("expires")]
        public DateTime expires { get; set; }

        [JsonProperty("desc")]
        public string desc { get; set; }

        [JsonProperty("instruction")]
        public string instruction { get; set; }
    }
}