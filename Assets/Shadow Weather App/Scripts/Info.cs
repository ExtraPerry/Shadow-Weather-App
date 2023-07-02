using UnityEngine;

public class Info : ScriptableObject
{
    private bool isCompletedOnce = false;

    public bool IsCompletedOnce()
    {
        return isCompletedOnce;
    }

    public void HasCompletedOnce()
    {
        isCompletedOnce = true;
    }
}
