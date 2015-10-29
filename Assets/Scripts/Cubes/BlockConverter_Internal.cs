#region Declaration
using UnityEngine;
using System.Collections;
using GenericFunctions;

public class BlockConverter_Internal : MonoBehaviour {
#endregion

	#region Initialize Variables
	public Material[] cubeMaterials;
	public Renderer myRenderer;
	public Animator myAnimator;
	public AudioSource popNoise;
	private BlockType blockType;

	public void BeginBlockConversion(BlockType block){
		blockType = block;
		popNoise.Play();
		myAnimator.SetInteger("AnimState",1);
	}
	#endregion

	#region Convert Block!
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
			gameObject.tag = Tags.moveable_Objects;
			myRenderer.material = cubeMaterials[3];
		}
	}
	#endregion

	#region Animator access
	public void FinishConversion(){
		myAnimator.SetInteger("AnimState",0);
	}
	#endregion
	
}
