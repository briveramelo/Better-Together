using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(AudioActivator))]
public class AudioActivator_Editor : Activator_Editor {
	
	public SerializedProperty
		AudioSourcePlayer_Prop,
		EnterSound_Prop,
		StayLoopSound_Prop,
		ExitSound_Prop;

	public string audioSourcePlayer = "audioSourcePlayer";
	public string enterSound = "enterSound";
	public string stayLoopSound = "stayLoopSound";
	public string exitSound = "exitSound";
	
	protected override void OnEnable(){
		base.OnEnable();
		AudioSourcePlayer_Prop = serializedObject.FindProperty(audioSourcePlayer);
		EnterSound_Prop = serializedObject.FindProperty(enterSound);
		StayLoopSound_Prop = serializedObject.FindProperty(stayLoopSound);
		ExitSound_Prop = serializedObject.FindProperty(exitSound);
	}
	
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		EditorGUILayout.PropertyField(AudioSourcePlayer_Prop);
		EditorGUILayout.PropertyField(EnterSound_Prop);
		EditorGUILayout.PropertyField(StayLoopSound_Prop);
		EditorGUILayout.PropertyField(ExitSound_Prop);
		serializedObject.ApplyModifiedProperties();
	}
}