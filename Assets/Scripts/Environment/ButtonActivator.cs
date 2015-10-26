using UnityEngine;
using System.Collections;
using GenericFunctions;

public class ButtonActivator : Activator {

	public ButtonType buttonType;

	protected override void ActivateObjects(){
		if (noise){
			noise.Play();
		}
		done = true;
		if (playerType == PlayerType.Explo){
			if (buttonType == ButtonType.X){
				Players.explo_x_Button.SetActive(activateOnTrigger);
			}
			else if (buttonType == ButtonType.Y){
				Players.explo_y_Button.SetActive(activateOnTrigger);
			}
			else if (buttonType == ButtonType.B){
				Players.explo_b_Button.SetActive(activateOnTrigger);
			}
		}
		else{
			if (buttonType == ButtonType.X){
				Players.implo_x_Button.SetActive(activateOnTrigger);
			}
			else if (buttonType == ButtonType.Y){
				Players.implo_y_Button.SetActive(activateOnTrigger);
			}
			else if (buttonType == ButtonType.B){
				Players.implo_b_Button.SetActive(activateOnTrigger);
			}
		}
	}

}
