using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {

	public AudioSource select;
	public AudioSource toggle;

	public void PlayToggle(){
		toggle.Play ();
	}

	public void PlaySelect(){
		select.Play();
	}
}
