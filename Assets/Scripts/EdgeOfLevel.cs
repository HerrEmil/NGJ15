using UnityEngine;
using System.Collections;

public class EdgeOfLevel : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {
        //if (coll.transform.tag.Equals("Ball"))
        //{
        //    int playerId = coll.gameObject.GetComponent<BallScript>().playerId;
        //    ResetSelectedHexagons(playerId);
        //    ResetBallPosition(playerId);
        //}
    }

    private void ResetSelectedHexagons(int playerId)
    {
        //GameObject[] hexagons = GameObject.FindGameObjectsWithTag("H")
    }

    private void ResetBallPosition(int playerId)
    {
        // reset the ball at the player position
    }
}
