using UnityEngine;
using System.Collections;
using GenericFunctions;
public class ButtonActivator : MonoBehaviour {

	public enum TriggerType{
		Input,
		Collision,
		TriggerCollider,
		InputAndTrigger
	}
	public bool dependsOnPlayerType;
	public PlayerType playerType;
	public TriggerType triggerType;
	public string[] objectsToActivate;
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
				if (!dependsOnPlayerType || col.GetComponent<TypeOfPlayer>().PlayerType == playerType){
					if (oneOff && !done || !oneOff){
						ActivateGameObjects();
					}
				}
			}
		}
	}
	
	void OnTriggerStay(Collider col){
		if (triggerType == TriggerType.InputAndTrigger){
			if (col.gameObject.layer == Layers.player){
				if (col.GetComponent<TypeOfPlayer>()){
					if (!dependsOnPlayerType || col.GetComponent<TypeOfPlayer>().PlayerType == playerType){
						if (triggerType == TriggerType.InputAndTrigger){
							if (oneOff && !done || !oneOff){
								foreach (string inputString in inputStrings){
									if (Input.GetButtonDown(inputString)){
										ActivateGameObjects();
									}
								}
							}
						}
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
		foreach (string objectToActivate in objectsToActivate){
			if (objectToActivate == "explo_x_button"){
				Players.explo_x_button.SetActive(activateOnTrigger);
			}
			else if (objectToActivate == "explo_y_button"){
				Players.explo_y_button.SetActive(activateOnTrigger);
			}
			else if (objectToActivate == "implo_x_button"){
				Players.implo_x_button.SetActive(activateOnTrigger);
			}
			else if (objectToActivate == "implo_y_button"){
				Players.implo_y_button.SetActive(activateOnTrigger);
			}
		}
	}


}
