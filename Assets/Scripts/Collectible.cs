using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public Animator animator;
    public PolygonCollider2D pcollider;

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            CollectAnimationandDestroy();
        }
    }
    public void CollectAnimationandDestroy()
    {
        pcollider.enabled = !pcollider.enabled;
        Destroy(this.gameObject, 0.375f); // 6 frames / 16 samples per second
        animator.SetTrigger("Collected");
    }
}
