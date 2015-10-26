using UnityEngine;
using System.Collections;
using GenericFunctions;

public class StaticUpdater : MonoBehaviour {

	public PlayerType playerType;
	public Transform cameraAnchor;
	public Transform cameraLookSpot;
	public GameObject x_Button;
	public GameObject y_Button;
	public GameObject b_Button;

	// Use this for initialization
	void Awake () {
		if (playerType == PlayerType.Explo){
			Players.explo = gameObject;
			Players.explo_CameraAnchor = cameraAnchor;
			Players.explo_CameraLookSpot = cameraLookSpot;
			Players.explo_x_Button = x_Button;
			Players.explo_y_Button = y_Button;
			Players.explo_b_Button = b_Button;
		}
		else{
			Players.implo = gameObject;
			Players.implo_CameraAnchor = cameraAnchor;
			Players.implo_CameraLookSpot = cameraLookSpot;
			Players.implo_x_Button = x_Button;
			Players.implo_y_Button = y_Button;
			Players.implo_b_Button = b_Button;
		}
	}
}
