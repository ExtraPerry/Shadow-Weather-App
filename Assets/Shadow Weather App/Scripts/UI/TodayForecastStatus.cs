using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ExtraPerry.Shadow.WeatherApp.API;
using ExtraPerry.Shadow.WeatherApp.API.SO;
using ExtraPerry.Shadow.WeatherApp.API.Model;

namespace ExtraPerry.Shadow.WeatherApp.UI
{
    public class TodayForecastStatus : UpdatableMono
    {
        [SerializeField]
        private WeatherForecastInfo weatherForecastInfo;
        [SerializeField]
        private UnitChoiceInfo unitChoiceInfo;

        [SerializeField]
        private HourForecastStatusSection[] sections = new HourForecastStatusSection[6];

        private Hour[] hourlyForecast;
        [SerializeField]
        [Range(0, 17)]
        private int offset = 0;

        private void Awake()
        {
            foreach (HourForecastStatusSection section in sections)
            {
                section.title.text = "NA:NA";
                section.icon.sprite = Utility.GetIconSprite(1000, true);
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

            bool unitChoice = unitChoiceInfo.choice == UnitChoice.Metric;

            for (int i = 0; i < sections.Length; i++)
            {
                Hour hour;
                try
                {
                    hour = hourlyForecast[i + offset];
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                    return;
                }

                string timeStr;
                if (unitChoice)
                {
                    timeStr = hour.time.Substring(11);
                }
                else
                {
                    string str1 = hour.time.Substring(11, 2);
                    string str2 = hour.time.Substring(14, 2);
                    int num = int.Parse(str1);
                    timeStr = (num <= 12) ? num + ":" + str2 + " AM" : (num - 12).ToString() + ":" + str2 + " PM";
                }
                sections[i].title.text = timeStr;
                sections[i].icon.sprite = Utility.GetIconSprite(hour.condition.code, hour.is_day == 1);
                sections[i].info.text = (unitChoice) ? hour.temp_c + " °C" : hour.temp_f + " °F";
            }
        }

        public void UpdateOffsetSlider(float target)
        {
            int oldOffset = offset;
            target = Mathf.Clamp(target, 0, 1);
            int newOffset = (int)Mathf.Lerp(0, 18, target);
            // Debug.Log("Target : " + target + " | Old : " + oldOffset + " | New : " + newOffset);
            if (oldOffset == newOffset) return;
            offset = newOffset;
            UpdateDisplays();
        }

        public void UpdateOffsetButton(int amount)
        {
            offset += amount;
            if (offset < 0) offset = 0;
            if (offset > 18) offset = 18;
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
}
