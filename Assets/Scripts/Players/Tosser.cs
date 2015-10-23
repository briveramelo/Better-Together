using UnityEngine;
using System.Collections;
using GenericFunctions;

public class Tosser : MonoBehaviour {

	public Controls controls;
	private Collider[] collidersToToss;
	[Range(200,10000)]
	private float tossForce;
	public Transform targetTossTransform; 

	void Awake(){
		tossForce = 600f;
	}

	void OnTriggerStay(Collider col){
		if (col.gameObject.layer == Layers.blocks){
			if (Input.GetButtonDown(controls.Toss)){
				Toss (col);
			}
		}
	}

	void Toss(Collider col){
		Vector3 tossDir = (targetTossTransform.position-col.transform.position).normalized;
		float forceMultiplier = Mathf.Clamp01 (Vector3.Distance(targetTossTransform.position,col.transform.position));
		col.GetComponent<Rigidbody>().AddForce(tossDir * tossForce * forceMultiplier);
	}
}
