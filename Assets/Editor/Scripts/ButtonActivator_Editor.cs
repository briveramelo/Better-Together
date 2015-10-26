using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(ButtonActivator))]
public class ButtonActivator_Editor : Activator_Editor {
	
	public SerializedProperty ButtonType_Prop;
	private string buttonType = "buttonType";
	
	
	protected override void OnEnable(){
		base.OnEnable();
		ButtonType_Prop = serializedObject.FindProperty(buttonType);
	}
	
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		EditorGUILayout.PropertyField(ButtonType_Prop, true);
		serializedObject.ApplyModifiedProperties();
	}
}