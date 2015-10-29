#region Declaration
using UnityEngine;
using System.Collections;

public class ExploSphereSceneAnimatorScript : MonoBehaviour {
#endregion

	#region Initialize Variables

	public GameObject sphereEffect;
	public GameObject explosionEffect;
	public Animator explosionAnimator;
	public ParticleSystem fog;
	private bool forwardInTime;
	public bool ForwardInTime{get{return forwardInTime;}set{forwardInTime = value;}}
	private Quaternion sphereQuaternion;
	void Awake () {
		sphereQuaternion = Quaternion.Euler (0f,25f,270f);
		forwardInTime = true;
	}
	#endregion

	public void Fwd_Explode(){
		if (forwardInTime){
			Instantiate (explosionEffect, transform.position,Quaternion.identity);
			GameObject spherePulse = Instantiate (sphereEffect, transform.position,sphereQuaternion) as GameObject;
			spherePulse.transform.parent = transform;
			spherePulse.transform.localScale = transform.parent.localScale;
			explosionAnimator.SetInteger("AnimState",1);
		}
	}

	public void Bkwd_Explode(){
		if (!forwardInTime){
			explosionAnimator.SetInteger("AnimState",1);
		}
	}

	public void Fwd_DisableFog(){
		if (forwardInTime){
			fog.enableEmission = false;
		}
	}

	public void Bkwd_DisableFog(){
		if (!forwardInTime){
			fog.enableEmission = false;
		}
	}

	public void Fwd_EnableFog(){
		if (forwardInTime){
			fog.enableEmission = true;
		}
	}

	public void Bkwd_EnableFog(){
		if (!forwardInTime){
			fog.enableEmission = true;
		}
	}
	
	public void Fwd_Shrink(){
		if (forwardInTime){
			explosionAnimator.SetInteger("AnimState",2);
		}
	}

	public void Bkwd_Shrink(){
		if (!forwardInTime){
			explosionAnimator.SetInteger("AnimState",2);
		}
	}
	
	public void Fwd_IdleSmall(){
		if (forwardInTime){
			explosionAnimator.SetInteger("AnimState",0);
		}
	}

	public void Bkwd_IdleSmall(){
		if (!forwardInTime){
			explosionAnimator.SetInteger("AnimState",0);
		}
	}
}
