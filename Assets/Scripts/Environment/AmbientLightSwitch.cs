using UnityEngine;
using System.Collections;
using GenericFunctions;

public class AmbientLightSwitch : MonoBehaviour {

	public float intensity;

	void Awake(){
		this.enabled = false;
	}

	void Start(){
		ChangeAmbientLight();
	}

	public void ChangeAmbientLight(){
		RenderSettings.ambientIntensity = intensity;
		Camera.main.backgroundColor = GameColors.darkCloset;
	}
}
