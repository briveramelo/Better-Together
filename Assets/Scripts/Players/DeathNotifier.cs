using UnityEngine;
using System.Collections;
using GenericFunctions;

public class DeathNotifier : MonoBehaviour {

	public PlayerType playerType;

	void OnDestroy(){
		LevelItems.playerRespawner.RespawnPlayer(playerType);
		if (playerType == PlayerType.Explo){
			Players.dominantPlayer = PlayerType.Implo;
		}
		else if (playerType == PlayerType.Implo){
			Players.dominantPlayer = PlayerType.Explo;
		}
	}
}
