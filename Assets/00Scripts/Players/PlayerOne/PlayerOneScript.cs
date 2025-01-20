using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField] PlayerOneMovement playerMovement;
	// [SerializeField] Animator animator;
	float horizontalMove = 0f;
	float runSpeed = 40f;
	bool isJump = false;

	void Start () {

	}
	
	void Update () {
		// horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		// animator.SetFloat("speed", Mathf.Abs(horizontalMove));
		// if(Input.GetButtonDown("Jump")){
		// 	isJump = true;
		// 	// animator.SetBool("isJump", true);
		// }
	}

	// private void FixedUpdate() {
	// 	playerMovement.Move(horizontalMove * Time.fixedDeltaTime, false, isJump);
	// 	isJump = false;
	// }

	// public void onLanding() {
	// 	animator.SetBool("isJump", false);
	// }
}
