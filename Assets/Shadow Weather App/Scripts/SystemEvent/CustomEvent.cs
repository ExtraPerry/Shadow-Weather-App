using System.Collections.Generic;
using UnityEngine;

namespace ExtraPerry.Shadow.WeatherApp.Event
{
    [CreateAssetMenu(menuName = "CustomEvent")]
    public class CustomEvent : ScriptableObject
    {
        public List<CustomEventListener> listeners = new List<CustomEventListener>();

        // Raise event through the different methods signatures.

        public void Raise(Component sender)
        {
            Raise(sender, null);
        }

        public void Raise(Component sender, object data)
        {
            for (int i = 0; i < listeners.Count; i++)
            {
                listeners[i].OnEventRaised(sender, data);
            }
        }

        // Manage Listeners

        public void RegisterListener(CustomEventListener listener)
        {
            if (!listeners.Contains(listener))
            {
                listeners.Add(listener);
            }
        }

        public void UnregisterListener(CustomEventListener listener)
        {
            if (listeners.Contains(listener))
            {
                listeners.Remove(listener);
            }
        }
    }
}