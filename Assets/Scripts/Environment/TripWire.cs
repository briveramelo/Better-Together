#region Declaration
using UnityEngine;
using System.Collections;

public class TripWire : MonoBehaviour {
#endregion

	#region Initialize Variables
	public LayerMask lookFor;
	public GameObject target;
	public Vector3 wireDirection;
	[Range(0,30)]
	public float wireLength;
	protected bool waitingToShoot;
	#endregion

	#region Check if Raycast has been tripped
	protected void Update(){
		if (Physics.Raycast(transform.position, wireDirection, wireLength, lookFor.value)){
			if (!waitingToShoot){
				StartCoroutine(TripTheWire());
			}
		}
	}
	#endregion

	#region Establish Overwriteable Function for Children to use as they wish
	protected virtual IEnumerator TripTheWire(){
		yield return null;
	}
	#endregion

	#region Gizmos
	void OnDrawGizmos(){
		Gizmos.color = Color.white;
		Gizmos.DrawLine(transform.position,transform.position + wireDirection * wireLength);
	}
	#endregion
}
