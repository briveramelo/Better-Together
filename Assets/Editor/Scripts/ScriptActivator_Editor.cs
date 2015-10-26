using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(ScriptActivator))]
public class ScriptActivator_Editor : Activator_Editor {
	
	public SerializedProperty ScriptsToActivate_Prop;
	private string scriptsToActivate = "scriptsToActivate";
	
	
	protected override void OnEnable(){
		base.OnEnable();
		ScriptsToActivate_Prop = serializedObject.FindProperty(scriptsToActivate);
	}
	
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		EditorGUILayout.PropertyField(ScriptsToActivate_Prop, true);
		serializedObject.ApplyModifiedProperties();
	}
}
