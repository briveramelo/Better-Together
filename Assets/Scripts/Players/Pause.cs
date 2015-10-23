using UnityEngine;
using System.Collections;
using GenericFunctions;
public class Pause : MonoBehaviour {

	private Controls controls;
	public TypeOfPlayer typeOfPlayer;

	void Awake(){
		GetCurrentControls();
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

	public void GetCurrentControls(){
		if (typeOfPlayer.PlayerType == PlayerType.Explo){
			controls = GameManager.StaticControls.Explo_Controls;
		}
		else{
			controls = GameManager.StaticControls.Implo_Controls;
		} 
	}
}
