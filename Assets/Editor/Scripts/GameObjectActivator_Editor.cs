using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(GameObjectActivator))]
public class GameObjectActivator_Editor : Activator_Editor {

	public SerializedProperty GameObjectsToActivate_Prop;
	private string gameObjectsToActivate = "gameObjectsToActivate";


	protected override void OnEnable(){
		base.OnEnable();
		GameObjectsToActivate_Prop = serializedObject.FindProperty(gameObjectsToActivate);
	}

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		EditorGUILayout.PropertyField(GameObjectsToActivate_Prop, true);
		serializedObject.ApplyModifiedProperties();
	}
}
