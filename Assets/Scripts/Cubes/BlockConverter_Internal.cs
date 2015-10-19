using UnityEngine;
using System.Collections;
using GenericFunctions;

public class BlockConverter_Internal : MonoBehaviour {

	public Material[] cubeMaterials;
	//0 neither
	//1 explosive
	//2 implosive
	//3 both
	public Renderer myRenderer;
	public Animator myAnimator;
	private BlockType blockType;
	public AudioSource popNoise;

	public void BeginBlockConversion(BlockType block){
		blockType = block;
		popNoise.Play();
		myAnimator.SetInteger("AnimState",1);
	}
	
	public void MakeCubeInteractable(){
		if (blockType == BlockType.Immoveable){
			gameObject.tag = Tags.immoveable_Objects;
			myRenderer.material = cubeMaterials[0];
		}
		else if (blockType == BlockType.Moveable_Explo){
			gameObject.tag = Tags.explode_Objects;
			myRenderer.material = cubeMaterials[1];
		}
		else if (blockType == BlockType.Moveable_Implo){
			gameObject.tag = Tags.implode_Objects;
			myRenderer.material = cubeMaterials[2];
		}
		else if (blockType == BlockType.Moveable){
			gameObject.tag = Tags.moveableObjects;
			myRenderer.material = cubeMaterials[3];
		}
	}

	public void FinishConversion(){
		myAnimator.SetInteger("AnimState",0);
	}
	
}
