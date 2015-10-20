using UnityEngine;
using System.Collections;
using GenericFunctions;
public class ExitPlatform : MonoBehaviour {

	public AudioClip conrad_WrapUp;
	public PlayerType platformType;
	public ExitPlatform partnerPlatform;
	private bool platformActive;
	public bool PlatformActive{get{return platformActive;}}
	private bool levelComplete;

	void OnTriggerStay(Collider col){
		if (col.gameObject.layer == Layers.player){
			if (col.gameObject.GetComponent<TypeOfPlayer>().PlayerType == platformType){
				if (platformType == PlayerType.Explo){
					if (Input.GetButton (GameManager.StaticControls.Explo_Controls.Door)){
						if (partnerPlatform.PlatformActive && !levelComplete){
							StartCoroutine (EndTheLevel());
						}
					}
				}
				else{
					platformActive = Input.GetButton (GameManager.StaticControls.Implo_Controls.Door) ? true : false;
				}
			}
		}
	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.layer == Layers.player){
			if (col.gameObject.GetComponent<TypeOfPlayer>().PlayerType == platformType){
				platformActive = false;
			}
		}
	}

	IEnumerator EndTheLevel(){
		levelComplete = true;
		Players.explo.GetComponent<PlayerMovement>().enabled = false;
		Players.explo.GetComponent<Pause>().enabled = false;
		Players.explo.GetComponentInChildren<Ploder>().enabled = false;
		Players.implo.GetComponent<PlayerMovement>().enabled = false;
		Players.implo.GetComponent<Pause>().enabled = false;
		Players.implo.GetComponentInChildren<Ploder>().enabled = false;

		AudioSource.PlayClipAtPoint(conrad_WrapUp,transform.position);
		yield return new WaitForSeconds(conrad_WrapUp.length);
		Application.LoadLevel(Levels.mainMenu);
	}
}
