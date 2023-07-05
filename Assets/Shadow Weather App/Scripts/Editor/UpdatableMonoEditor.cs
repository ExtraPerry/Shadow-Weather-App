using System.Collections;
using UnityEngine;
using UnityEditor;
using ExtraPerry.Shadow.WeatherApp;

[CustomEditor(typeof(UpdatableMono), true)]
public class UpdatableMonoEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		UpdatableMono mono = (UpdatableMono)target;

		if (GUILayout.Button("Update"))
		{
			Debug.Log("Manually updating " + mono.name + " in Editor.");
			mono.TriggerUpdate();
		}
	}
}
