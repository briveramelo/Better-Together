using UnityEngine;
using System.Collections;
using GenericFunctions;
public class BlockConverter_External : MonoBehaviour {

	public BlockType convertToThisBlock;

	void OnTriggerEnter(Collider col){
		if ((col.gameObject.CompareTag(Tags.explode_Objects)||
		    col.gameObject.CompareTag(Tags.implode_Objects)||
		    col.gameObject.CompareTag(Tags.moveableObjects))&&
		    (!col.gameObject.CompareTag(convertToThisBlock.ToString()))){

			col.GetComponent<BlockConverter_Internal>().BeginBlockConversion(convertToThisBlock);
		}
	}
}
