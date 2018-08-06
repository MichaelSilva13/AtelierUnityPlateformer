using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;

	private float x, z;

	public float OGjumpForce = 25f;
	public float variation;
	public float jumpForce;
	public float gravity;
	public float cancelJumpMaxVelocity;

	public Animator anim;

	public bool isGrounded = true;

	private Rigidbody rb;

    private Vector3 facingVect = new Vector3(1,1,1);


	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody>();
		anim = this.GetComponent<Animator>();
	}

	private void OnCollisionEnter(Collision collision)
	{
		GameObject other = collision.gameObject;
		//Resets the ability to jump
		if (other.CompareTag("Ground"))
		{
			isGrounded = true;
		}
		
	}

	private void OnCollisionExit(Collision collision)
	{
		
		
	}

	private void Update()
	{
		
	}

	// Update is called once per frame
	//We use fix update for the movement as it is better to use this instead of update for the physics
	void FixedUpdate () {

		//sets the gravity to give the world a less floaty feel
		Physics.gravity = new Vector3(0, -gravity, 0);

		//Start of the jump, when the player presses the jump btn
		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			// Instantly push the avatar upward.
			rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
			isGrounded = false;
		}
		//if the player is still in the air
		else if (!isGrounded)
		{
			//if the player releases the jump btn
			if (!Input.GetButton("Jump"))
			{
				// Cancel the jump early.
				var v = rb.velocity;
				v.y = Mathf.Min(v.y, cancelJumpMaxVelocity);
				rb.velocity = v;
			}
			else if (rb.velocity.y <= cancelJumpMaxVelocity)
			{
				// The jump has now progressed beyond the point where it can be canceled early.
				isGrounded = false;
			}
		}
		//facing will be used to make the character move relative to the camera
		float facing = Camera.main.transform.eulerAngles.y;

		//Set the variables according to the imput. They will be used for the movement of the player
		x = Input.GetAxis("Horizontal");
		z = Input.GetAxis("Vertical");  //We use z cause unity doesn't understand standard axis
		
		//Set the animation variables
		anim.SetFloat("Speed", Mathf.Sqrt((x*x)+(z*z)));
		anim.SetBool("Jump", !isGrounded); //grounded is opposite of jump. Should have put jump but too lazy to change
		
		
		//We set the new velocity without the camera facing. We keep the normal y speed of the rigidbody because at 0 the character will float in the air instead of falling
		Vector3 inputs = new Vector3(x * speed, this.GetComponent<Rigidbody>().velocity.y, z * speed);

		//We change our inputs vector so it rotates so the player can move relative to how the camera is positionned
		Vector3 myTurnedInputs = Quaternion.Euler(0, facing, 0) * inputs;

		//We set the velocity of the player with our new inputs
		this.GetComponent<Rigidbody>().velocity = myTurnedInputs;

        //We rotate our character so turns to the direction he is moving towards
        facingVect = new Vector3(myTurnedInputs.x + transform.position.x, transform.position.y , myTurnedInputs.z + transform.position.z);
        

        transform.LookAt( facingVect);

	}
}
