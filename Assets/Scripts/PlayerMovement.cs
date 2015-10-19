#region Declaration
using UnityEngine;
using System.Collections;
using GenericFunctions;

public class PlayerMovement : MonoBehaviour {
#endregion

	#region Initialize Variables
	public TypeOfPlayer typeOfPlayer;
	public Controls controls;
	public Rigidbody playerBody;
	public Transform feet;
	public Ploder ploderScript;

	private bool isPaused;
	private bool grounded;
	private float lastXAxisInput;
	private float deadSize;

	[Range(2,5)]
	public float maxSpeed;

	[Range(0,6)]
	public float moveForce;

	[Range(500f,1000f)]
	public float jumpForce;

	void Awake(){
		moveForce = .3f;
		deadSize = 0.5f;
		controls.SetControls(typeOfPlayer.PlayerType);
		SetSpeed(typeOfPlayer.PlayerType);
		Physics.IgnoreLayerCollision(Layers.player, Layers.player, true);
		Physics.IgnoreLayerCollision(Layers.player, Layers.invisibleWAlls, true);
	}
	#endregion

	void SetSpeed(PlayerType playerType){
		if (playerType == PlayerType.Explo){
			//explosive jump, moderate running
			maxSpeed = 5f;
			jumpForce = 800f;
		}
		else if (playerType == PlayerType.Implo){
			//quick running, mild jump
			maxSpeed = 7f;
			jumpForce = 600f;
		}
	}

	// Update is called once per frame
	void Update () {
		bool willPause = Input.GetButtonDown(controls.Pause);
		if (willPause){
			Pause();
		}
	}

	void FixedUpdate(){
		bool willJump = Input.GetButtonDown(controls.Jump) && grounded;
		float xAxisInput = Input.GetAxisRaw(controls.Horizontal);
		bool willMoveSideways = Mathf.Abs (xAxisInput)>0 &&
			(Mathf.Abs (playerBody.velocity.x)<(maxSpeed *Mathf.Abs (xAxisInput)) || Mathf.Sign (playerBody.velocity.x)!= Mathf.Sign(xAxisInput));
		bool willBrake = grounded && Mathf.Abs (lastXAxisInput)>deadSize && Mathf.Abs (xAxisInput) <deadSize;

		CheckForGround();
		if (willJump){
			Jump();
		}

		if (willMoveSideways){
			MoveSideways(xAxisInput);
		}
		if (willBrake){
			Brake();
		}
		lastXAxisInput = xAxisInput;
	}

	void Brake(){
		playerBody.velocity = new Vector3(0f,playerBody.velocity.y,0f);
	}

	void Jump(){
		playerBody.velocity = new Vector3(playerBody.velocity.x,0f,0f);
		playerBody.AddForce (Vector3.up * jumpForce);
	}

	void Pause(){
		Time.timeScale = isPaused ? 1f : 0f;
		isPaused = !isPaused;
	}

	void MoveSideways(float xAxisInput){
		playerBody.AddForce(Vector3.right * xAxisInput * moveForce, ForceMode.VelocityChange);
	}

	void CheckForGround(){
		bool air = true;
		foreach (Collider col in Physics.OverlapSphere(feet.position,0.25f,-1,QueryTriggerInteraction.Ignore)){
			if (col.gameObject.layer == Layers.ground){
				grounded = true;
				air = false;
				break;
			}
		}
		if (air){
			grounded = false;
		}
	}
}
