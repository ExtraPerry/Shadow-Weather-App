using System.Collections;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(UpdatableMono), true)]
public class UpdatableMonoEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		UpdatableMono mono = (UpdatableMono)target;

		if (GUILayout.Button("Update"))
		{
				mono.TriggerUpdate();
		}
	}
}
