using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoScript : MonoBehaviour
{

  [SerializeField] PlayerTwoMovement playerMovement;
  // [SerializeField] Animator animator;
  float horizontalMove = 0f;
  float runSpeed = 40f;
  bool isJump = false;

  void Start()
  {

  }

  void Update()
  {
    // horizontalMove = Input.GetAxisRaw("Horizontal_P2") * runSpeed;
    // animator.SetFloat("speed", Mathf.Abs(horizontalMove));
    // if (Input.GetButtonDown("Jump_P2"))
    // {
    //   isJump = true;
    //   // animator.SetBool("isJump", true);
    // }
  }

  // private void FixedUpdate()
  // {
  //   playerMovement.Move(horizontalMove * Time.fixedDeltaTime, isJump);
  //   isJump = false;
  // }

  // public void onLanding() {
  // 	animator.SetBool("isJump", false);
  // }
}
