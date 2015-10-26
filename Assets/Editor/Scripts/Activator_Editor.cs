using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(Activator))]
[CanEditMultipleObjects]
public class Activator_Editor: Editor{
	public SerializedProperty
		TriggerType_Prop,
		DependsOnPlayerType_Prop,
		PlayerType_Prop,
		InputButton_Prop,
		ActivateOnTrigger_Prop,
		OneOff_Prop,
		Noise_Prop;

	#region property names
	private string triggerType = "triggerType";
	private string dependsOnPlayerType = "dependsOnPlayerType";
	private string playerType = "playerType";
	private string inputButton = "inputButton";
	private string activateOnTrigger = "activateOnTrigger";
	private string oneOff = "oneOff";
	private string noise = "noise";
	#endregion

	protected virtual void OnEnable(){
		TriggerType_Prop = serializedObject.FindProperty(triggerType);
		DependsOnPlayerType_Prop = serializedObject.FindProperty(dependsOnPlayerType);
		PlayerType_Prop = serializedObject.FindProperty(playerType);
		InputButton_Prop = serializedObject.FindProperty(inputButton);
		ActivateOnTrigger_Prop  = serializedObject.FindProperty(activateOnTrigger);
		OneOff_Prop = serializedObject.FindProperty(oneOff);
		Noise_Prop = serializedObject.FindProperty(noise);
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		EditorGUILayout.PropertyField(TriggerType_Prop);

		#region If Player Type Matters
		bool showPlayerChoice = DependsOnPlayerType_Prop.boolValue;
		if (showPlayerChoice){
			EditorGUILayout.PropertyField(PlayerType_Prop);
		}
		#endregion

		EditorGUILayout.PropertyField(DependsOnPlayerType_Prop);

		#region If Input Required
		int triggerTypeCount = (int)TriggerType_Prop.enumValueIndex;
		if (triggerTypeCount == (int)TriggerType.Input ||
		    triggerTypeCount == (int)TriggerType.InputAndOnTriggerStay){
			
			EditorGUILayout.PropertyField(InputButton_Prop);
		}
		#endregion

		EditorGUILayout.PropertyField(ActivateOnTrigger_Prop);
		EditorGUILayout.PropertyField(OneOff_Prop);
		EditorGUILayout.PropertyField(Noise_Prop);

		serializedObject.ApplyModifiedProperties();
	}
}
