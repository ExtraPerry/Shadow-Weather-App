using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApiData : ScriptableObject
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
}
