#region Declaration
using UnityEngine;
using System.Collections;
using GenericFunctions;

public class CheckPoint : MonoBehaviour {
#endregion

	#region Initialize Variables
	public PlayerRespawner playerRespawner;
	#endregion

	#region Trigger Updating Checkpoints
	void OnTriggerEnter(Collider col){
		if (col.gameObject.layer == Layers.player){
			int i=0;
			foreach (Transform checkPoint in playerRespawner.checkPoints){
				if (checkPoint == transform){
					playerRespawner.CurrentCheckPointNumber = i;
				}
				i++;
			}
		} 
	}
	#endregion
}
