using UnityEngine;
using ExtraPerry.Shadow.WeatherApp.UI;

namespace ExtraPerry.Shadow.WeatherApp.Event
{
    public class Timer : UpdatableMono
    {
        [SerializeField]
        private CustomEvent customEvent;
        [SerializeField]
        private float timerAmount = 600; // 600s <=> 10min

        [SerializeField]
        private float time = 0;

        private void Awake()
        {
            time = timerAmount;
        }

        private void Update()
        {
            time -= Time.deltaTime;

            if (time <= 0)
            {
                TriggerUpdate();
            }
        }

        public override void TriggerUpdate(Component sender, object data)
        {
            if (sender is SearchInputManager || sender is ApiKeyInputManager) TriggerUpdate();
        }

        public override void TriggerUpdate()
        {
            time = timerAmount;
            RaiseEvent();
        }

        public void RaiseEvent()
        {
            customEvent.Raise(this);
        }
    }
}