using UnityEngine;
using System.Collections;
using GenericFunctions;
public class CharacterSelect : MonoBehaviour {

	public Controls P1_Controls;
	public Controls P2_Controls;

	public Transform exploTran;
	public Transform imploTran;
	public Transform p1Tran;
	public Transform p2Tran;

	public AudioSource conradOpener;
	public AudioClip conrad_01;
	public AudioClip conrad1;
	public AudioClip toggle;
	public AudioClip select;

	private bool exploOnLeft;

	private float last_P1Horizontal;
	private float last_P2Horizontal;
	private bool selected;
	private float near1;
	void Awake(){
		exploOnLeft = true;
		near1 = .95f;
	}

	void Update(){
		if (!selected){

			if (Input.GetButtonDown(P1_Controls.Jump) || Input.GetButtonDown(P2_Controls.Jump)){
				StartCoroutine(LoadLevel(0));
			}
			else if (Input.GetButtonDown(P1_Controls.Restart) || Input.GetButtonDown(P2_Controls.Restart)){
				StartCoroutine(LoadLevel(-2));
			}
			
			if ( (Mathf.Abs (Input.GetAxisRaw( P1_Controls.Horizontal)) >near1 && Mathf.Abs (last_P1Horizontal) < near1)
			  || (Mathf.Abs (Input.GetAxisRaw( P2_Controls.Horizontal)) >near1 && Mathf.Abs (last_P2Horizontal) < near1)){
				SwitchPositions();
				AudioSource.PlayClipAtPoint(toggle,transform.position);
			}
			
			last_P1Horizontal = Input.GetAxisRaw( P1_Controls.Horizontal);
			last_P2Horizontal = Input.GetAxisRaw( P2_Controls.Horizontal);
		}

	}

	void SetControls(){
		GameManager.StaticControls.P1_Controls = exploOnLeft ? P1_Controls : P2_Controls;
	}

	IEnumerator LoadLevel(int levelNumber){
		SetControls ();
		conradOpener.Stop();
		AudioSource.PlayClipAtPoint(select,transform.position);
		selected = true;

		switch (levelNumber){
			case -2: AudioSource.PlayClipAtPoint(conrad_01,transform.position); break;
			case 0:  AudioSource.PlayClipAtPoint(conrad1,transform.position); break;
		}
		yield return new WaitForSeconds(5f);
		switch (levelNumber){
			case -2: Application.LoadLevel(Levels.homeScreen); break;
			case 0: Application.LoadLevel(Levels.mainMenu);	break;
		}
	}

	void SwitchPositions(){
		if (exploOnLeft){
			exploOnLeft = false;
			exploTran.position = p2Tran.position;
			imploTran.position = p1Tran.position;
		}
		else{
			exploOnLeft = true;
			exploTran.position = p1Tran.position;
			imploTran.position = p2Tran.position;
		}
	} 
}