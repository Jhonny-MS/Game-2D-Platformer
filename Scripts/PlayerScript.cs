using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {



	private Animator anim_C;
	private Rigidbody2D Rb2D;
	public float speed = 2f;
	private float h;
	public bool isJumping, aux, onTheFloor;
	public Vector2 jumpHeight;


	void GetAxis (){

		h = Input.GetAxisRaw ("Horizontal") * speed;
	}

	void ApplyingPhysics(){
		
		Rb2D.MovePosition (Rb2D.position + new Vector2 (h * Time.fixedDeltaTime, 0.0f));
	}

	void MovimentAnimationManager (){

		if (h > 0 && isJumping == false) {
			anim_C.SetInteger ("state", 3);
		}
		else if (h < 0 && isJumping == false) {
			anim_C.SetInteger ("state", 2);
		}
		else if (h == 0 && isJumping == false) {
			anim_C.SetInteger ("state", 0);
		}
	}

	void onColisionStay2D(Collision2D coll){

		if (coll.gameObject.tag == "floor") {
			onTheFloor = true;
			Rb2D.gravityScale = 1;
		}			
	}

	void onColisionExit2D(Collision2D coll){
		if (coll.gameObject.tag == "floor") {
			Rb2D.gravityScale = 15;
			onTheFloor = false;
		}
	}

	IEnumerator JumpSystem(){
		if (Input.GetKeyDown (KeyCode.Space) && isJumping == false && aux == false) {
			isJumping = true;
			anim_C.SetInteger ("state", 1);
			Rb2D.AddForce (jumpHeight, ForceMode2D.Impulse);
			aux = true;
		} else if (isJumping == true && aux == true) {
			isJumping = false;
			yield return new WaitForSeconds (0.8f);
			aux = false;
		}
	}

	void JumpAct(){
		
		StartCoroutine (JumpSystem ());
	}

	public void DisableJump(){
		
		isJumping = false;
	}

	void Start () {

		Rb2D = this.gameObject.GetComponent<Rigidbody2D>();
		anim_C = GetComponent<Animator> ();
		isJumping = false;
		aux = false;
	}
	

	void Update () {
		
		GetAxis ();
		MovimentAnimationManager ();
	}

	void FixedUpdate(){
		
		ApplyingPhysics ();
		JumpAct ();
	}
	}

