using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    public void DeathAnimationandDestroy()
    {
        this.transform.parent.GetComponent<Enemy>().freezePosition(); //we want the enemy to stop moving as soon as you kill it
        Destroy(this.transform.parent.gameObject, 0.375f); // 6 frames / 16 samples per second
        animator.SetTrigger("Killed");
    }
}
