using UnityEngine;
using System.Collections;
using GenericFunctions;

public class AudioActivator : Activator {

	public AudioSource audioSourcePlayer;
	public AudioClip enterSound;
	public AudioClip stayLoopSound;
	public AudioClip exitSound;

	protected override void ActivateObjects(){
		audioSourcePlayer.Stop();

		if (triggerType == TriggerType.OnTriggerEnter){
			audioSourcePlayer.clip = enterSound;
			audioSourcePlayer.loop = false;
		}
		else if (triggerType == TriggerType.OnTriggerStay){
			audioSourcePlayer.clip = stayLoopSound;
			audioSourcePlayer.loop = true;
		}
		else if (triggerType == TriggerType.OnTriggerExit){
			audioSourcePlayer.clip = exitSound;
			audioSourcePlayer.loop = false;
		}

		audioSourcePlayer.Play();
	}
}
