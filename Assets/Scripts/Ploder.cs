using UnityEngine;
using System.Collections;
using GenericFunctions;
using System.Linq;

public class Ploder : MonoBehaviour {

	public TypeOfPlayer typeOfPlayer;
	public Controls controls;
	public PlayerMovement playerMovement;
	private Collider[] collidersToPlode;
	
	private float baselinePlodeForce;
	private float plosionRadius;
	private bool ploding;
	public bool Ploding{get{return ploding;}}
	public Animator plosionAnimator;
	public AudioSource explode;
	public AudioSource implode;

	// Use this for initialization
	void Awake () {
		baselinePlodeForce = 20000f;
		plosionRadius = 20f;
		collidersToPlode = new Collider[0];
	}
	
	// Update is called once per frame
	void Update () {
		if ( !ploding ){
			if ( Input.GetButtonDown(controls.Action) ){
				FindMoveableColliders();
				AnimatePlosion();
				Plode();
				StartCoroutine (StallOnPlodingAgain());
			}
		}
	}

	public void AnimateSmallIdle(){
		plosionAnimator.SetInteger("AnimState",0);
	}
	
	public void AnimatePlosion(){
		plosionAnimator.SetInteger("AnimState",1);
	}

	public void AnimateReScale(){
		plosionAnimator.SetInteger("AnimState",2);
	}

	public void AnimateBigIdle(){
		plosionAnimator.SetInteger("AnimState",3);
	}

	void Plode(){
		foreach (Collider col in collidersToPlode){
			if (col.attachedRigidbody){
				float separationDistance = Vector3.Distance(transform.position,col.transform.position);
				Vector3 plosionDirection;
				float plosionForce;
				if (typeOfPlayer.PlayerType == PlayerType.Explo){
					plosionDirection = (col.transform.position - transform.position).normalized;
					plosionForce = baselinePlodeForce * Mathf.Clamp01(1-separationDistance/plosionRadius);
				}
				else{
					plosionDirection = (transform.position - col.transform.position).normalized;
					plosionForce = baselinePlodeForce * Mathf.Clamp01(separationDistance/plosionRadius);
				}
				col.attachedRigidbody.AddForce(plosionDirection * plosionForce);
			}
		}
	}

	IEnumerator StallOnPlodingAgain(){
		ploding = true;
		yield return new WaitForSeconds (2f);
		ploding = false;
	}

	float FindExponentMultiplier(float cutoffTolerance, float distanceAway){
		return Mathf.Log(cutoffTolerance)/(-distanceAway);
	}
	
	void FindMoveableColliders(){
		collidersToPlode = Physics.OverlapSphere (transform.position,plosionRadius,-1,QueryTriggerInteraction.Ignore); 
		collidersToPlode = collidersToPlode.Where(foundCollider => (foundCollider.tag == Tags.moveableObjects || 
		                                                           (foundCollider.tag == Tags.explode_Objects && typeOfPlayer.PlayerType == PlayerType.Explo) || 
		                                                           (foundCollider.tag == Tags.implode_Objects && typeOfPlayer.PlayerType == PlayerType.Implo))).ToArray();

	}

}
