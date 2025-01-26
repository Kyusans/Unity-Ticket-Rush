﻿using UnityEngine;
using UnityEngine.Events;

public class PlayerTwoMovement : MonoBehaviour
{
    PlayerTwoControls controls;
    [SerializeField] private float m_JumpForce = 400f;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    [SerializeField] private bool m_AirControl = false;
    [SerializeField] private LayerMask m_WhatIsGround;
    [SerializeField] private Transform m_GroundCheck;
    [SerializeField] private GameObject punchGameObject;
    Animator animator;
    const float k_GroundedRadius = .2f;
    private bool m_Grounded;
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;
    private Vector3 m_Velocity = Vector3.zero;

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

        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
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

    void Jump()
    {
        if (m_Grounded)
        {
            m_Grounded = false;
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

    private void Update()
    {
        animator.SetBool("isGrounded", m_Grounded);
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    void Punch()
    {
        punchGameObject.SetActive(true);
    }
}
