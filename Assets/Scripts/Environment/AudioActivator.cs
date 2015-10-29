#region Declaration
using UnityEngine;
using System.Collections;
using GenericFunctions;

public class AudioActivator : MonoBehaviour {
#endregion


	#region Initialize Variables
	public bool dependsOnPlayerType;
	public PlayerType playerType;
	public bool oneOff;
	private bool done;
	public AudioSource audioSourcePlayer;
	public AudioClip enterSound;
	public AudioClip stayLoopSound;
	public AudioClip exitSound;
	#endregion

	#region Audio Triggers
	//code?
	#endregion

		#region OnTriggerEnter
	void OnTriggerEnter(Collider col){
		if (enabled){
			if (col.gameObject.layer == Layers.player){
				if (!dependsOnPlayerType || col.GetComponent<TypeOfPlayer>().PlayerType == playerType){
					if (oneOff && !done || !oneOff){
						ActivateObjects(TriggerType.OnTriggerEnter);
					}
				}
			}
		}
	}
		#endregion

		#region OnTriggerStay
	void OnTriggerStay(Collider col){
		if (enabled){
			if (col.gameObject.layer == Layers.player){
				if (!dependsOnPlayerType || col.GetComponent<TypeOfPlayer>().PlayerType == playerType){
					if (oneOff && !done || !oneOff){
						if (audioSourcePlayer.clip != stayLoopSound){
							ActivateObjects(TriggerType.OnTriggerStay);
						}
					}
				}
			}
		}
	}
		#endregion

		#region OnTriggerExit  
	void OnTriggerExit(Collider col){
		if (enabled){
			if (col.gameObject.layer == Layers.player){
				if (!dependsOnPlayerType || col.GetComponent<TypeOfPlayer>().PlayerType == playerType){
					if (oneOff && !done || !oneOff){
						ActivateObjects(TriggerType.OnTriggerExit);
					}
				}
			}
		}
	}
		#endregion


	#region Activate Audio!
	void ActivateObjects(TriggerType triggerType){
		done = true;
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
	#endregion
}
