using UnityEngine;
using System.Collections;

public class ActivatorViaInput : MonoBehaviour {

	public string[] inputTriggers;
	public GameObject[] objectsToActivate;
	public bool oneOff;
	private bool done;
	
	void Update(){
		if (oneOff && !done || !oneOff){
			foreach (string inputString in inputTriggers){
				if (Input.GetButtonDown(inputString)){
					done = true;
					foreach (GameObject objectToActivate in objectsToActivate){
						objectToActivate.SetActive(true);
					}
				}
			}
		}
	}
}
