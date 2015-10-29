#region Declaration
using UnityEngine;
using System.Collections;
using GenericFunctions;

public class ScriptActivator : Activator {
#endregion

	#region Intialize Variables
	public MonoBehaviour[] scriptsToActivate;
	#endregion

	#region Activate Scripts!
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
	#endregion
}
