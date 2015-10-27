using UnityEngine;
using System.Collections;
using GenericFunctions;

public class DeathRay : TripWire {
	
	public Transform fireOrigin;
	public float fireSpeed;
	public float timeToReload;
	public GameObject deathRay;

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

	void OnDrawGizmos(){
		Gizmos.color = Color.red;
		Gizmos.DrawLine(transform.position,transform.position + wireDirection * wireLength);
	}
}
