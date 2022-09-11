using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    //public float speed;
    //private float Move;

    public float jump;
    private float angle;
    private float rotAngle;
    private float maxPosVel;
    private float maxNegVel;
    //public bool isJumping;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        angle = 45f;
        maxPosVel = 13.6f; //middle = 0.89, 14.49 distance
        maxNegVel = -15.38f;
    }

    // Update is called once per frame
    void Update()
    {
        //Move = Input.GetAxis("Horizontal");

        //rb.velocity = new Vector2(speed * Move, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0f, jump));
        }
        getAngle();
    }

    private void getAngle()
    {
        if (rb.velocity.y < 0)
        {
            rotAngle = -angle * (rb.velocity.y / maxNegVel);
        }
        else
        {
            rotAngle = angle * (rb.velocity.y / maxPosVel);
        }
        transform.eulerAngles = new Vector3(0, 0, rotAngle);
    }
    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Pipe"))
    //    {
    //        isJumping = false;
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("PIp"))
    //    {
    //        isJumping = true;
    //    }
    //}

    //private void fallCheck()
    //{
    //    if (transform.position.y < -7)
    //    {
    //        DeathScript.restartPosition(this.gameObject);
    //    }
    //}
}
