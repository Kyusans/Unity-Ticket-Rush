﻿﻿using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerOneMovement : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;                          // Amount of force added when the player jumps.
	[Range(0, .3f)][SerializeField] private float m_MovementSmoothing = .05f; // How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
	[SerializeField] private GameObject punchGameObject;
	[SerializeField] private float punchCooldown = 0f;                          // Cooldown duration for punching
	private float punchCooldownTimer;
	private bool canPunch = true;
	private float playerX, playerY;
	Animator animator;
	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;

	AudioSource audioSource;

	[Header("Events")]
	[Space]
	public UnityEvent OnLandEvent;

	private void Awake()
	{
		playerX = transform.position.x;
		playerY = transform.position.y;
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
	}

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}

	public void Move(float move, bool jump)
	{
		if (m_Grounded || m_AirControl)
		{
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			if (move > 0 && !m_FacingRight)
				Flip();
			else if (move < 0 && m_FacingRight)
				Flip();
		}

		if (m_Grounded && jump)
		{
			m_Grounded = true;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
		}
	}

	private void Flip()
	{
		m_FacingRight = !m_FacingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void goBackToStart()
	{
		audioSource.Play();
		transform.position = new Vector2(playerX, playerY);
	}

	private void Update()
	{
		float move = Input.GetAxisRaw("Horizontal_P1");
		bool jump = Input.GetButtonDown("Jump_P1");
		animator.SetBool("isGrounded", m_Grounded);
		animator.SetFloat("speed", Mathf.Abs(move));
		Move(move, jump);
		if (transform.position.y < -20)
		{
			if (m_Rigidbody2D.gravityScale >= 100)
			{
				m_Rigidbody2D.gravityScale = 1.5f;
			}
			audioSource.Play();
			goBackToStart();
		}

		// Handle punch cooldown
		if (!canPunch)
		{
			punchCooldownTimer -= Time.deltaTime;
			if (punchCooldownTimer <= 0)
			{
				canPunch = true;
			}
		}

		if (Input.GetButtonDown("Punch_P1") && canPunch)
		{
			punchGameObject.SetActive(true);
			canPunch = false;
			punchCooldownTimer = punchCooldown;
			animator.Play("Player1_Punch");
			StartCoroutine(ResetPunch());
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			goBackToStart();
		}
	}

	private IEnumerator ResetPunch()
	{
		yield return new WaitForSeconds(0.1f);
		animator.Play("Player1_Idle");
		punchGameObject.SetActive(false);
	}
}