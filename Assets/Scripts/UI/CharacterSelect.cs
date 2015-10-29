using UnityEngine;
using System.Collections;
using GenericFunctions;
public class CharacterSelect : MonoBehaviour {
	
//	public Transform exploTran;
//	public Transform imploTran;
//	public Transform p1Tran;
//	public Transform p2Tran;
//
//	public AudioSource conradOpener;
//	public AudioClip conrad_01;
//	public AudioClip conrad1;
//	public AudioClip toggle;
//	public AudioClip select;
//
//	private bool exploOnLeft;
//
//	private float last_P1Horizontal;
//	private float last_P2Horizontal;
//	private bool selected;
//	void Awake(){
//		exploOnLeft = true;
//	}
//
//	void Update(){
//		if (!selected){
//
//			if (Input.GetButtonDown(GameManager.StaticControls.P1_Controls.Jump)||
//			    Input.GetButtonDown(GameManager.StaticControls.P1_Controls.Pause)||
//			    Input.GetButtonDown(GameManager.StaticControls.P1_Controls.Action)){
//				StartCoroutine(LoadScene(LevelNames.LevelSelect));
//			}
//			else if (Input.GetButtonDown(GameManager.StaticControls.P1_Controls.Toss)){
//				StartCoroutine(LoadScene(LevelNames.HomeScreen));
//			}
//			
//			if ( (Mathf.Abs (Input.GetAxisRaw(GameManager.StaticControls.P1_Controls.Horizontal)) >Constants.near1 && Mathf.Abs (last_P1Horizontal) < Constants.near1)){
//				SwitchPositions();
//				AudioSource.PlayClipAtPoint(toggle,Camera.main.transform.position);
//			}
//			
//			last_P1Horizontal = Input.GetAxisRaw( GameManager.StaticControls.P1_Controls.Horizontal);
//		}
//
//	}
//
//	void SetControls(){
//		GameManager.StaticControls.P1_Controls = exploOnLeft ? 
//			GameManager.StaticControls.Explo_Controls : GameManager.StaticControls.Implo_Controls;
//	}
//
//	IEnumerator LoadScene(LevelNames levelName){
//		SetControls ();
//		conradOpener.Stop();
//		AudioSource.PlayClipAtPoint(select,Camera.main.transform.position);
//		selected = true;
//
//		switch (levelName){
//			case LevelNames.HomeScreen: AudioSource.PlayClipAtPoint(conrad_01,Camera.main.transform.position); break;
//			case LevelNames.LevelSelect:  AudioSource.PlayClipAtPoint(conrad1,Camera.main.transform.position); break;
//		}
//		yield return new WaitForSeconds(5f);
//		Levels.LoadLevel(LevelNames.HomeScreen);
//	}
//
//	void SwitchPositions(){
//		if (exploOnLeft){
//			exploOnLeft = false;
//			exploTran.position = p2Tran.position;
//			imploTran.position = p1Tran.position;
//		}
//		else{
//			exploOnLeft = true;
//			exploTran.position = p1Tran.position;
//			imploTran.position = p2Tran.position;
//		}
//	} 
}