using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CustomUnityEvent : UnityEvent<Component, object>
{
    // . . .
}

public class CustomEventListener : MonoBehaviour
{
    // The event that you want to listen to.
    public CustomEvent customEvent;
    // The answer to said event.
    public CustomUnityEvent response;

    private void OnEnable()
    {
        customEvent.RegisterListener(this);
    }
    
    private void OnDisable()
    {
        customEvent.UnregisterListener(this);
    }

    public void OnEventRaised(Component sender, object data)
    {
        response.Invoke(sender, data);
    }
}
