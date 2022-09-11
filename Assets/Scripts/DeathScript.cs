using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            restartPosition();
            resetGame();
        }
    }
    public void restartPosition()
    {
        player.transform.position = startPoint.transform.position;
    }

    public void resetGame()
    {
        SceneManager.LoadScene("Flappy Bird");
    }
}
