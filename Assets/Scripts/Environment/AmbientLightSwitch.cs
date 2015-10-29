#region Declaration
using UnityEngine;
using System.Collections;
using GenericFunctions;

public class AmbientLightSwitch : MonoBehaviour {
#endregion

	#region Initialize Variables
	public float intensity;
	#endregion

	#region Trigger Light Switch
	void OnEnable(){
		ChangeAmbientLight();
	}
	#endregion

		#region Turn Out The Light
	public void ChangeAmbientLight(){
		RenderSettings.ambientIntensity = intensity;
		Camera.main.backgroundColor = GameColor.CameraBackground.darkCloset;
	}
		#endregion

}
