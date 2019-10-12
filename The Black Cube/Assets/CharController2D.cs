using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CharController2D : MonoBehaviour {

	public float speed;
	public float jumpForce;
	private float moveInput;
	public float dSpeed;
	public GameObject AudioPrefab;
	public GameObject DestroyThis;
	private LevelChanger lvl;
	public int levelToLoad;

	public Animator anim;
	public Rigidbody2D rb;

	public BoxCollider2D stand;
	public BoxCollider2D crouchCol;

	private bool facingRight = true;
	private bool isPressedW = false;
	private bool isPressedUp = false;
	private bool crouch = false;
	private float jumpsMade = 0;
	private float jumpAnimController;

	private bool isGrounded;
	public Transform groundCheck;
	public float checkRadius;
	public LayerMask whatIsGround;

	private int extraJumps;
	public int extraJumpsValue;

	void Update ()
	{


		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");
		Vector2 dir = new Vector2 (x, y);

		Walk (dir);

		Debug.Log (jumpsMade);

		if (isGrounded == true) {
			extraJumps = extraJumpsValue;
			jumpsMade = 0;
		}
		if (Input.GetKeyDown (KeyCode.W) && extraJumps > 0 && isPressedUp == false) {
			rb.velocity = Vector2.up * jumpForce;
			extraJumps--;
			isPressedW = true;
			jumpsMade++;
			jumpAnimController++;
			Instantiate (AudioPrefab, new Vector2 (0, 0), Quaternion.identity);
		} else if (Input.GetKeyDown (KeyCode.W) && extraJumps == 0 && isGrounded == true) {
			rb.velocity = Vector2.up * jumpForce;
		}
		if (Input.GetKeyDown (KeyCode.UpArrow) && extraJumps > 0 && isPressedW == false) {
			rb.velocity = Vector2.up * jumpForce;
			extraJumps--;
			isPressedUp = true;
			jumpsMade++;
			jumpAnimController++;
		} else if (Input.GetKeyDown (KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true) {
			rb.velocity = Vector2.up * jumpForce;
		}
		if (Input.GetKeyDown (KeyCode.W)) {
			anim.Play ("Double_Jump");
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			anim.Play ("Double_Jump");
		}
/*		if (Input.GetKeyDown (KeyCode.S)) {
			crouch = true;
			anim.Play ("Crouch");
			stand.enabled = false;
			crouchCol.enabled = true;
		} else if (Input.GetKeyUp (KeyCode.S)) {
			OnCollisionEnter2D ();
			stand.enabled = true;
			crouchCol.enabled = false;
		}
*/	}

	private void OnCollisionEnter2D ()
	{
		anim.Play ("Jump_Land");
		anim.Play ("Idle");
		isPressedW = false;
		isPressedUp = false;
		Destroy (DestroyThis, 1f);
		crouch = false;
	}

	void Start ()
	{
		anim = GetComponent<Animator> ();
		extraJumps = extraJumpsValue;
		rb = GetComponent<Rigidbody2D> ();
		crouch = GetComponent<BoxCollider2D> ();
		stand = GetComponent<BoxCollider2D> ();
		crouchCol.enabled = false;
	}

	void FixedUpdate ()
	{
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, checkRadius, whatIsGround);
		moveInput = Input.GetAxis ("Horizontal");
		//Debug.Log (extraJumps);
		rb.velocity = new Vector2 (moveInput * speed, rb.velocity.y);
		if (facingRight == false && moveInput > 0) {
			Flip ();
		} else if (facingRight == true && moveInput < 0) {
			Flip ();
		}
	}

	void Flip ()
	{
		facingRight = !facingRight;
		Vector3 Scaler = transform.localScale;
		Scaler.x *= -1;
		transform.localScale = Scaler;
	}

	private void OnCollisionEnter2D (Collision2D col)
	{
		if (col.collider.tag == "GameOver" && crouch == false) {
			
		}

	}

	private void Walk (Vector2 dir)
	{
		rb.velocity = (new Vector2 (dir.x * dSpeed, rb.velocity.y));
	}

}
