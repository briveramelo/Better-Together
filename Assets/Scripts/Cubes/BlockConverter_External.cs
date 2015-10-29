#region Declaration
using UnityEngine;
using System.Collections;
using GenericFunctions;
public class BlockConverter_External : MonoBehaviour {
#endregion

	#region Initialize Variables
	public BlockType convertToThisBlock;
	#endregion
	
	#region Trigger Block Conversion OnTriggerEnter
	void OnTriggerEnter(Collider col){
		if ((col.gameObject.CompareTag(Tags.explode_Objects)||
		    col.gameObject.CompareTag(Tags.implode_Objects)||
		    col.gameObject.CompareTag(Tags.moveable_Objects))&&
		    (!col.gameObject.CompareTag(convertToThisBlock.ToString()))){

			col.GetComponent<BlockConverter_Internal>().BeginBlockConversion(convertToThisBlock);
		}
	}
	#endregion
}
