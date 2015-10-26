using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

	public Keyhole keyhole;
	public int keyNumber;

	void OnEnable(){
		if (keyNumber<keyhole.keys.Length){
			keyhole.StartCoroutine(keyhole.ActivateKey(keyNumber));
		}
		this.enabled = false;
	}
}
