using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

	public Transform transformToBeCloseTo;

	[Range (10,50)]
	public float maxSeparation;
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(transform.position,transformToBeCloseTo.position)>maxSeparation){
			transform.position = transformToBeCloseTo.position;
		}
	}
}
