using UnityEngine;
using System.Collections;

public class BuddyCubeRespawner : MonoBehaviour {

	public CubeCannon cubeCannon;
	
	void OnDestroy(){
		cubeCannon.RespawnCube();
	}
}
