using UnityEngine;
using System.Collections;
using GenericFunctions;

public class GameObjectActivator : MonoBehaviour {

	public enum TriggerType{
		Input,
		Collision,
		TriggerCollider,
	}
	public TriggerType triggerType;
	public GameObject[] objectsToActivate;
	public string[] inputStrings;
	public bool activateOnTrigger;
	public bool oneOff;
	public AudioSource noise;

	private bool done;

	void OnCollisionEnter(Collision col){
		if (triggerType == TriggerType.Collision){
			if (oneOff && !done || !oneOff){
				ActivateGameObjects();
			}
		}
	}

	void OnTriggerEnter(Collider col){
		if (triggerType == TriggerType.TriggerCollider){
			if (col.gameObject.layer == Layers.player){
				if (oneOff && !done || !oneOff){
					ActivateGameObjects();
				}
			}
		}
	}

	void Update(){
		if (triggerType == TriggerType.Input){
			if (oneOff && !done || !oneOff){
				foreach (string inputString in inputStrings){
					if (Input.GetButtonDown(inputString)){
						ActivateGameObjects();
					}
				}
			}
		}
	}

	void ActivateGameObjects(){
		if (noise){
			noise.Play();
		}
		done = true;
		foreach (GameObject objectToActive in objectsToActivate){
			objectToActive.SetActive(activateOnTrigger);
		}
	}
}
