using UnityEngine;
using System.Collections;

public class EdgeOfLevel : MonoBehaviour {

	private SoundController SoundController;

    void Start()
    {
      //  gameObject.GetComponent<CircleCollider2D>().radius = GameLogic.Radius + 0.5f;

		SoundController = GameObject.Find ("GameLogic").GetComponent<SoundController>();
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.transform.tag.Equals("Ball"))
        {
            var bs = coll.gameObject.GetComponent<BallScript>();
            int playerId = bs.PlayerId;
            if (bs.playerScript.balls.Count == 1)
            {
                ResetSelectedHexagons(playerId);
            }
            bs.playerScript.balls.Remove(coll.gameObject);

			SoundController.PlaySoundClip(2);
            
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
