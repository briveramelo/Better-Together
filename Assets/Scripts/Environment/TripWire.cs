using UnityEngine;
using System.Collections;

public class TripWire : MonoBehaviour {

	public LayerMask lookFor;
	public GameObject target;
	public Vector3 wireDirection;
	[Range(0,30)]
	public float wireLength;
	protected bool waitingToShoot;
	
	protected void Update(){
		if (Physics.Raycast(transform.position, wireDirection, wireLength, lookFor.value)){
			if (!waitingToShoot){
				StartCoroutine(TripTheWire());
			}
		}
	}
	
	protected virtual IEnumerator TripTheWire(){
		yield return null;
	}
	
	void OnDrawGizmos(){
		Gizmos.color = Color.white;
		Gizmos.DrawLine(transform.position,transform.position + wireDirection * wireLength);
	}
}
