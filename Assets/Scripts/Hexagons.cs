using UnityEngine;
using System.Collections;

public class Hexagons : MonoBehaviour {

    public int breakingHits;
    public bool unbreakable = false;
    public int pointsForDestroying = 1;
    public Sprite smallCrack;
    public Sprite largeCrack;

    private bool canDestory = false;
    private Color neutralColor;

	private PowerupLogic PowerupLogic;
	private SoundController SoundController;

    public int PlayerId { get; set; }

    void Start()
    {
        PlayerId = 0;
        neutralColor = GetComponent<SpriteRenderer>().color;

		// Gets the powerup logic
		PowerupLogic = GameObject.Find("GameLogic").GetComponent<PowerupLogic>();
		SoundController = GameObject.Find ("GameLogic").GetComponent<SoundController>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!unbreakable)
        {
            if (coll.gameObject.tag == "Ball")
            {
                var ballScript = coll.transform.GetComponent<BallScript>();
                var ballID = ballScript.PlayerId;

				SoundController.PlaySoundClip(Mathf.Abs(Random.Range(0,1)));

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
                else if (breakingHits == 0)
                {
                    PlayerId = ballID;
                    ChangeBoxColor(ballScript.PlayerColor);
                }
            }
        }
    }

    private void BreakingSomeMore()
    {
        if (breakingHits == 2)
        {
            GetComponent<SpriteRenderer>().sprite = smallCrack;
        }
        else if (breakingHits == 1)
        {
            GetComponent<SpriteRenderer>().sprite = largeCrack;
        }
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
		SoundController.PlaySoundClip(6);

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
