using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpVelocity;
    [SerializeField] private float runVelocity;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private AudioSource jumpSoundEffect;

    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;
    private Animator animator;
    private SpriteRenderer sprite;
    private enum AnimationState { idle, running, jumping, falling };


    // Start is called before the first frame update (when the game starts)
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        float dirX = Input.GetAxis("Horizontal");
        rigidBody.velocity = new Vector2(dirX * runVelocity, rigidBody.velocity.y);


        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rigidBody.velocity = new Vector2(0, jumpVelocity);
        }

        UpdateAnimation(dirX);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(
            boxCollider.bounds.center, 
            boxCollider.bounds.size, 
            0f, 
            Vector2.down, 
            .1f, 
            jumpableGround
        );
    }

    private void UpdateAnimation(float dirX)
    {
        if (dirX != 0) sprite.flipX = dirX < 0f;

        AnimationState animationState =
            (.1f < rigidBody.velocity.y)  ? AnimationState.jumping :
            (rigidBody.velocity.y < -0.1) ? AnimationState.falling :
            (dirX != 0f)                  ? AnimationState.running :
            (dirX == 0f)                  ? AnimationState.idle :
                                            AnimationState.idle;

        animator.SetInteger("animationState", (int)animationState);
    }
}
