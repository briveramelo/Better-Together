using UnityEngine;
using System.Collections;

public class CannonActivator_TripWire : TripWire {
	
	public GameObject cubeCannonToActivate;
	
	protected override IEnumerator TripTheWire(){
		cubeCannonToActivate.SetActive(true);
		yield return null;
		Destroy(gameObject);
	}
}
