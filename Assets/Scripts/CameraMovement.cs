using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public Transform targetTransformPosition;
	public Transform targetTransformLookSpot;
	public Controls controls;
	[Range (0,1)]
	public float lerpMoveFraction;

	[Range(0,1)]
	public float lerpRotationFraction;


	private float lastForwardPosition;
	private float lastBackwardPosition;
	private float switchCameraAngleDistance;

	// Use this for initialization
	void Awake () {
		controls.SetControls(PlayerType.Explo);
		lerpMoveFraction = 0.075f;
		lerpRotationFraction = 0.035f;
		switchCameraAngleDistance = 1f;
	}
	
	//FIXED UPDATE SO GOOD FOR LERP!
	void FixedUpdate () {
		if (targetTransformPosition){
			transform.position = Vector3.Lerp(transform.position,targetTransformPosition.position,lerpMoveFraction);
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation(targetTransformLookSpot.position - transform.position), lerpRotationFraction);
		}

		if (Input.GetAxisRaw(controls.Horizontal)>0.5f){
			lastForwardPosition = transform.position.x;
			if (lastForwardPosition>lastBackwardPosition+switchCameraAngleDistance){
				targetTransformLookSpot.localPosition = new Vector3 (1f,0f,10f);
			}

		}
		else if (Input.GetAxisRaw(controls.Horizontal)<-0.5f){
			lastBackwardPosition = transform.position.x;
			if (lastBackwardPosition<lastForwardPosition-switchCameraAngleDistance){
				targetTransformLookSpot.localPosition = new Vector3 (-1f,0f,10f);
			}
		}
	}
}
