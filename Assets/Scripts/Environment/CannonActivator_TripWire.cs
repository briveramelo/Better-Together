#region Declaration (Inherits from TripWire)
using UnityEngine;
using System.Collections;

public class CannonActivator_TripWire : TripWire {
#endregion

	#region Initialize variables
	public GameObject cubeCannonToActivate;
	#endregion


	#region Activate Cannon and Destroy Self
	protected override IEnumerator TripTheWire(){
		cubeCannonToActivate.SetActive(true);
		yield return null;
		Destroy(gameObject);
	}
	#endregion
}
