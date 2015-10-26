using UnityEngine;
using System.Collections;

public class DoorLift : MonoBehaviour {

	public Transform targetTransform;

	[Range(0.01f,0.1f)]
	public float moveSpeed;
	public bool resetPosition;
	public DoorLift resetDoorScript;
	private Vector3 startPosition;
	public AudioSource doorLiftNoise;

	void OnEnable(){
		startPosition = transform.position;
		if (doorLiftNoise){
			doorLiftNoise.Play();
		}
		StartCoroutine(LiftUp());
	}

	IEnumerator LiftUp(){
		while (Vector3.Distance(startPosition,targetTransform.position)>0.01f){
			transform.position = Vector3.MoveTowards(transform.position,targetTransform.position,moveSpeed);
			yield return null;
		}
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
}
