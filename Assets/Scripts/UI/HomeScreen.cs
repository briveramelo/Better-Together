using UnityEngine;
using System.Collections;
using GenericFunctions;
public class HomeScreen : MonoBehaviour {

	public Controls P1_Controls;
	public Controls P2_Controls;

	public GameObject title;
	public GameObject startButton;
	public AudioClip introAudio;

	void Awake(){
		AudioSource.PlayClipAtPoint(introAudio,Camera.main.transform.position);
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
		if (Input.GetButton(P1_Controls.Action) || Input.GetButton(P2_Controls.Action)||
		    Input.GetButton(P1_Controls.Jump) || Input.GetButton(P2_Controls.Jump)||
		    Input.GetButton(P1_Controls.Pause) || Input.GetButton(P2_Controls.Pause)||
		    Input.GetButton(P1_Controls.Toss) || Input.GetButton(P2_Controls.Toss)||
		    Input.GetButton(P1_Controls.Door) || Input.GetButton(P2_Controls.Door)||
		    Input.GetButton(P1_Controls.ToggleCamera) || Input.GetButton(P2_Controls.ToggleCamera)||
		    Input.GetButton(P1_Controls.Restart) || Input.GetButton(P2_Controls.Restart)){
			Levels.LoadLevel(LevelNames.LevelSelect);
		}
	}
}
