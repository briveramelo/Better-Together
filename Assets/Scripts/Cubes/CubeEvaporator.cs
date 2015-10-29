#region Declaration
using UnityEngine;
using System.Collections;
using GenericFunctions;
public class CubeEvaporator : MonoBehaviour {
#endregion
	
	#region Trigger Evaporation
	void OnEnable () {
		StartCoroutine(Evaporate());
	}
	#endregion

	#region Evaporate
	IEnumerator Evaporate(){
		if (Players.explo){
			if (Players.explo.GetComponent<Collider>()){
				Physics.IgnoreCollision(GetComponent<Collider>(),Players.explo.GetComponent<Collider>());
			}
		}
		if (Players.implo){
			if (Players.implo.GetComponent<Collider>()){
				Physics.IgnoreCollision(GetComponent<Collider>(),Players.implo.GetComponent<Collider>());
			}
		}
		yield return StartCoroutine(GameColor.TransitionMaterialColor(GetComponent<Renderer>().material,"_Color", GameColor.clearWhite,0.03f));
		Destroy(gameObject);
	}
	#endregion

}
