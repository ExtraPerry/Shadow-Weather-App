using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApiInfo : ScriptableObject
{
    private bool isCompletedOnce = false;

    public bool GetIsCompletedOnce()
    {
        return isCompletedOnce;
    }

    public void hasCompletedOnce()
    {
        isCompletedOnce = true;
    }

    public virtual void Reset()
    {

    }
}
