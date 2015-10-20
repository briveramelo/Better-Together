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
		if (Input.GetButtonDown(P1_Controls.Pause) || Input.GetButtonDown(P2_Controls.Pause)){
			LoadLevel(-1);
		}
	}

	public void LoadLevel(int levelNumber){
		switch (levelNumber){
		case -1: Application.LoadLevel(Levels.characterSelect); break;
		case 0: Application.LoadLevel(Levels.mainMenu); break;
		case 1: Application.LoadLevel(Levels.level1); break;
		case 2: Application.LoadLevel(Levels.level2); break;
		case 3: Application.LoadLevel(Levels.level3); break;
		case 4: Application.LoadLevel(Levels.level4); break;
		case 5: Application.LoadLevel(Levels.level5); break;
		case 6: Application.LoadLevel(Levels.level6); break;
		}
	}
}
