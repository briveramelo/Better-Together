using UnityEngine;
using System.Collections;
using GenericFunctions;
public class ButtonActivator : MonoBehaviour {
	
	public bool dependsOnPlayerType;
	public PlayerType playerType;
	public ButtonType[] buttonTypes;
	public TriggerType triggerType;
	public string[] objectsToActivate;
	public string[] inputStrings;
	public bool activateOnTrigger;
	public bool oneOff;
	public AudioSource noise;
	
	private bool done;
	
	void OnCollisionEnter(Collision col){
		if (enabled){
			if (triggerType == TriggerType.Collision){
				if (oneOff && !done || !oneOff){
					ActivateGameObjects();
				}
			}
		}
	}
	
	void OnTriggerEnter(Collider col){
		if (enabled){
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
	}
	
	void OnTriggerStay(Collider col){
		if (enabled){
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
	}

	void OnTriggerExit(Collider col){
		if (enabled){
			if (triggerType == TriggerType.TriggerColliderExit){
				if (col.gameObject.layer == Layers.player){
					if (col.GetComponent<TypeOfPlayer>()){
						if (!dependsOnPlayerType || col.GetComponent<TypeOfPlayer>().PlayerType == playerType){
							ActivateGameObjects();
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
		foreach (ButtonType buttonType in buttonTypes){
			if (playerType == PlayerType.Explo){
				if (buttonType == ButtonType.X){
					Players.explo_x_Button.SetActive(activateOnTrigger);
				}
				else if (buttonType == ButtonType.Y){
					Players.explo_y_Button.SetActive(activateOnTrigger);
				}
				else if (buttonType == ButtonType.B){
					Players.explo_b_Button.SetActive(activateOnTrigger);
				}
			}
			else{
				if (buttonType == ButtonType.X){
					Players.implo_x_Button.SetActive(activateOnTrigger);
				}
				else if (buttonType == ButtonType.Y){
					Players.implo_y_Button.SetActive(activateOnTrigger);
				}
				else if (buttonType == ButtonType.B){
					Players.implo_b_Button.SetActive(activateOnTrigger);
				}
			}
		}
	}


}
