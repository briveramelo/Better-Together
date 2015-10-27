using UnityEngine;
using System.Collections;

public class CubeCannon : MonoBehaviour {

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

	void OnEnable(){
		cubeToSpawn = ChooseTypeToSpawn(cubeType);
		RespawnCube();
	}

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

	void OnDrawGizmos(){
		Gizmos.DrawRay(transform.position,shootDirection*shootForce);
	}

	void OnDestroy(){
		StopAllCoroutines();
	}
}
