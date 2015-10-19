using UnityEngine;
using System.Collections;

public class ObjectDeActivator : MonoBehaviour {
	

	public string[] inputTriggers;
	public GameObject[] objectsToDeactive;
	public bool oneOff;
	private bool done;

	void Update(){
		if (oneOff && !done || !oneOff){
			foreach (string inputString in inputTriggers){
				if (Input.GetButtonDown(inputString)){
					done = true;
					foreach (GameObject objectToDeActive in objectsToDeactive){
						objectToDeActive.SetActive(false);
					}
				}
			}
		}
	}
}
