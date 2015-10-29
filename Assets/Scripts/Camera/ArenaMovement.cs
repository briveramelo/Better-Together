#region Declaration
using UnityEngine;
using System.Collections;
using GenericFunctions;
public class ArenaMovement : MonoBehaviour {
#endregion

	#region Initialize Variables
	public Transform defaultSpot;
	private Vector3 targetSpot;
	private Camera cam;
	private float minFOV;
	private float targetFOV;
	void Awake () {
		cam = Camera.main;
		minFOV = 60f;
	}
	#endregion

	#region SetCamera Position + Field of View
	void FixedUpdate () {
		targetSpot = defaultSpot.position;
		if (Players.explo && Players.implo){
			targetSpot = (Players.explo_CameraAnchor.position + Players.implo_CameraAnchor.position)/2f;
			targetFOV = Mathf.Clamp(Vector3.Angle((Players.implo.transform.position-transform.position),
			                                (Players.explo.transform.position-transform.position)),minFOV,180f);
			cam.fieldOfView = Mathf.Lerp (cam.fieldOfView,targetFOV,0.1f);
		}
		else if (!Players.explo && Players.implo){
			targetSpot =Players.implo_CameraAnchor.position;
		}
		else if (Players.explo && !Players.implo){
			targetSpot =Players.explo_CameraAnchor.position;
		}
		targetSpot += Vector3.up*4f;
		transform.position = Vector3.Lerp(transform.position,targetSpot,0.075f);
	}

	#endregion

}
