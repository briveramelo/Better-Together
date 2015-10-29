#region Declaration
using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {
#endregion

	#region Initialize Variables
	public Keyhole keyhole;
	public int keyNumber;
	#endregion

	#region Send Message to Keyhole that you're attempting to open
	void OnEnable(){
		if (keyNumber<keyhole.keys.Length && keyNumber>=0){
			if (!keyhole.keys[keyNumber]){
				keyhole.StartCoroutine(keyhole.ActivateKey(keyNumber));
			}
		}
		this.enabled = false;
	}
	#endregion
}
