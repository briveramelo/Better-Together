#region Declaration
using UnityEngine;
using System.Collections;

public class DoorLift : MonoBehaviour {
#endregion

	#region Initialize Variables
	public Transform startTransform;
	public Transform targetTransform;

	[Range(0.01f,0.1f)]
	public float moveSpeed;
	public bool resetPosition;
	public DoorLift[] otherDoorLiftScripts;
	public DoorLift resetDoorScript;
	public AudioSource doorLiftNoise;
	private bool isLifting;
	private bool justOpenTheDamnDoor;
	public bool JustOpenTheDamnDoor{get{return justOpenTheDamnDoor;}set{justOpenTheDamnDoor=value;}}
	public bool ResetPosition{set{resetPosition = value;}}
	#endregion

	#region Trigger Door Lifting
	void OnEnable(){
		StartCoroutine(CheckToLift());
	}
	#endregion

		#region Check If Now is a Good Time To Lift the Door
	IEnumerator CheckToLift(){
		yield return new WaitForEndOfFrame();
		if ((!isLifting && Vector3.Distance(transform.position, startTransform.position)<0.001f) || justOpenTheDamnDoor){
			TellTheDoorsToStopMoving();
			if (doorLiftNoise){
				doorLiftNoise.Play();
			}
			StartCoroutine(LiftUp());
		}
		else{
			this.enabled = false;
		}
	}
		#endregion
	
		#region Lift IT!
	IEnumerator LiftUp(){
		isLifting = true;
		while (Vector3.Distance(transform.position,targetTransform.position)>0.02f){
			transform.position = Vector3.MoveTowards(transform.position,targetTransform.position,moveSpeed);
			yield return null;
		}
		transform.position = targetTransform.position;
		isLifting = false;
		if (doorLiftNoise){
			doorLiftNoise.Stop();
		}
		if (resetPosition){
			if (resetDoorScript){
				resetDoorScript.enabled = true;
			}
		}
		this.enabled = false;
		yield return null;
	}
		#endregion


	#region Communicate with other Door Lift Scripts on the same object 
	void TellTheDoorsToStopMoving(){
		if (otherDoorLiftScripts.Length>0){
			foreach (DoorLift doorLiftScript in otherDoorLiftScripts){
				doorLiftScript.StopMovingAround();
			}
		}
	}

	public void StopMovingAround(){
		StopAllCoroutines();
	}
	#endregion
}
