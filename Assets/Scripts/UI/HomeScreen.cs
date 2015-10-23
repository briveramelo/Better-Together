using UnityEngine;
using System.Collections;
using GenericFunctions;
public class HomeScreen : MonoBehaviour {

	public Controls P1_Controls;
	public Controls P2_Controls;

	public GameObject title;
	public GameObject startButton;

	void Awake(){
		Invoke ("ActivateTitle",7.4f);
		Invoke ("ActivateStartButton",9.5f);
	}

	void ActivateTitle(){
		title.SetActive(true);
	}

	void ActivateStartButton(){
		startButton.SetActive(true);
	}

	void Update(){
		if (Input.GetButton(P1_Controls.Pause) || Input.GetButton(P2_Controls.Pause)){
			Application.LoadLevel(Levels.characterSelect);
		}
	}
}
