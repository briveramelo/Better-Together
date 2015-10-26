using UnityEngine;
using System.Collections;
using GenericFunctions;

public class ScriptActivator : Activator {

	public MonoBehaviour[] scriptsToActivate;
	
	protected override void ActivateObjects(){
		if (noise){
			noise.Play();
		}
		done = true;
		foreach (MonoBehaviour scriptToActivate in scriptsToActivate){
			if (scriptToActivate){
				scriptToActivate.enabled = activateOnTrigger;
			}
		}
	}
}
