using UnityEngine;
using System.Collections;

public class DoorLift : MonoBehaviour {

	public Transform targetTransform;

	[Range(0.01f,0.1f)]
	public float moveSpeed;
	public bool resetPosition;
	public DoorLift resetDoorScript;
	public AudioSource doorLiftNoise;

	void OnEnable(){
		if (doorLiftNoise){
			doorLiftNoise.Play();
		}
		StartCoroutine(LiftUp());
	}

	IEnumerator LiftUp(){
		while (Vector3.Distance(transform.position,targetTransform.position)>0.02f){
			transform.position = Vector3.MoveTowards(transform.position,targetTransform.position,moveSpeed);
			yield return null;
		}
		transform.position = targetTransform.position;
		if (doorLiftNoise){
			doorLiftNoise.Stop();
		}
		if (resetPosition){
			if (resetDoorScript){
				resetDoorScript.enabled = true;
			}
		}
		yield return null;
		this.enabled = false;
	}

	public bool ResetPosition{
		set{
			resetPosition = value;
		}
	}
}
