using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    private Animator enemyAnimator;

    float horizontalMove = 0f;
    public float runSpeed = 0f;
    public float bounceForce = 400f;
    bool isJumping = false;
    bool isCrouching = false;
    bool isFalling;
    public static int currHealth;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            isCrouching = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            isCrouching = false;
        }

        if (controller.checkFalling())
        {
            animator.SetBool("isFalling", true);
            isFalling = true;
        }
        else
        {
            animator.SetBool("isFalling", false);
            isFalling = false;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        animator.SetBool("isFalling", false);
    }

    public void OnCrouch(bool crouching)
    {
        animator.SetBool("IsCrouching", crouching);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy" && !isFalling)
        {
            if (currHealth > 20)
            {
                currHealth -= 20;
                animator.SetBool("Hurt", true);
                rb.AddForce(other.contacts[0].normal * bounceForce);
                Debug.Log("Ouch! Health = " + currHealth);
                Invoke("StopHurt", 0.25f); //2 frames, 8 samples/second
            }
            else
                Debug.Log("GameOver");
        }
        else if (other.gameObject.tag == "Enemy" && isFalling)
        {
            other.gameObject.GetComponentInChildren<EnemyGFX>().DeathAnimationandDestroy();
            rb.AddForce(other.contacts[0].normal * bounceForce);            //add a bounce when the player jumps on the enemy
        }

    }
    
    void StopHurt()
    {
        animator.SetBool("Hurt", false);
    }

    private void FixedUpdate()
    {
        //Move Character
        controller.Move(horizontalMove * Time.fixedDeltaTime, isCrouching, isJumping); //time.FixedDeltaTime is time elapsed since the previous time this function called
        isJumping = false;
    }
}
