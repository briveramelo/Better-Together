#region Declaration 
using UnityEngine;
using System.Collections;

public class Keyhole : MonoBehaviour {
#endregion

	#region Initialize Variables
	public bool[] keys;
	public bool activateOnTrigger;
	public bool forDoors;
	public MonoBehaviour[] scriptsToActivate;
	public DoorLift[] doorLiftScripts;
	public float activationTimeWindow;
	#endregion


	#region Activate Key
	public IEnumerator ActivateKey(int keyNumber){
		keys[keyNumber] = true;
		if (CheckToOpenTheDoor()){
			OpenTheDoor();
		}
		else{
			yield return new WaitForSeconds (activationTimeWindow);
			keys[keyNumber] = false;
		}
		yield return null;
	}
	#endregion

		#region Check To Open Door
	bool CheckToOpenTheDoor(){
		foreach (bool key in keys){
			if (!key){
				return false;
			}
		}
		return true;
	}
		#endregion

		#region Open The Door
	void OpenTheDoor(){
		foreach (MonoBehaviour script in scriptsToActivate){
			script.enabled = activateOnTrigger;
		}
		foreach (DoorLift doorLiftScript in doorLiftScripts){
			doorLiftScript.enabled = true;
			doorLiftScript.ResetPosition = false;
			doorLiftScript.JustOpenTheDamnDoor = true;
		}
	}
		#endregion
}
