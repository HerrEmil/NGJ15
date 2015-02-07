using UnityEngine;
using System.Collections;

public class Hexagons : MonoBehaviour {

    public int breakingHits;
    public Color neutralColor;
    public bool unbreakable = false;
    public int pointsForDestroying = 1;

    private int playerId = 0;
    private bool canDestory = false;

    void OnCollisionEnter2D(Collision2D coll)
    {
        print("hit");
        if (coll.gameObject.tag == "Ball") {
            print("hit by ball");
            var ballScript = coll.transform.GetComponent<BallScript>();
            var ballID = ballScript.playerId;

            if (breakingHits != 0) { 
                breakingHits--;
                BreakingSomeMore();
            }
            else
            {
                canDestory = true;
            }

            print(playerId + " : " + ballID);
            if (playerId.Equals(ballID) && canDestory)
            {
                print("destroyed");
                Destroyed();
            }
            else
            {
                print("Add color");
                playerId = ballID;
                ChangeBoxColor(ballScript.playerColor);
            }
        }
    }

    private void BreakingSomeMore()
    {
        
    }

    void ResetToNeutral()
    {
        GetComponent<SpriteRenderer>().color = neutralColor;
    }

    void ChangeBoxColor(Color playerColor)
    {
        GetComponent<SpriteRenderer>().color = playerColor;
    }

    void Destroyed()
    {
        AddPointsToPlayer();
        Destroy(this.gameObject);
    }

    void AddPointsToPlayer()
    {
        GameObject.FindGameObjectWithTag("Player" + playerId).GetComponent<PlayerScript>().IncreasePoints(pointsForDestroying);
    }
}
