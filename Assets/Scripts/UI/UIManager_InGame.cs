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
		Application.LoadLevel(Application.loadedLevelName);
	}

	public void ReturnToMainMenu(){
		UnPause();
		Application.LoadLevel(Levels.mainMenu);
	}

	public void ViewControls(){
		controlImage.SetActive(!controlImage.activeSelf);
	}

	void UnPause(){
		GameState.isPaused = false;
		Time.timeScale = 1;
	}
}
