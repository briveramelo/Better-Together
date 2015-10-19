using UnityEngine;
using System.Collections;

public class InputTest : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("P1_Jump")){
			Debug.Log("Jumped");
		}
	}
}
