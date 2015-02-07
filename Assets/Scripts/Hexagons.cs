using UnityEngine;
using System.Collections;

public class Hexagons : MonoBehaviour {

    public int breakingHits;
    public bool unbreakable = false;
    public int pointsForDestroying = 1;

    private bool canDestory = false;
    private Color neutralColor;

	private PowerupLogic PowerupLogic;

    public int PlayerId { get; set; }

    void Start()
    {
        PlayerId = 0;
        neutralColor = GetComponent<SpriteRenderer>().color;

		// Gets the powerup logic
		PowerupLogic = GameObject.Find("GameLogic").GetComponent<PowerupLogic>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!unbreakable)
        {
            if (coll.gameObject.tag == "Ball")
            {
                var ballScript = coll.transform.GetComponent<BallScript>();
                var ballID = ballScript.PlayerId;

                if (breakingHits != 0)
                {
                    breakingHits--;
                    BreakingSomeMore();
                }
                else
                {
                    canDestory = true;
                }

                if (PlayerId.Equals(ballID) && canDestory)
                {
                    AddPointsToPlayer();
                    Destroyed();
                }
                else
                {
                    PlayerId = ballID;
                    ChangeBoxColor(ballScript.PlayerColor);
                }
            }
        }
    }

    private void BreakingSomeMore()
    {
        
    }

    public void ResetToNeutral()
    {
        GetComponent<SpriteRenderer>().color = neutralColor;
        PlayerId = 0;
    }

    void ChangeBoxColor(Color playerColor)
    {
        GetComponent<SpriteRenderer>().color = playerColor;
    }

    void Destroyed()
    {
		PowerupLogic.RunPowerup(transform.position);

        Destroy(this.gameObject);
    }

    void AddPointsToPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player" + PlayerId);
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
