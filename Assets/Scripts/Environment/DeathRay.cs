#region Declaration (Inherits from TripWire)
using UnityEngine;
using System.Collections;
using GenericFunctions;

public class DeathRay : TripWire {
#endregion

	#region Initialize Variables
	public Transform fireOrigin;
	public float fireSpeed;
	public float timeToReload;
	public GameObject deathRay;
	#endregion

	#region Shoot a blast OnTripping
	protected override IEnumerator TripTheWire(){
		waitingToShoot = true;
		GameObject currentDeathRay = Instantiate (deathRay,fireOrigin.position,Quaternion.identity) as GameObject;
		EffectSettings effectSettings = currentDeathRay.GetComponent<EffectSettings>();
		effectSettings.Target = target;
		effectSettings.MoveSpeed = fireSpeed;
		currentDeathRay.SetActive(true);
		yield return new WaitForSeconds (timeToReload);
		waitingToShoot = false;
	}
	#endregion

	#region Gizmos
	void OnDrawGizmos(){
		Gizmos.color = Color.red;
		Gizmos.DrawLine(transform.position,transform.position + wireDirection * wireLength);
	}
	#endregion
}
