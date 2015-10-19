using UnityEngine;
using System.Collections;
using GenericFunctions;
public class Teleporter : MonoBehaviour {

	private Transform transformToBeCloseTo;
	public TypeOfPlayer typeOfPlayer;

	[Range (10,50)]
	public float maxSeparation;
	
	// Update is called once per frame
	void Update () {
		if (typeOfPlayer.PlayerType != Players.dominantPlayer){
			if (!transformToBeCloseTo){
				if (typeOfPlayer.PlayerType == PlayerType.Explo){
					transformToBeCloseTo = Players.implo.transform;
				}
				else{
					transformToBeCloseTo = Players.explo.transform;
				}
			}
			else if (Vector3.Distance(transform.position,transformToBeCloseTo.position)>maxSeparation){
				transform.position = transformToBeCloseTo.position + Players.respawnShift;
			}
		}
	}
}
