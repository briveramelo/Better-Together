using UnityEngine;
using System.Collections;
using GenericFunctions;
public class Pause : MonoBehaviour {

	public Controls controls;
	void Update () {
		if (Input.GetButtonDown(controls.Pause)){
			PauseLevel();
		}
	}
	
	void PauseLevel(){
		Time.timeScale = GameState.isPaused ? 1f : 0f;
		LevelItems.pauseMenu.SetActive(!LevelItems.pauseMenu.activeSelf);
		GameState.isPaused = !GameState.isPaused;
	}
}
