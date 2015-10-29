#region Declaration
using UnityEngine;
using System.Collections;
using GenericFunctions;

public class CollectableStar : MonoBehaviour {
#endregion

	#region Initialize Variables
	public GameObject shimmeringEffect;
	public AudioClip starNoise;
	public Renderer topRenderer;
	public Renderer bottomRenderer;
	private bool beenGotten;
	#endregion

	#region Trigger Star Collection
	void OnTriggerEnter(Collider col){
		if (col.gameObject.layer == Layers.player && !beenGotten){
			StartCoroutine(GetTheStar());
		}
	}
	#endregion

		#region Collect The Star
	IEnumerator GetTheStar(){
		beenGotten = true;
		Instantiate(shimmeringEffect,transform.position,transform.rotation * Quaternion.Euler(90f,0f,0f));
		AudioSource.PlayClipAtPoint(starNoise,Camera.main.transform.position);
		StartCoroutine(GameColor.TransitionMaterialColor(topRenderer.material,"_Color",GameColor.clearWhite,0.07f));
		yield return StartCoroutine(GameColor.TransitionMaterialColor(bottomRenderer.material,"_Color",GameColor.clearWhite,0.07f));
		Destroy(gameObject);
	}
		#endregion
}
