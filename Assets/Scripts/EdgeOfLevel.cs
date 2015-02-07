using UnityEngine;
using System.Collections;

public class EdgeOfLevel : MonoBehaviour {

    void Start()
    {
        gameObject.GetComponent<CircleCollider2D>().radius = GameLogic.Radius;
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.transform.tag.Equals("Ball"))
        {
            int playerId = coll.gameObject.GetComponent<BallScript>().PlayerId;
            ResetSelectedHexagons(playerId);
            Destroy(coll.gameObject);
        }
    }

    private void ResetSelectedHexagons(int playerId)
    {
        GameObject[] hexagons = GameObject.FindGameObjectsWithTag("Boxes");
        for (int i = 0; i < hexagons.Length; i++)
        {
            var hexScript = hexagons[i].GetComponent<Hexagons>();
            if (hexScript.PlayerId.Equals(playerId))
            {
                hexScript.ResetToNeutral();
            }
        }
    }
}
