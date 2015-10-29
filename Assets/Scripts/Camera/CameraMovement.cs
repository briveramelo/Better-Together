#region Declaration
using UnityEngine;
using System.Collections;
using GenericFunctions;
public class CameraMovement : MonoBehaviour {
#endregion

	#region Initialize Variables
	public Transform targetTransformPosition;
	public Transform targetTransformLookSpot;
	[Range (0,1)]
	public float lerpMoveFraction;

	[Range(0,1)]
	public float lerpRotationFraction;


	private Controls playerControlsForCamera;
	private float lastForwardPosition;
	private float lastBackwardPosition;
	private float switchCameraAngleDistance;

	// Use this for initialization
	void Start () {
		playerControlsForCamera = Players.dominantPlayer == PlayerType.Explo ? GameManager.StaticControls.Explo_Controls : GameManager.StaticControls.Implo_Controls;
		lerpMoveFraction = 0.075f;
		lerpRotationFraction = 0.035f;
		switchCameraAngleDistance = 1f;
	}
	#endregion


	#region Lerp Camera Position
	//FIXED UPDATE SO GOOD FOR LERP!
	void FixedUpdate () {
		if (targetTransformPosition){
			transform.position = Vector3.Lerp(transform.position,targetTransformPosition.position,lerpMoveFraction);
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation(targetTransformLookSpot.position - transform.position), lerpRotationFraction);
			if (Input.GetAxisRaw(playerControlsForCamera.Horizontal)>0.5f){
				lastForwardPosition = transform.position.x;
				if (lastForwardPosition>lastBackwardPosition+switchCameraAngleDistance){
					targetTransformLookSpot.localPosition = new Vector3 (1f,0f,10f);
				}
				
			}
			else if (Input.GetAxisRaw(playerControlsForCamera.Horizontal)<-0.5f){
				lastBackwardPosition = transform.position.x;
				if (lastBackwardPosition<lastForwardPosition-switchCameraAngleDistance){
					targetTransformLookSpot.localPosition = new Vector3 (-1f,0f,10f);
				}
			}
		}
		else{
			SwitchToOtherPlayer();
		}
	}
	#endregion


	#region Toggle Camera
	//code?
	#endregion
	
		#region Check for Toggle input
	void Update(){
		if (Input.GetButtonDown(playerControlsForCamera.ToggleCamera)){
			SwitchToOtherPlayer();
		}
	}
		#endregion

		#region Do the Toggle
	void SwitchToOtherPlayer(){
		if (playerControlsForCamera.IsExplo){
			targetTransformPosition = Players.implo_CameraAnchor;
			targetTransformLookSpot = Players.implo_CameraLookSpot;
			playerControlsForCamera = GameManager.StaticControls.Implo_Controls;
			Players.dominantPlayer = PlayerType.Implo;
		}
		else{
			targetTransformPosition = Players.explo_CameraAnchor;
			targetTransformLookSpot = Players.explo_CameraLookSpot;
			playerControlsForCamera = GameManager.StaticControls.Explo_Controls;
			Players.dominantPlayer = PlayerType.Explo;
		}
	}
		#endregion


	#region DisableAnimator
	public void DisableAnimator(){
		GetComponent<Animator>().enabled = false;
	}
	#endregion
}
