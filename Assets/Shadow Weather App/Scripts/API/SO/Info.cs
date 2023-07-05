using UnityEngine;

namespace ExtraPerry.Shadow.WeatherApp.API.SO
{
    public class Info : ScriptableObject
    {
        protected bool isCompletedOnce = false;

        public bool IsCompletedOnce()
        {
            return isCompletedOnce;
        }

        public void HasCompletedOnce()
        {
            isCompletedOnce = true;
        }
    }
}