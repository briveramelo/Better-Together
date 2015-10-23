using UnityEngine;
using System.Collections;
using GenericFunctions;

public class Controls : MonoBehaviour {

	public PlayerType playerType; 

	private bool isExplo;
	private string horizontal;
	private string vertical;
	private string action; 
	private string jump;
	private string pause;
	private string toss;
	private string door;
	private string toggleCamera;
	private string restart;

	public string Horizontal{ get{return horizontal;}}
	public string Vertical{ get{return vertical;}}
	public string Action{ get{return action;}}
	public string Jump{ get{return jump;}}
	public string Pause{ get{return pause;}}
	public string Toss{get{return toss;}}
	public string Door{ get{return door;}}
	public string ToggleCamera{get{return toggleCamera;}}
	public string Restart{ get{return restart;}}
	public bool IsExplo{get{return isExplo;}}	

	void Awake(){
		SetControls(playerType);
	}

	public void SetControls(PlayerType playerType){
		if (playerType == PlayerType.Explo){
			horizontal = "P1_Horizontal";
			vertical = "P1_Vertical";
			action = "P1_Action";
			jump = "P1_Jump";
			pause = "P1_Pause";
			toss = "P1_Toss";
			door = "P1_Door";
			toggleCamera = "P1_ToggleCamera";
			restart = "P1_Restart";
			isExplo = true;
		}
		else if (playerType == PlayerType.Implo){
			horizontal = "P2_Horizontal";
			vertical = "P2_Vertical";
			action = "P2_Action";
			jump = "P2_Jump";
			pause = "P2_Pause";
			toss = "P2_Toss";
			door = "P2_Door";
			toggleCamera = "P2_ToggleCamera";
			restart = "P2_Restart";
			isExplo = false;
		}
	}

}
