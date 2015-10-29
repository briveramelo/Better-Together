#region Declaration (Inherits from Activator)
using UnityEngine;
using System.Collections;
using GenericFunctions;

public class GameObjectActivator : Activator {
#endregion

	#region initialize variables
	public GameObject[] gameObjectsToActivate;
	#endregion

	#region Activate GameObjects
	protected override void ActivateObjects(){
		if (noise){
			noise.Play();
		}
		done = true;
		foreach (GameObject gameObjectToActivate in gameObjectsToActivate){
			gameObjectToActivate.SetActive(activateOnTrigger);
		}
	}
	#endregion
}
