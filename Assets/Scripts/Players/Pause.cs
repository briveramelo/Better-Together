using UnityEngine;
using System.Collections;
using GenericFunctions;

public class Pause : MonoBehaviour {


	private Controls controls;
	public PlayerType playerType;

	void Start(){
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
			StartCoroutine(PauseLevel());
		}
	}
	
	IEnumerator PauseLevel(){
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
		yield return null;
		Time.timeScale = GameState.isPaused ? 0f : 1f;
	}
}
