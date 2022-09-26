using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isBouncing = false;
    public float bounceForce = 400f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            rb.AddForce(other.contacts[0].normal * bounceForce);
            isBouncing = true;
            Invoke("StopBounce", 0.3f);
        }
    }
    void StopBounce()
    {
        isBouncing = false;
    }

    public void freezePosition()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
    }
}
