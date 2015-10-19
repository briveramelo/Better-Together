using UnityEngine;
using System.Collections;
using GenericFunctions;
public class StaticUpdater : MonoBehaviour {

	public TypeOfPlayer typeOfPlayer;
	public Transform cameraAnchor;
	public Transform cameraLookSpot;

	// Use this for initialization
	void Awake () {
		if (typeOfPlayer.PlayerType == PlayerType.Explo){
			Players.explo = gameObject;
			Players.explo_CameraAnchor = cameraAnchor;
			Players.explo_CameraLookSpot = cameraLookSpot;
		}
		else if (typeOfPlayer.PlayerType == PlayerType.Implo){
			Players.implo = gameObject;
			Players.implo_CameraAnchor = cameraAnchor;
			Players.implo_CameraLookSpot = cameraLookSpot;
		}
	}
}
