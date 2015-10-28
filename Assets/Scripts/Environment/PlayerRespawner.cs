using UnityEngine;
using System.Collections;
using GenericFunctions;

public class PlayerRespawner : MonoBehaviour {

	public GameObject explo;
	public GameObject implo;
	private bool respawningExplo;
	private bool respawningImplo;
	private int currentCheckPointNumber;

	public Transform[] checkPoints; 

	void Awake(){
		LevelItems.playerRespawner = this;
	}

	public void RespawnPlayer(PlayerType playerType){
		if (this){
			if (isActiveAndEnabled){
				StartCoroutine(RespawnMe(playerType));
			}
		}
	}

	IEnumerator RespawnMe(PlayerType playerType){
		GameObject personToRespawn = playerType == PlayerType.Explo ? explo : implo;
		yield return new WaitForSeconds(2f);
		Vector3 respawnPoint = checkPoints[currentCheckPointNumber].position;
		if (Players.dominantPlayer == PlayerType.Explo && Players.explo){
			respawnPoint = Players.explo.transform.position+Players.respawnShift;
		}
		else if (Players.dominantPlayer == PlayerType.Implo && Players.implo){
			respawnPoint = Players.implo.transform.position+Players.respawnShift;
		}

		Instantiate(personToRespawn,respawnPoint,Quaternion.identity);
	}

	public int CurrentCheckPointNumber{get{return currentCheckPointNumber;} set{currentCheckPointNumber = value;}}
}
