using UnityEngine;
using System.Collections;
using GenericFunctions;
using System.Collections.Generic;

public class Tosser : MonoBehaviour {

	public Controls controls;
	private float tossForce;
	private float yFactor; 
	private float xAxisInput;
	private float xDir;
	private List<Collider> colliderstoToss;
	private float timeBeforeYouCanTossTheColliderAgain;

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
		timeBeforeYouCanTossTheColliderAgain = 1f;
		colliderstoToss = new List<Collider>();
	}

	void Update(){
		xAxisInput = Input.GetAxisRaw(controls.Horizontal);
		if (Mathf.Abs (xAxisInput)>0.2f){
			xDir = Mathf.Sign(xAxisInput);
			transform.localPosition = new Vector3(xDir,0f,0f);
		}
	}

	void OnTriggerStay(Collider col){
		if (col.gameObject.layer == Layers.blocks){
			if (Input.GetButtonDown(controls.Toss)){
				Toss (col);
			}
		}
	}

	void Toss(Collider col){
		if (!colliderstoToss.Contains(col)){
			colliderstoToss.Add(col);
			Vector3 tossDir = new Vector3 (-xDir,yFactor,0f).normalized;
			Rigidbody boxBody = col.GetComponent<Rigidbody>();
			boxBody.velocity =Vector3.zero;
			boxBody.AddForce(tossDir * tossForce);
			StartCoroutine (RemoveColliderDelayed(col));
		}
	}

	IEnumerator RemoveColliderDelayed(Collider col){
		yield return new WaitForSeconds(timeBeforeYouCanTossTheColliderAgain);
		colliderstoToss.Remove(col);
	}
}
