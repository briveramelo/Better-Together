using UnityEngine;
using System.Collections;

public class Keyhole : MonoBehaviour {

	public bool[] keys;
	public bool activateOnTrigger;
	public MonoBehaviour[] scriptsToActivate;
	public float activationTimeWindow;

	public IEnumerator ActivateKey(int keyNumber){
		keys[keyNumber] = true;
		bool openTheDoor = CheckToOpenTheDoor();
		if (openTheDoor){
			OpenTheDoor();
		}
		yield return new WaitForSeconds (activationTimeWindow);
		keys[keyNumber] = false;
	}

	bool CheckToOpenTheDoor(){
		foreach (bool key in keys){
			if (!key){
				return false;
				break;
			}
		}
		return true;
	}

	void OpenTheDoor(){
		foreach (MonoBehaviour script in scriptsToActivate){
			script.enabled = activateOnTrigger;
		}
	}
}
