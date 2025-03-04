﻿﻿using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerTwoMovement : MonoBehaviour
{
    PlayerTwoControls controls;
    [SerializeField] private float m_JumpForce = 400f;
    [Range(0, .3f)][SerializeField] private float m_MovementSmoothing = .05f;
    [SerializeField] private bool m_AirControl = false;
    [SerializeField] private LayerMask m_WhatIsGround;
    [SerializeField] private Transform m_GroundCheck;
    [SerializeField] private GameObject punchGameObject;
    private float playerX, playerY;
    Animator animator;
    const float k_GroundedRadius = .2f;
    private bool m_Grounded;
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;
    private Vector3 m_Velocity = Vector3.zero;

    private bool isPunchOnCooldown = false;
    private float punchCooldownTimer = 0f;
    [SerializeField] private float punchCooldown = 0f;

    AudioSource audioSource;
    Vector2 moveInput;

    [Header("Events")]
    [Space]
    public UnityEvent OnLandEvent;

    private void Awake()
    {
        controls = new PlayerTwoControls();
        controls.Gameplay.Jump.performed += ctx => Jump();
        controls.Gameplay.Punch.performed += ctx => Punch();
        controls.Gameplay.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => moveInput = Vector2.zero;
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
        Move(moveInput.x);
    }

    public void Move(float move)
    {
        animator.SetFloat("speed", Mathf.Abs(move));
        if (m_Grounded || m_AirControl)
        {
            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            if (move > 0 && !m_FacingRight)
                Flip();
            else if (move < 0 && m_FacingRight)
                Flip();
        }

    }

    public void Jump()
    {
        Debug.Log("Jumping");
        if (m_Grounded)
        {
            m_Grounded = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }
    }

    public void Punch()
    {
        Debug.Log("Punching");
        if (!isPunchOnCooldown)
        {
            punchGameObject.SetActive(true);
            isPunchOnCooldown = true;
            punchCooldownTimer = punchCooldown;
            animator.Play("Player2_Punch");
            StartCoroutine(ResetPunch());
        }
    }

    private void Flip()
    {
        Debug.Log("Flipping direction");
        m_FacingRight = !m_FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void goBackToStart()
    {
        transform.position = new Vector2(playerX, playerY);
        audioSource.Play();
    }

    private void Update()
    {
        // float move = Input.GetAxis("Horizontal_P2");
        // bool jump = Input.GetKeyDown(KeyCode.Joystick2Button0);

        if (isPunchOnCooldown)
        {
            punchCooldownTimer -= Time.deltaTime;
            if (punchCooldownTimer <= 0f)
            {
                isPunchOnCooldown = false;
            }
        }

        if (transform.position.y < -20)
        {
            if (m_Rigidbody2D.gravityScale >= 100)
            {
                m_Rigidbody2D.gravityScale = 1.5f;
            }
            goBackToStart();
        }

        // animator.SetFloat("speed", Mathf.Abs(move));
        animator.SetBool("isGrounded", m_Grounded);

        // Move(move);
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
        animator.Play("Player2_Idle");
        punchGameObject.SetActive(false);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

}
