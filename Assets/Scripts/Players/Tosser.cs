using UnityEngine;
using System.Collections;
using GenericFunctions;

public class Tosser : MonoBehaviour {

	public Controls controls;
	private Collider[] collidersToToss;
	private float tossForce;
	private float yFactor; 

//	struct BackPack{
//		public static BackPack empty = new BackPack(0,0);
//
//		float weight;
//		int numNoteBooks;
//		public BackPack(float weight, int numNoteBooks){
//			this.weight = weight;
//			this.numNoteBooks = numNoteBooks;
//		}
//
//	}

	void Awake(){
		tossForce = 600f;
		yFactor = 7.5f;
	}

	void OnTriggerStay(Collider col){
		if (col.gameObject.layer == Layers.blocks){
			if (Input.GetButtonDown(controls.Toss)){
				Toss (col);
			}
		}
	}

	void Toss(Collider col){
		Vector3 tossDir = new Vector3 (-Mathf.Sign(controls.transform.localScale.x),yFactor,0f).normalized;
		col.GetComponent<Rigidbody>().AddForce(tossDir * tossForce);
	}
}
