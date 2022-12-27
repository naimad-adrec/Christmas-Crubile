using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sp;
    private Animator anim;
    private BoxCollider2D colls;

    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private float jumpSpeed = 5f;
    [SerializeField] private float moveSpeed = 5f;
    private int jumpCount = 0;

    private enum MovementState {idle, running, jumping, falling};
    private MovementState state = MovementState.idle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        colls = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");

        UpdateSantaAnimationState(dirX);

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            jumpCount++;
        }
    }

    private void UpdateSantaAnimationState(float direction)
    {
        MovementState state;

        if (direction > 0f)
        {
            sp.flipX = true;
            state = MovementState.running;
        }
        else if (direction < 0f)
        {
            sp.flipX = false;
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }

        if(rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        if (Input.GetKeyDown("e"))
        {
            anim.SetTrigger("isAttacking");
        }

        anim.SetInteger("animState", (int) state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(colls.bounds.center, colls.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}
