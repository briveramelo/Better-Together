using UnityEngine;
using System.Collections;
using GenericFunctions;
public class DestroyOnCollision : MonoBehaviour {

	public LayerMask destroyThese;

	void OnTriggerEnter(Collider col){
		if (enabled){
			Debug.Log("TriggerEntered");
			if ((destroyThese.value & (1<<col.gameObject.layer)) != 0){
				Debug.LogWarning("HIT " + col.gameObject.name);
				Destroy (col.gameObject);
				this.enabled = false;
			}
		}
	}
}
