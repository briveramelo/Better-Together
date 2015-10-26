using UnityEngine;
using System.Collections;
using GenericFunctions;

public class GameObjectActivator : Activator {

	public GameObject[] gameObjectsToActivate;

	protected override void ActivateObjects(){
		if (noise){
			noise.Play();
		}
		done = true;
		foreach (GameObject gameObjectToActivate in gameObjectsToActivate){
			gameObjectToActivate.SetActive(activateOnTrigger);
		}
	}
}
