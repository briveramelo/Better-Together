using UnityEngine;
using System.Collections;
using GenericFunctions;
public class DeathTrap : MonoBehaviour {
	
	void OnTriggerEnter(Collider col){
		if (col.gameObject.layer == Layers.player){
			Destroy(col.gameObject);
		}
	}
}
