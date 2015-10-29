#region Declaration
using UnityEngine;
using System.Collections;
using GenericFunctions;
public class Activator : MonoBehaviour {
#endregion


	#region Initialize Variables
	public bool dependsOnPlayerType;
	public PlayerType playerType;
	public TriggerType triggerType;
	public LayerMask layerMask;
	public InputButtonNames inputButton;
	public bool activateOnTrigger;
	public bool oneOff;
	public AudioSource noise;
	private string inputString;
	protected bool done;

	void Awake(){
		inputString = GameManager.StaticControls.ButtonNameToString(playerType,inputButton);
	}
	#endregion

	#region Establish Overwriteable Function
	protected virtual void ActivateObjects(){

	}
	#endregion

	#region Triggers
	//code?
	#endregion

		#region OnEnable Trigger
	void OnEnable(){
		if (triggerType == TriggerType.OnEnable){
			ActivateObjects();
		}
	}
		#endregion

		#region OnCollisionEnter Trigger
	void OnCollisionEnter(Collision col){
		if (enabled){
			if (triggerType == TriggerType.OnCollision){
				if (oneOff && !done || !oneOff){
					ActivateObjects();
				}
			}
		}
	}
		#endregion

		#region OnTriggerEnter Trigger	
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
		#endregion

		#region OnTriggerStay Trigger
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
		#endregion

		#region OnTriggerExit Trigger
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
		#endregion

		#region Input Trigger
	void Update(){
		if (triggerType == TriggerType.Input){
			if (oneOff && !done || !oneOff){
				if (Input.GetButtonDown(inputString)){
					ActivateObjects();
				}
			}
		}
	}
		#endregion
}
