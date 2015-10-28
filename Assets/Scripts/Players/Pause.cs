using UnityEngine;
using System.Collections;
using GenericFunctions;

public class Pause : MonoBehaviour {


	private Controls controls;
	public PlayerType playerType;

	void Awake(){
		GetCurrentControls();
	}

	public void GetCurrentControls(){
		if (playerType == PlayerType.Explo){
			controls = GameManager.StaticControls.Explo_Controls;
		}
		else{
			controls = GameManager.StaticControls.Implo_Controls;
		} 
	}

	void Update () {
		if (Input.GetButtonDown(controls.Pause)){
			PauseLevel();
		}
	}
	
	void PauseLevel(){
		Time.timeScale = GameState.isPaused ? 1f : 0f;
		LevelItems.pauseMenu.SetActive(!LevelItems.pauseMenu.activeSelf);
		GameState.isPaused = !GameState.isPaused;
		foreach (AudioSource aud in FindObjectsOfType<AudioSource>()){
			if (GameState.isPaused){
				aud.Pause();
			}
			else{
				aud.UnPause();
			}
		}
	}
}
