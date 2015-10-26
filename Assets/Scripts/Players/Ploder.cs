using UnityEngine;
using System.Collections;
using GenericFunctions;
using System.Linq;

public class Ploder : MonoBehaviour {

	public PlayerType playerType;
	public PlayerMovement playerMovement;
	private Collider[] collidersToPlode;
	
	private Controls controls;
	private float baselinePlodeForce;
	private float plosionRadius;
	private bool ploding;
	public bool Ploding{get{return ploding;}}
	public Animator plosionAnimator;
	public AudioSource plosionToPlay;
	public GameObject plosionEffect;
	public ParticleSystem fog;
	public GameObject sphereEffect;
	private Quaternion sphereQuaternion;

	// Use this for initialization
	void Awake () {
		baselinePlodeForce = 6500f;
		plosionRadius = 10f;
		collidersToPlode = new Collider[0];
		GetCurrentControls();

		sphereQuaternion = playerType == PlayerType.Explo ? Quaternion.Euler (0f,25f,270f) : Quaternion.Euler (90f,180f,0f);
	}
	
	// Update is called once per frame
	void Update () {
		if ( !ploding ){
			if ( Input.GetButton(controls.Action) ){
				plosionToPlay.Play();
				FindMoveableColliders();
				AnimatePlosion();
				Plode();
			}
		}
	}

	public void AnimateSmallIdle(){
		plosionAnimator.SetInteger("AnimState",0);
		StartCoroutine(FinishPloding());
	}
	
	public void AnimatePlosion(){
		Instantiate (plosionEffect, transform.position,Quaternion.identity);
		GameObject spherePulse = Instantiate (sphereEffect, transform.position,sphereQuaternion) as GameObject;
		spherePulse.transform.parent = transform;
		spherePulse.transform.localScale = transform.parent.localScale;
		plosionAnimator.SetInteger("AnimState",1);
	}

	public void AnimateReScale(){
		plosionAnimator.SetInteger("AnimState",2);
	}

	public void AnimateBigIdle(){
		plosionAnimator.SetInteger("AnimState",3);
		StartCoroutine(FinishPloding());
	}

	IEnumerator FinishPloding(){
		yield return null;
		yield return null;
		ploding = false;
	}

	void Plode(){
		ploding = true;
		foreach (Collider col in collidersToPlode){
			if (col.attachedRigidbody){
				float separationDistance = Vector3.Distance(transform.position,col.transform.position);
				Vector3 plosionDirection;
				float plosionForce;
				if (playerType == PlayerType.Explo){
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
	
	float FindExponentMultiplier(float cutoffTolerance, float distanceAway){
		return Mathf.Log(cutoffTolerance)/(-distanceAway);
	}
	
	void FindMoveableColliders(){
		collidersToPlode = Physics.OverlapSphere (transform.position,plosionRadius,-1,QueryTriggerInteraction.Ignore); 
		collidersToPlode = collidersToPlode.Where(foundCollider => (foundCollider.tag == Tags.moveableObjects || 
		                                                           (foundCollider.tag == Tags.explode_Objects && playerType == PlayerType.Explo) || 
		                                                           (foundCollider.tag == Tags.implode_Objects && playerType == PlayerType.Implo))).ToArray();

	}

	public void GetCurrentControls(){
		if (playerType == PlayerType.Explo){
			controls = GameManager.StaticControls.Explo_Controls;
		}
		else{
			controls = GameManager.StaticControls.Implo_Controls;
		} 
	}

	void EmitFog(){
		fog.Emit(10);
	}
}
