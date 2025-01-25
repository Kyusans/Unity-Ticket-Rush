using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
	PlayerOneControls controls;
	[SerializeField] private float moveSpeed = 5f;
	[SerializeField] private float jumpForce = 10f;
	[SerializeField] private LayerMask groundLayer;
	[SerializeField] private Transform m_GroundCheck;

	Animator animator;

	private Rigidbody2D rb;
	private bool isGrounded = true;

	private void Awake()
	{
		controls = new PlayerOneControls();
		controls.Gameplay.Jump.performed += ctx => Jump();
	}

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	private void Jump()
	{
		if (isGrounded)
		{
			rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
			isGrounded = false;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.GetComponent<CompositeCollider2D>() != null)
		{
			isGrounded = true;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.collider.GetComponent<CompositeCollider2D>() != null)
		{
			isGrounded = false;
		}
	}

	private void Update()
	{
		CheckGrounded();
	}

	private void CheckGrounded()
	{
		isGrounded = Physics2D.OverlapCircle(m_GroundCheck.position, 0.1f, groundLayer);
	}

	void OnEnable()
	{
		controls.Gameplay.Enable();
	}

	void OnDisable()
	{
		controls.Gameplay.Disable();
	}
}
