using UnityEngine;
using System.Collections;
using GenericFunctions;
public class UIManager_InGame : MonoBehaviour {

	public GameObject controlImage;
	public GameObject pauseMenu;

	void Awake(){
		LevelItems.pauseMenu = pauseMenu;
	}

	public void Continue(){
		UnPause();
		pauseMenu.SetActive(false);
	}

	public void RestartLevel(){
		UnPause();
		Levels.LoadLevel(LevelNames.Current);
	}

	public void ReturnToLevelSelect(){
		UnPause();
		Levels.LoadLevel(LevelNames.LevelSelect);
	}

	public void ViewControls(){
		controlImage.SetActive(!controlImage.activeSelf);
	}

	void UnPause(){
		GameState.isPaused = false;
		Time.timeScale = 1;
	}
}
