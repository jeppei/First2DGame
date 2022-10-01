using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpVelocity;
    [SerializeField] private float runVelocity;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private AudioSource jumpSoundEffect;

    [SerializeField] private Text cherriesText;
    [SerializeField] private AudioSource collectSoundEffect;

    private int collectedCherries = 0;
    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;
    private Animator animator;
    private SpriteRenderer sprite;
    private int nrAirJumps;

    private bool doubleJumpEnabled;

    private enum AnimationState { idle, running, jumping, falling };


    // Start is called before the first frame update (when the game starts)
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        nrAirJumps = 0;
        doubleJumpEnabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        float dirX = Input.GetAxis("Horizontal");
        
        if (rigidBody.bodyType != RigidbodyType2D.Static)
        {
            rigidBody.velocity = new Vector2(dirX * runVelocity, rigidBody.velocity.y);
        }


        if (IsGrounded())
        {
            this.nrAirJumps = 0;
        }

        if (Input.GetButtonDown("Jump") && CanJump())
        {
            jumpSoundEffect.Play();
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpVelocity);
            if (InAir())
            {
                this.nrAirJumps++;
            }
        
        }

        

        UpdateAnimation(dirX);
    }

    private bool InAir()
    {
        return !IsGrounded();
    }

    private bool CanJump()
    {
        return IsGrounded() || (this.nrAirJumps == 0 && doubleJumpEnabled); 
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(
            boxCollider.bounds.center, 
            boxCollider.bounds.size - new Vector3(0, boxCollider.bounds.size.y / 2, 0), 
            0f, 
            Vector2.down, 
            .1f + boxCollider.bounds.size.y / 4, 
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Kiwi"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            doubleJumpEnabled = true;
        }
        else if (collision.gameObject.CompareTag("Cherry"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            collectedCherries++;
            cherriesText.text = $"Cherries: {collectedCherries}";
        }
    }
}
