#region Declaration
using UnityEngine;
using System.Collections;
using GenericFunctions;

public class PlayerMovement : MonoBehaviour {
#endregion

	#region Initialize Variables
	public TypeOfPlayer typeOfPlayer;
	public Transform feet;
	public Ploder ploderScript;

	private bool grounded;
	private bool willJump;
	private int groundCheckMask;
	private float groundCheckHeight;
	private float lastXAxisInput;
	private float deadSize;
	public Rigidbody playerBody;
	private Controls controls;

	[Range(2,5)]
	public float maxSpeed;

	[Range(0,6)]
	public float moveForce;

	[Range(500f,1000f)]
	public float jumpForce;

	void Awake(){
		moveForce = .3f;
		deadSize = 0.5f;

		groundCheckHeight = 0.2f;
		groundCheckMask = LayerMask.GetMask("Player","Ground","Blocks");
		SetSpeed(typeOfPlayer.PlayerType);

		if (typeOfPlayer.PlayerType == PlayerType.Explo){
			Players.explo = gameObject;
			controls = GameManager.StaticControls.Explo_Controls;
		}
		else{
			Players.implo = gameObject;
			controls = GameManager.StaticControls.Implo_Controls;
		}

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

	void Update(){
		grounded = CheckForGround();
		willJump = Input.GetButtonDown(controls.Jump) && grounded;
	}

	void FixedUpdate(){
		float xAxisInput = Input.GetAxisRaw(controls.Horizontal);
		bool willMoveSideways = Mathf.Abs (xAxisInput)>0 &&
			(Mathf.Abs (playerBody.velocity.x)<(maxSpeed *Mathf.Abs (xAxisInput)) ||
			 Mathf.Sign (playerBody.velocity.x)!= Mathf.Sign(xAxisInput));
		bool willBrake = grounded && Mathf.Abs (lastXAxisInput)>deadSize && Mathf.Abs (xAxisInput) <deadSize;

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

	void MoveSideways(float xAxisInput){
		playerBody.AddForce(Vector3.right * xAxisInput * moveForce, ForceMode.VelocityChange);
		//transform.localScale = new Vector3(Mathf.Sign(xAxisInput),1f,1f);
	}

	bool CheckForGround(){

		return Physics.Raycast(feet.position + Vector3.up*0.5f,Vector3.down,(0.5f+groundCheckHeight),groundCheckMask)||
			Physics.Raycast(feet.position + transform.right*0.3f + Vector3.up*0.5f,Vector3.down,(0.5f+groundCheckHeight),groundCheckMask)||
			Physics.Raycast(feet.position - transform.right*0.3f + Vector3.up*0.5f,Vector3.down,(0.5f+groundCheckHeight),groundCheckMask);
	}
//
//	void OnDrawGizmos(){
//		Debug.DrawRay(feet.position + Vector3.up*0.5f,Vector3.down*(0.5f+groundCheckHeight));
//		Debug.DrawRay(feet.position + transform.right*0.3f + Vector3.up*0.5f,Vector3.down*(0.5f+groundCheckHeight));
//		Debug.DrawRay(feet.position - transform.right*0.3f + Vector3.up*0.5f,Vector3.down*(0.5f+groundCheckHeight));
//	}

	public void GetCurrentControls(){
		if (typeOfPlayer.PlayerType == PlayerType.Explo){
			controls = GameManager.StaticControls.Explo_Controls;
		}
		else{
			controls = GameManager.StaticControls.Implo_Controls;
		} 
	}
}
