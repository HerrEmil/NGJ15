using UnityEngine;
using System.Collections;

public class BossBehaviour : MonoBehaviour
{
    public int breakingHits = 0;
    public int pointsForDestroying = 5;

    private Animator animator;

	private GameLogic GameLogic;
	private SoundController SoundController;

    void Start()
    {
        animator = GetComponent<Animator>();

		GameLogic = GameObject.Find("GameLogic").GetComponent<GameLogic>();
		SoundController = GameObject.Find("GameLogic").GetComponent<SoundController>();
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
		SoundController.PlaySoundClip(7);

		GameLogic.EndLevel();

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
