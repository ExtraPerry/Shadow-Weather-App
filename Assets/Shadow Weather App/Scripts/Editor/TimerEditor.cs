using System.Collections;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Timer), true)]
public class TimerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Timer mono = (Timer)target;

        if (GUILayout.Button("Trigger Now"))
        {
            Debug.Log("Manually updating " + mono.name + " Timer in Editor.");
            mono.TriggerNow();
        }
    }
}