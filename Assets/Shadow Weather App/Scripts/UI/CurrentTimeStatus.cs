using System;
using UnityEngine;
using TMPro;

namespace ExtraPerry.Shadow.WeatherApp.UI
{
    public class CurrentTimeStatus : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text zone;
        [SerializeField]
        private UnitChoice unitChoice;

        private int oldSecond;

        private void Awake()
        {
            oldSecond = DateTime.Now.Second;
        }

        private void Update()
        {
            DateTime time = DateTime.Now;

            if (time.Second != oldSecond)
            {
                string day = (time.Day.ToString().Length == 1) ? "0" + time.Day : time.Day.ToString();
                string month = (time.Month.ToString().Length == 1) ? "0" + time.Month : time.Month.ToString();
                string year = time.Day.ToString();
                string hour = (time.Hour.ToString().Length == 1) ? "0" + time.Hour : time.Hour.ToString();
                string minute = (time.Minute.ToString().Length == 1) ? "0" + time.Minute : time.Minute.ToString();
                string second = (time.Second.ToString().Length == 1) ? "0" + time.Second : time.Second.ToString();

                if (unitChoice == UnitChoice.Metric)
                {
                    zone.text = "Current Time : " + day + "/" + month + "/" + year + " - " + hour + ":" + minute + ":" + second;
                }
                else
                {
                    zone.text = "Current Time : " + month + "/" + day + "/" + year + "-" + hour + ":" + minute + ":" + second;
                }

                oldSecond = time.Second;
            }
        }
    }
}