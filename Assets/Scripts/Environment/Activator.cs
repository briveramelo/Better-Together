using UnityEngine;
using System.Collections;
using GenericFunctions;
public class Activator : MonoBehaviour {

	public bool dependsOnPlayerType;
	public PlayerType playerType;
	public TriggerType triggerType;
	public InputButtonNames inputButton;
	public bool activateOnTrigger;
	public bool oneOff;
	public AudioSource noise;
	private string inputString;
	protected bool done;

	protected virtual void ActivateObjects(){

	}

	void Awake(){
		inputString = GameManager.StaticControls.ButtonNameToString(playerType,inputButton);
	}
	
	void OnEnable(){
		if (triggerType == TriggerType.OnEnable){
			ActivateObjects();
		}
	}
	
	void OnCollisionEnter(Collision col){
		if (enabled){
			if (triggerType == TriggerType.OnCollision){
				if (oneOff && !done || !oneOff){
					ActivateObjects();
				}
			}
		}
	}
	
	void OnTriggerEnter(Collider col){
		if (enabled){
			if (triggerType == TriggerType.OnTriggerEnter){
				if (col.gameObject.layer == Layers.player){
					if (!dependsOnPlayerType || col.GetComponent<TypeOfPlayer>().PlayerType == playerType){
						if (oneOff && !done || !oneOff){
							ActivateObjects();
						}
					}
				}
			}
		}
	}
	
	void OnTriggerStay(Collider col){
		if (enabled){
			if (triggerType == TriggerType.InputAndOnTriggerStay || triggerType == TriggerType.OnTriggerStay){
				if (col.gameObject.layer == Layers.player){
					if (col.GetComponent<TypeOfPlayer>()){
						if (!dependsOnPlayerType || col.GetComponent<TypeOfPlayer>().PlayerType == playerType){
							if (oneOff && !done || !oneOff){
								if (triggerType == TriggerType.InputAndOnTriggerStay){
									if (Input.GetButtonDown(inputString)){
										ActivateObjects();
									}
								}
								else{
									ActivateObjects ();
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
			if (triggerType == TriggerType.OnTriggerExit){
				if (col.gameObject.layer == Layers.player){
					if (col.GetComponent<TypeOfPlayer>()){
						if (!dependsOnPlayerType || col.GetComponent<TypeOfPlayer>().PlayerType == playerType){
							ActivateObjects();
						}
					}
				}
			}
		}
	}
	
	void Update(){
		if (triggerType == TriggerType.Input){
			if (oneOff && !done || !oneOff){
				if (Input.GetButtonDown(inputString)){
					ActivateObjects();
				}
			}
		}
	}
}
