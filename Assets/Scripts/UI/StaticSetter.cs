using UnityEngine;
using System.Collections;
using GenericFunctions;

public class StaticSetter : MonoBehaviour {

	public GameObject pauseMenu;
	void Awake(){
		LevelItems.pauseMenu = pauseMenu;
	}

}
