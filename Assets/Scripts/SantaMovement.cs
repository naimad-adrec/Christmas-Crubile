using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sp;
    private Animator anim;
    [SerializeField] private int jumpSpeed = 5;
    [SerializeField] private int moveSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");

        UpdateSantaAnimationState(dirX);

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }

    private void UpdateSantaAnimationState(float direction)
    {
        if (direction > 0)
        {
            sp.flipX = true;
        }
        else if (direction < 0)
        {
            sp.flipX = false;
        }

        if (Input.GetKeyDown("e"))
        {
            anim.SetTrigger("isAttacking");
        }
    }
}
