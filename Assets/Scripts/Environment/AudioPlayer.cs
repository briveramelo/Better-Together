using UnityEngine;
using System.Collections;
using GenericFunctions;
public class AudioPlayer : MonoBehaviour {

	public AudioSource audioSourcePlayer;
	public AudioClip enterSound;
	public AudioClip stayLoopSound;
	public AudioClip exitSound;

	public bool dependOnPlayerType;
	public PlayerType playerType;

	private enum Triggers{
		Enter,
		Stay,
		Exit
	}
	
	void OnTriggerEnter(Collider col){
		if (col.gameObject.layer == Layers.player){
			if (col.gameObject.GetComponent<TypeOfPlayer>().PlayerType == playerType){
				PlayNewSound(Triggers.Enter);
			}
		}
	}

	void OnTriggerStay(Collider col){
		if (col.gameObject.layer == Layers.player){
			if (col.gameObject.GetComponent<TypeOfPlayer>().PlayerType == playerType){
				if (audioSourcePlayer.clip != stayLoopSound){
					PlayNewSound(Triggers.Stay);
				}
			}
		}
	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.layer == Layers.player){
			if (col.gameObject.GetComponent<TypeOfPlayer>().PlayerType == playerType){
				PlayNewSound(Triggers.Exit);
			}
		}
	}

	void PlayNewSound(Triggers triggerType){
		audioSourcePlayer.Stop();

		if (triggerType == Triggers.Enter){
			audioSourcePlayer.clip = enterSound;
			audioSourcePlayer.loop = false;
		}
		else if (triggerType == Triggers.Stay){
			audioSourcePlayer.clip = stayLoopSound;
			audioSourcePlayer.loop = true;
		}
		else if (triggerType == Triggers.Exit){
			audioSourcePlayer.clip = exitSound;
			audioSourcePlayer.loop = false;
		}

		audioSourcePlayer.Play();
	}
}
