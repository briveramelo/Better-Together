#region Declaration
using UnityEngine;
using System.Collections;

public class BuddyCubeRespawner : MonoBehaviour {
#endregion

	#region Initialize Variables
	public CubeCannon cubeCannon;
	#endregion

	#region Let the cannon know to shoot another block OnDestroy
	void OnDestroy(){
		cubeCannon.RespawnCube();
	}
	#endregion
}
