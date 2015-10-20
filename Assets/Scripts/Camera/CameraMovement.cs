using UnityEngine;
using System.Collections;
using GenericFunctions;
public class CameraMovement : MonoBehaviour {

	public Transform targetTransformPosition;
	public Transform targetTransformLookSpot;
	[Range (0,1)]
	public float lerpMoveFraction;

	[Range(0,1)]
	public float lerpRotationFraction;


	private Controls controls;
	private float lastForwardPosition;
	private float lastBackwardPosition;
	private float switchCameraAngleDistance;

	// Use this for initialization
	void Awake () {
		controls = GameManager.StaticControls.Explo_Controls;
		lerpMoveFraction = 0.075f;
		lerpRotationFraction = 0.035f;
		switchCameraAngleDistance = 1f;
	}
	
	//FIXED UPDATE SO GOOD FOR LERP!
	void FixedUpdate () {
		if (targetTransformPosition){
			transform.position = Vector3.Lerp(transform.position,targetTransformPosition.position,lerpMoveFraction);
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation(targetTransformLookSpot.position - transform.position), lerpRotationFraction);
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
		else{
			targetTransformPosition = Players.explo_CameraAnchor;
			targetTransformLookSpot = Players.explo_CameraLookSpot;
			controls = GameManager.StaticControls.Explo_Controls;
			if (!targetTransformPosition){
				targetTransformPosition = Players.implo_CameraAnchor;
				targetTransformLookSpot = Players.implo_CameraLookSpot;
				controls = GameManager.StaticControls.Implo_Controls;
			}
		}


	}
}
