using UnityEngine;

namespace ExtraPerry.Shadow.WeatherApp.Synced
{
    [CreateAssetMenu(menuName = "Shadow Weather App/Synced/String")]
    public class SyncedString : ScriptableObject
    {
        public string value;

        private void Awake()
        {
            value = null;
        }
    }
}