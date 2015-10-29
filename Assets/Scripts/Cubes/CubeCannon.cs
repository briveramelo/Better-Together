#region Declaration
using UnityEngine;
using System.Collections;

public class CubeCannon : MonoBehaviour {
#endregion

	#region Initialize variables
	public GameObject exploCube;
	public GameObject imploCube;
	public GameObject bothCube;
	public GameObject neitherCube;

	private GameObject cubeToSpawn;
	public CubeTypes cubeType;
	public Transform spawnPoint;
	public Vector3 shootDirection;
	[Range(0,1000)]
	public float shootForce;
	#endregion

	#region Trigger Cube Spawn
	void OnEnable(){
		cubeToSpawn = ChooseTypeToSpawn(cubeType);
		RespawnCube();
	}
	#endregion

		#region Respawn Cube
	public void RespawnCube(){
		if (this){
			StartCoroutine(RespawnCube_Internal());
		}
	}
	
	IEnumerator RespawnCube_Internal(){
		yield return null;
		GameObject currentCube = Instantiate(cubeToSpawn,spawnPoint.position,Quaternion.identity) as GameObject;
		currentCube.GetComponent<Rigidbody>().AddForce(shootDirection.normalized * shootForce);
		currentCube.AddComponent<BuddyCubeRespawner>().cubeCannon = this;
	}
		#endregion

		#region Choose Cube To Spawn
	GameObject ChooseTypeToSpawn(CubeTypes cubeType){
		if (cubeType == CubeTypes.Explo){
			return exploCube;
		}
		else if (cubeType == CubeTypes.Implo){
			return imploCube;
		}
		else if (cubeType == CubeTypes.Both){
			return bothCube;
		}
		else{
			return neitherCube;
		}
	}
		#endregion


	#region Gizmos + OnDestroyStopCoroutines
	void OnDrawGizmos(){
		Gizmos.DrawRay(transform.position,shootDirection*shootForce);
	}

	void OnDestroy(){
		StopAllCoroutines();
	}
	#endregion
}
