using UnityEngine;

namespace ExtraPerry.Shadow.WeatherApp.Synced
{
    [CreateAssetMenu(menuName = "Shadow Weather App/Synced/String")]
    public class SyncedString : ScriptableObject
    {
        public string value = null;
        [SerializeField]
        private bool resetOnAwake = true;

        private void Awake()
        {
            if (resetOnAwake) value = null;
        }

        public override string ToString()
        {
            return value;
        }
    }
}