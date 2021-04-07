using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private const string animatorIsRunning = "isRunning";
    private const string animatorIsJumping = "isJumping";
    private const string animatorTakeOff = "take-off";
    
    [SerializeField]
    private Rigidbody2D characterRigidbody;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float groundCheckRadius;
    [SerializeField]
    private LayerMask groundLayerMask;
    [SerializeField]
    private float jumpTime;
    [SerializeField]
    private float fallMultiplier = 2.5f;
    [SerializeField]
    private float lowJumpMultiplier = 2f;

    private float moveInput;
    private bool isGrounded;
    private bool isJumping;
    private float jumpTimeCounter;

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayerMask);
        moveInput = Input.GetAxisRaw("Horizontal");
        characterRigidbody.velocity = new Vector2(moveInput * speed, characterRigidbody.velocity.y);
    }

    void Update()
    {
        if (moveInput == 0)
        {
            animator.SetBool(animatorIsRunning, false);
        }
        else 
        {
            animator.SetBool(animatorIsRunning, true);
        }

        if(moveInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if(moveInput < 0)
        {
            spriteRenderer.flipX = true;
        }

        if(isGrounded && ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))))
        {
            animator.SetTrigger(animatorTakeOff);
            animator.SetBool(animatorIsJumping, true);
            isJumping = true;
            jumpTimeCounter = jumpTime;
            characterRigidbody.velocity = Vector2.up * jumpForce;
        }
        
        if (isGrounded)
        {
            animator.SetBool(animatorIsJumping, false);
        }
        else
        {
            animator.SetBool(animatorIsJumping, true);
        }

        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && isJumping)
        {
            if(jumpTimeCounter > 0)
            {
                characterRigidbody.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if((Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W)))
        {
            isJumping = false;
        }
    }
}
