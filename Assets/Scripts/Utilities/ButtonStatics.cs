using UnityEngine;
using System.Collections;
using GenericFunctions;
public class ButtonStatics : MonoBehaviour {

	public TypeOfPlayer typeOfPlayer;
	public GameObject x_Button;
	public GameObject y_Button;

	void Awake(){
		if (typeOfPlayer.PlayerType == PlayerType.Explo){
			Players.explo_x_button = x_Button;
			Players.explo_y_button = y_Button;
		}
		else{
			Players.implo_x_button = x_Button;
			Players.implo_y_button = y_Button;
		}


	}
}
