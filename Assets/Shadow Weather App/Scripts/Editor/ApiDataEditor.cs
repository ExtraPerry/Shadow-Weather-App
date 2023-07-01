using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ApiInfo), true)]
public class SerializedDataEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		ApiInfo apiData = (ApiInfo)target;

		if (GUILayout.Button("Reset"))
		{
			apiData.Reset();
		}
	}
}
