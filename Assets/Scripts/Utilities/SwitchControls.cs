using UnityEngine;
using System.Collections;
using GenericFunctions;
public class SwitchControls : MonoBehaviour {

	public bool switchTHEM;
	void Update(){
		if (switchTHEM){
			switchTHEM = false;
			GameManager.StaticControls.P1_Controls = GameManager.StaticControls.P1_Controls.Action == "P1_Action" ?
				GameManager.theInstance.p2 : GameManager.theInstance.p1;
			Players.explo.BroadcastMessage("GetCurrentControls",SendMessageOptions.DontRequireReceiver);
			Players.implo.BroadcastMessage("GetCurrentControls",SendMessageOptions.DontRequireReceiver);
		}
	}
}
