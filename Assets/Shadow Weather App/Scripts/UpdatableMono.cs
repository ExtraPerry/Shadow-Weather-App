using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatableMono : MonoBehaviour
{
    private int retryAttemptCount = 0;

    public virtual void TriggerUpdate(Component sender, object data)
    {
        if (sender is Timer)
        {
            ResetRetryAttempts();
            TriggerUpdate();
        }
    }

    public virtual void TriggerUpdate()
    {

    }

    protected IEnumerator RetryAttempt()
    {
        if (retryAttemptCount > 2) 
        {
            Debug.LogWarning("To many attemps to update \"" + gameObject.name + "\" no longer trying.");
            yield break;
        }
        Debug.LogWarning("Failed to update \"" + gameObject.name + "\" trying again for " + retryAttemptCount + "x in 1s.");
        yield return new WaitForSeconds(1f);
        retryAttemptCount++;
        TriggerUpdate();
    }

    protected void ResetRetryAttempts()
    {
        retryAttemptCount = 0;
    }
}
