using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Ground Movement")]
    public float speed = 5f;
    public float jumpForce = 3f;
    public LayerMask groudLayer;

    [Header("Water Movement")]
    public float waterMoveSpeed = 1f;
    public float waterVerticalSpeed = 1f;
    public float normalGravity = 1f;
    public float waterGravity = 0.5f;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
    private bool isInWater;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        rb.gravityScale = normalGravity;
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");

        if (isInWater)
        {
            float verticalMove = 0f;

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
                verticalMove = 1f;
            else if (Input.GetKey(KeyCode.S))
                verticalMove = -1f;

            rb.linearVelocity = new Vector2(move * waterMoveSpeed, verticalMove * waterVerticalSpeed);
        }
        else
        {
            rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

            isGrounded = Physics2D.OverlapCircle(transform.position, 0.7f, groudLayer);

            if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

                if (AudioManager.instance != null)
                    AudioManager.instance.PlayJump();
            }

        }

        if (move > 0)
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

        if (move < 0)
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

        animator.SetBool("isRunning", move != 0);
        animator.SetBool("isGrounded", isGrounded || isInWater);
        animator.SetBool("isInWater", isInWater);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            Debug.Log("ENTER WATER");
            isInWater = true;
            rb.gravityScale = waterGravity;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            Debug.Log("EXIT WATER");
            isInWater = false;
            rb.gravityScale = normalGravity;
        }
    }

    public void Bounce(float force)
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, force);
    }
}