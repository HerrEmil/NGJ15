using UnityEngine;
using System.Collections;

public class BossBehaviour : MonoBehaviour
{
    public int breakingHits = 0;
    public int pointsForDestroying = 5;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.tag.Equals("Ball"))
        {
            bool hit = animator.GetBool("OnHit");
            if (hit != true)
            {
                animator.SetBool("OnHit", true);
            }

            if (breakingHits != 0)
            {
                breakingHits--;
            }
            
            if (breakingHits == 0)
            {
                var ballScript = coll.transform.GetComponent<BallScript>();
                var ballID = ballScript.PlayerId;
                AddPointsToPlayer(ballID);
                Destroyed();
            }
        }
    }
    void Destroyed()
    {

        Destroy(this.gameObject);
    }

    void AddPointsToPlayer(int playerId)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player" + playerId);
        if (player != null)
        {
            PlayerScript script = player.GetComponent<PlayerScript>();
            if (script != null)
            {
                script.IncreasePoints(pointsForDestroying);
            }
        }
    }
}
