using UnityEngine;
using System.Collections;
using GenericFunctions;

public class ScriptActivator : MonoBehaviour {

	public TriggerType triggerType;
	public MonoBehaviour[] scriptsToActivate;
	public string[] inputStrings;
	public bool activateOnTrigger;
	public bool oneOff;
	public AudioSource noise;

	private bool done;

	void OnCollisionEnter(Collision col){
		if (enabled){
			if (triggerType == TriggerType.Collision){
				if (oneOff && !done || !oneOff){
					ActivateScripts();
				}
			}
		}
	}
	
	void OnTriggerEnter(Collider col){
		if (enabled){
			if (triggerType == TriggerType.TriggerCollider){
				if (col.gameObject.layer == Layers.player){
					if (oneOff && !done || !oneOff){
						ActivateScripts();
					}
				}
			}
		}
	}
	
	void Update(){
		if (triggerType == TriggerType.Input){
			if (oneOff && !done || !oneOff){
				foreach (string inputString in inputStrings){
					if (Input.GetButtonDown(inputString)){
						ActivateScripts();
					}
				}
			}
		}
	}

	void ActivateScripts(){
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
