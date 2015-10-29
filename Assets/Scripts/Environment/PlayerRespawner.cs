#region Declaration
using UnityEngine;
using System.Collections;
using GenericFunctions;

public class PlayerRespawner : MonoBehaviour {
#endregion

	#region Initialize Variables
	public GameObject explo;
	public GameObject implo;
	public bool isDuel;
	private bool respawningExplo;
	private bool respawningImplo;
	private int currentCheckPointNumber;

	public Transform[] checkPoints; 

	void Awake(){
		LevelItems.playerRespawner = this;
	}
	#endregion

		#region Trigger Player Respawn
	public void RespawnPlayer(PlayerType playerType){
		if (this){
			if (isActiveAndEnabled){
				StartCoroutine(RespawnMeInLevel(playerType));
			}
		}
	}
		#endregion

			#region Respawn Player
	IEnumerator RespawnMeInLevel(PlayerType playerType){
		GameObject personToRespawn = playerType == PlayerType.Explo ? explo : implo;
		yield return new WaitForSeconds(2f);
		Vector3 respawnPoint = checkPoints[currentCheckPointNumber].position;
		if (!isDuel){
			if (Players.dominantPlayer == PlayerType.Explo && Players.explo){
				respawnPoint = Players.explo.transform.position+Players.respawnShift;
			}
			else if (Players.dominantPlayer == PlayerType.Implo && Players.implo){
				respawnPoint = Players.implo.transform.position+Players.respawnShift;
			}
		}

		Instantiate(personToRespawn,respawnPoint,Quaternion.identity);
	}
			#endregion

	#region Get/Set
	public int CurrentCheckPointNumber{get{return currentCheckPointNumber;} set{currentCheckPointNumber = value;}}
	#endregion
}
