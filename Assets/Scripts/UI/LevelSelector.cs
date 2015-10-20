using UnityEngine;
using System.Collections;
using GenericFunctions;
public class LevelSelector : MonoBehaviour {
	
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

	void Update(){
		if (Input.GetButtonDown(GameManager.StaticControls.P1_Controls.Restart)
		 || Input.GetButtonDown(GameManager.StaticControls.P2_Controls.Restart)){
			LoadLevel(-1);
		}
	}
}
