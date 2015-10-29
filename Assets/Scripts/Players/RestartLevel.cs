using UnityEngine;
using System.Collections;
using GenericFunctions;
public class RestartLevel : MonoBehaviour {

	void Update () {
		if (Input.GetButton(GameManager.StaticControls.P1_Controls.Restart) &&
		    Input.GetButton(GameManager.StaticControls.P2_Controls.Restart)){
			Levels.LoadLevel(LevelNames.Current);
		}
	}
}
