#region Declaration
using UnityEngine;
using System.Collections;
using GenericFunctions;

public class PlayerMovement : MonoBehaviour {
#endregion

	#region Initialize Variables

		#region declar vars
	public PlayerType playerType;
	public Transform feet;
	public Ploder ploderScript;
	public Rigidbody playerBody;

	private bool grounded;
	private bool willJump;
	private int groundCheckMask;
	private float groundCheckHeight;
	private float lastXAxisInput;
	private float deadSize;
	private Controls controls;
	private float maxSpeed;
	private float moveForce;
	private float jumpForce;
		#endregion

		#region Awake
	void Awake(){
		moveForce = .3f;
		deadSize = 0.5f;

		groundCheckHeight = 0.2f;
		groundCheckMask = LayerMask.GetMask("Player","Ground","Blocks");
		SetSpeed();

		if (playerType == PlayerType.Explo){
			Players.explo = gameObject;
		}
		else{
			Players.implo = gameObject;
		}
		GetCurrentControls();
	}
		#endregion

			#region Get Current Controls
	public void GetCurrentControls(){
		if (playerType == PlayerType.Explo){
			controls = GameManager.StaticControls.Explo_Controls;
		}
		else{
			controls = GameManager.StaticControls.Implo_Controls;
		} 
	}
			#endregion

			#region SetSpeed
	void SetSpeed(){
		if (playerType == PlayerType.Explo){
			//explosive jump, moderate running
			maxSpeed = 6f;
			jumpForce = 700f;
		}
		else if (playerType == PlayerType.Implo){
			//quick running, mild jump
			maxSpeed = 7f;
			jumpForce = 600f;
		}
	}
			#endregion

	#endregion

	#region Trigger Movement
	void Update(){
		grounded = CheckForGround();
		willJump = Input.GetButtonDown(controls.Jump) && grounded;
	}

	void FixedUpdate(){
		float xAxisInput = Input.GetAxisRaw(controls.Horizontal);
		bool willMoveSideways = Mathf.Abs (xAxisInput)>0 &&
			(Mathf.Abs (playerBody.velocity.x)<(maxSpeed *Mathf.Abs (xAxisInput)) ||
			 Mathf.Sign (playerBody.velocity.x)!= Mathf.Sign(xAxisInput));
		bool willBrake = Mathf.Abs (lastXAxisInput)>deadSize && Mathf.Abs (xAxisInput) <deadSize;

		if (willJump){
			Jump();
		}

		if (willMoveSideways){
			MoveSideways(xAxisInput);
		}
		if (willBrake){
			//Brake();
		}
		lastXAxisInput = xAxisInput;
	}
	#endregion

	#region Apply Movement
	void Jump(){
		playerBody.velocity = new Vector3(playerBody.velocity.x,0f,0f);
		playerBody.AddForce (Vector3.up * jumpForce);
	}

	void MoveSideways(float xAxisInput){
		playerBody.AddForce(Vector3.right * xAxisInput * moveForce, ForceMode.VelocityChange);
		//transform.localScale = new Vector3(Mathf.Sign(xAxisInput),1f,1f);
	}

	void Brake(){
		playerBody.velocity = new Vector3(0f,playerBody.velocity.y,0f);
	}
	#endregion

	#region Check For Ground
	bool CheckForGround(){
		return Physics.Raycast(feet.position + Vector3.up*0.5f,Vector3.down,(0.5f+groundCheckHeight),groundCheckMask)||
			Physics.Raycast(feet.position + transform.right*0.3f + Vector3.up*0.5f,Vector3.down,(0.5f+groundCheckHeight),groundCheckMask)||
			Physics.Raycast(feet.position - transform.right*0.3f + Vector3.up*0.5f,Vector3.down,(0.5f+groundCheckHeight),groundCheckMask);
	}
	#endregion


	#region Graveyard
//
//	void OnDrawGizmos(){
//		Debug.DrawRay(feet.position + Vector3.up*0.5f,Vector3.down*(0.5f+groundCheckHeight));
//		Debug.DrawRay(feet.position + transform.right*0.3f + Vector3.up*0.5f,Vector3.down*(0.5f+groundCheckHeight));
//		Debug.DrawRay(feet.position - transform.right*0.3f + Vector3.up*0.5f,Vector3.down*(0.5f+groundCheckHeight));
//	}
	#endregion

}
