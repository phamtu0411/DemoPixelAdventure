using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpbleGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 8f;

    private enum MovementState { idle, run, jump, fall }

    [SerializeField] private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (Input.GetKeyDown("space") && IsGrounded())
        {
            audio.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.run;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.run;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jump;
        }
        if (rb.velocity.y < -.1f)
        {
            state = MovementState.fall;
        }
        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(bc.bounds.center,bc.bounds.size,0f,Vector2.down,.1f,jumpbleGround);
    }
}
