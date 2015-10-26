using UnityEngine;
using System.Collections;

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
	}
}
