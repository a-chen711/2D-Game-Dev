using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pipe : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private bool first;
    private float playerX;
    public static int score;
    public bool scored;
    public GameObject scoreText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        first = true;
        score = 0;
        playerX = -6.45f;
        pipeRandomizer();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, 0);
        if (transform.position.x < playerX && !scored)
        {
            score++;
            scored = true;
            displayScore();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PipeCollider"))
        {
            pipeRandomizer();
        }
    }

    private void pipeRandomizer()
    {
        scored = false;
        float respawn_x = 15.4f;
        float respawn_y = Random.Range(-3.58f, 4.66f);
        if (first)
        {
            transform.position = new Vector2(transform.position.x, respawn_y);
            first = false;
        }
        else
            transform.position = new Vector2(respawn_x, respawn_y);
    }

    public void displayScore()
    {
        scoreText.GetComponent<TMP_Text>().text = "Score: " + score.ToString();
    }
}
