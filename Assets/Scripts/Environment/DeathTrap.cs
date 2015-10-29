#region Declaration
using UnityEngine;
using System.Collections;
using GenericFunctions;
public class DeathTrap : MonoBehaviour {
#endregion

	#region Destroy Players and Blocks OnTriggerEnter
	void OnTriggerEnter(Collider col){
		if (col.gameObject.layer == Layers.player||
		    col.gameObject.layer == Layers.blocks){
			Destroy(col.gameObject);
		}
	}
	#endregion
}
