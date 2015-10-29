#region Declaration
using UnityEngine;
using System.Collections;
using GenericFunctions;
using System.Collections.Generic;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {
#endregion

	#region Initialize Variables
	private LevelNames selectedLevel;
	public LevelNames SelectedLevel{set{selectedLevel = value;}}
	public AudioClip toggle;

	public GameObject imploShield;
	public GameObject exploShield;
	public ParticleSystemRenderer exploFogRenderer;
	private Material imploShieldMaterial;
	private Material exploShieldMaterial;
	public Material cubeFader;
	public Material imploFader; 
	public Material exploFader;
	
	private float p1Horizontal;
	private float p2Horizontal;
	private float last_p1Horizontal;
	private float last_p2Horizontal;
	private bool animating;
	private bool selectingLevel;

	void Awake(){
		exploShieldMaterial = exploShield.GetComponent<MeshRenderer>().material;
		imploShieldMaterial = imploShield.GetComponent<MeshRenderer>().material;
		cubeFader.color = GameColor.fader;
		exploFader.color = GameColor.fader;
		imploFader.color = GameColor.fader;
		selectedLevel = LevelNames.Level1;
	}
	#endregion

	#region Update
	void Update(){
		if (!selectingLevel){
			p1Horizontal = Input.GetAxisRaw( GameManager.StaticControls.P1_Controls.Horizontal);
			p2Horizontal = Input.GetAxisRaw( GameManager.StaticControls.P2_Controls.Horizontal);
			
			CheckToReturnToHomeScreen();
			CheckToToggleLevelHighlight ();
			CheckToSelectLevel();
			
			last_p1Horizontal = Input.GetAxisRaw( GameManager.StaticControls.P1_Controls.Horizontal);
			last_p2Horizontal = Input.GetAxisRaw( GameManager.StaticControls.P2_Controls.Horizontal);
		}
	}
	#endregion

		#region Input Checks

			#region HomeScreen
	void CheckToReturnToHomeScreen(){
		if (Input.GetButtonDown(GameManager.StaticControls.P1_Controls.Toss)||
		    Input.GetButtonDown(GameManager.StaticControls.P2_Controls.Toss)){
			Levels.LoadLevel(LevelNames.HomeScreen);
		}
	}
			#endregion

			#region LevelHighlight Check

				#region Check If Either Player is Toggling
	void CheckToToggleLevelHighlight(){
		CheckToToggleLevelHighlightByPlayer(p1Horizontal,last_p1Horizontal);
		CheckToToggleLevelHighlightByPlayer(p2Horizontal,last_p2Horizontal);
	}
				#endregion

				#region Trigger Animations
	void CheckToToggleLevelHighlightByPlayer(float playerHor, float lastPlayerHor){
		if ( (Mathf.Abs (playerHor) > Constants.near1 && Mathf.Abs (lastPlayerHor) < Constants.near1)){
			if (playerHor<-Constants.near1){
				if ((int)selectedLevel>1){
					if (!animating){
						ChangeSelectedLevel(false);
						StartCoroutine(AnimateScene());
					}
				}
			}
			else{
				if ((int)selectedLevel<(int)GameManager.theInstance.HighestAccessibleLevel){
					if (!animating){
						ChangeSelectedLevel(true);
						StartCoroutine(AnimateScene());
					}
				}
			}
		}
	}
				#endregion
			
				#region Change Selected Level
	void ChangeSelectedLevel(bool levelUp){
		selectedLevel = levelUp ? selectedLevel+1 : selectedLevel-1;
	}
				#endregion

			#endregion
	
			#region Select Level
	void CheckToSelectLevel(){
		if (Input.GetButtonDown(GameManager.StaticControls.P1_Controls.Jump)||
		    Input.GetButtonDown(GameManager.StaticControls.P1_Controls.Pause)||
		    Input.GetButtonDown(GameManager.StaticControls.P1_Controls.Action)||
		    Input.GetButtonDown(GameManager.StaticControls.P2_Controls.Jump)||
		    Input.GetButtonDown(GameManager.StaticControls.P2_Controls.Pause)||
		    Input.GetButtonDown(GameManager.StaticControls.P2_Controls.Action)){
			
			StartCoroutine(SelectLevelDelay());
		}
	}
	
	IEnumerator SelectLevelDelay(){
		selectingLevel = true;
		yield return new WaitForSeconds(1f);
		Levels.LoadLevel(selectedLevel);
	}
			#endregion

		#endregion

		#region AnimateScene
	IEnumerator AnimateScene(){
		animating = true;
		AudioSource.PlayClipAtPoint(toggle,Camera.main.transform.position);

		switch ((int)selectedLevel){
		
		case (int)LevelNames.Level1:
			ToggleCubeSpinning(false);
			StartCoroutine(GameColor.TransitionMaterialColor(exploFader,"_Color",GameColor.clearWhite,0.1f));
			StartCoroutine(GameColor.TransitionMaterialFloat(exploShieldMaterial,"_ColorStrength",5f,0.1f));
			StartCoroutine(GameColor.TransitionMaterialFloat(exploFogRenderer.material,"_ColorStrength",1.6f,0.07f));

			yield return StartCoroutine(GameColor.TransitionMaterialColor(cubeFader,"_Color",GameColor.fader,0.1f));
			break;

		case (int)LevelNames.Level2:
			ToggleCubeSpinning(true);
			StartCoroutine(GameColor.TransitionMaterialColor(exploFader,"_Color",GameColor.fader,0.1f));
			StartCoroutine(GameColor.TransitionMaterialFloat(exploShieldMaterial,"_ColorStrength",0.3f,0.07f));
			StartCoroutine(GameColor.TransitionMaterialFloat(exploFogRenderer.material,"_ColorStrength",0.3f,0.07f));

			StartCoroutine(GameColor.TransitionMaterialColor(cubeFader,"_Color",GameColor.clearWhite,0.1f));

			StartCoroutine(GameColor.TransitionMaterialColor(imploFader,"_Color",GameColor.fader,0.1f));
			yield return StartCoroutine(GameColor.TransitionMaterialFloat(imploShieldMaterial,"_ColorStrength",0.3f,0.1f));
			break;

		case (int)LevelNames.Level3:
			ToggleCubeSpinning(false);
			StartCoroutine(GameColor.TransitionMaterialColor(cubeFader,"_Color",GameColor.fader,0.1f));

			StartCoroutine(GameColor.TransitionMaterialColor(imploFader,"_Color",GameColor.clearWhite,0.1f));
			StartCoroutine(GameColor.TransitionMaterialFloat(imploShieldMaterial,"_ColorStrength",3f,0.1f));
			break;
		}

		animating = false;
		yield return null;

	}


	void ToggleCubeSpinning(bool spin){
		foreach (StarSpinner starSpinner in FindObjectsOfType<StarSpinner>()){
			starSpinner.enabled = spin;
		}
	}

		#endregion

}
