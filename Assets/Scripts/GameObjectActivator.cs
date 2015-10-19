using UnityEngine;
using System.Collections;
using GenericFunctions;

public class GameObjectActivator : MonoBehaviour {

	public GameObject[] objectsToActivate;
	public bool oneOff;
	private bool done;

	void OnTriggerEnter(Collider col){
		if (col.gameObject.layer == Layers.player){
			if (oneOff && !done || !oneOff){
				done = true;
				foreach (GameObject objectToActive in objectsToActivate){
					objectToActive.SetActive(true);
				}
			}
		}
	}
}
