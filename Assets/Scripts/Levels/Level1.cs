using UnityEngine;
using System.Collections;
using GenericFunctions;
public class Level1 : MonoBehaviour {

	public AudioClip conradIntro;
	public Collider imploCube;
	public Collider invisibleWalls;

	// Use this for initialization
	void Start () {
		//AudioSource.PlayClipAtPoint(conradIntro,Camera.main.transform.position);
		Physics.IgnoreCollision(imploCube,invisibleWalls);
	}
}