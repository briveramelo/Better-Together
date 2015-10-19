using UnityEngine;
using System.Collections;
using GenericFunctions;
public class RestartLevel : MonoBehaviour {

	public Controls controls_Explo;
	public Controls controls_Implo;

	// Update is called once per frame
	void Update () {
		if (controls_Explo && controls_Implo){
			if (Input.GetButton(controls_Explo.Restart) && Input.GetButton(controls_Implo.Restart)){
				Application.LoadLevel(Application.loadedLevelName);
			}
		}
		else{
			controls_Explo = StaticControls.controls_Explo;
			controls_Implo = StaticControls.controls_Implo;
		}
	}
}
