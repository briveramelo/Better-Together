using UnityEngine;
using System.Collections;
using GenericFunctions;
public class DeathTrap : MonoBehaviour {

	public PlayerRespawner playerRespawner;
	public AudioSource deathNoise;

	void OnTriggerEnter(Collider col){
		if (col.gameObject.layer == Layers.player){
			deathNoise.Play();
			PlayerType playerType = col.GetComponent<TypeOfPlayer>().PlayerType;
			playerRespawner.RespawnPlayer(playerType);
			if (playerType == PlayerType.Explo){
				Players.dominantPlayer = PlayerType.Implo;
			}
			else if (playerType == PlayerType.Implo){
				Players.dominantPlayer = PlayerType.Explo;
			}
			Destroy(col.gameObject);
		}
	}
}
