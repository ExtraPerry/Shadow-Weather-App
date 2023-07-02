using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
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
            TriggerNow();
        }
    }

    public void TriggerNow()
    {
        RaiseEvent();
        time = timerAmount;
    }

    public void RaiseEvent()
    {
        customEvent.Raise(this);
    }
}
