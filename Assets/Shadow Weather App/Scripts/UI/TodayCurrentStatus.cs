using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ExtraPerry.Shadow.WeatherApp.API;
using ExtraPerry.Shadow.WeatherApp.API.SO;
using ExtraPerry.Shadow.WeatherApp.API.Model;

namespace ExtraPerry.Shadow.WeatherApp.UI
{
    public class TodayCurrentStatus : UpdatableMono
    {
        [SerializeField]
        private WeatherCurrentInfo weatherCurrentInfo;
        [SerializeField]
        private UnitChoiceInfo unitChoiceInfo;

        [SerializeField]
        private TMP_Text city;
        [SerializeField]
        private TMP_Text countryAndRegion;
        [SerializeField]
        private TMP_Text temp;
        [SerializeField]
        private Image image;

        private void Awake()
        {
            city.text = "Data not Available";
            countryAndRegion.text = "NA";
            temp.text = "NA";
            image.sprite = Utility.GetImageSprite(1000, true);
        }

        public override void TriggerUpdate(Component sender, object data)
        {
            if (sender is WeatherCurrentRequester)
            {
                ResetRetryAttempts();
                TriggerUpdate();
            }
        }

        public override void TriggerUpdate()
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

            bool unitChoice = unitChoiceInfo.choice == UnitChoice.Metric;

            WeatherCurrent data = weatherCurrentInfo.data;
            city.text = data.location.name;
            countryAndRegion.text = data.location.country + " - " + data.location.region;
            temp.text = (unitChoice) ? data.current.temp_c + " °C" : data.current.temp_f + " °F";
            image.sprite = Utility.GetImageSprite(data.current.condition.code, data.current.is_day == 1);
        }
    }
}