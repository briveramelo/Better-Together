using UnityEngine;
using System.Collections;
using GenericFunctions;

public class Controls : MonoBehaviour {

	public PlayerType playerType; 

	private string horizontal;
	private string vertical;
	private string action; 
	private string jump;
	private string pause;
	private string restart;
	private string door;

	public string Horizontal{ get{return horizontal;}}
	public string Vertical{ get{return vertical;}}
	public string Action{ get{return action;}}
	public string Jump{ get{return jump;}}
	public string Pause{ get{return pause;}}
	public string Restart{ get{return restart;}}
	public string Door{ get{return door;}}
		
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
			restart = "P1_Restart";
			door = "P1_Door";
		}
		else if (playerType == PlayerType.Implo){
			horizontal = "P2_Horizontal";
			vertical = "P2_Vertical";
			action = "P2_Action";
			jump = "P2_Jump";
			pause = "P2_Pause";
			restart = "P2_Restart";
			door = "P2_Door";
		}
	}

}
