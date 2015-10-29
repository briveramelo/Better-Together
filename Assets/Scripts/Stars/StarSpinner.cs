#region Declaration
using UnityEngine;
using System.Collections;

public class StarSpinner : MonoBehaviour {
#endregion

	#region Initialize Variables
	
	void Awake () {
	
	}
	#endregion
	
	void Update () {
		transform.rotation = Quaternion.Lerp(transform.rotation,transform.rotation * Quaternion.Euler(0f,30f,10f),0.03f);
	}


}
