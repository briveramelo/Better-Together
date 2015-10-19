using UnityEngine;
using System.Collections;

public class UI_Animation : MonoBehaviour {

	public Animator myAnimator;

	public void SetAnimState(int animState){
		if (myAnimator.GetInteger("AnimState")!=animState){
			myAnimator.SetInteger("AnimState", animState);
		}
	}

}
