using UnityEngine;
using System.Collections;
using GenericFunctions;
public class ExitPlatform : MonoBehaviour {

	public AudioClip wrapUp;
	public PlayerType platformType;
	public ExitPlatform partnerPlatform;
	private bool platformActive;
	public bool PlatformActive{get{return platformActive;}}
	private bool levelComplete;
	public Transform exploParentAnimTran;
	public Transform imploParentAnimTran;

	void OnTriggerStay(Collider col){
		if (col.gameObject.layer == Layers.player){
			if (col.gameObject.GetComponent<TypeOfPlayer>()){
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
	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.layer == Layers.player){
			if (col.GetComponent<TypeOfPlayer>()){
				if (col.gameObject.GetComponent<TypeOfPlayer>().PlayerType == platformType){
					platformActive = false;
				}
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

		Players.explo_y_Button.SetActive(false);
		Players.implo_y_Button.SetActive(false);

		SetAnimationParent();
		AudioSource cameraAudio = Camera.main.GetComponent<AudioSource>();
		cameraAudio.enabled = true;
		cameraAudio.clip = wrapUp;
		cameraAudio.Play();
		Camera.main.GetComponent<CameraMovement>().targetTransformLookSpot = Players.dominantPlayer == PlayerType.Explo ? Players.explo.transform : Players.implo.transform;
		yield return new WaitForSeconds(wrapUp.length);
		Application.LoadLevel(Levels.mainMenu);
	}

	public void SetAnimationParent(){
		Players.explo.transform.parent = exploParentAnimTran;
		Players.implo.transform.parent = imploParentAnimTran;
		Players.explo.GetComponent<Animator>().enabled = true;
		Players.implo.GetComponent<Animator>().enabled = true;
	}
}
