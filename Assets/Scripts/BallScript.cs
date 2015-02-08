using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour
{

    public PlayerScript playerScript;

    public int PlayerId { get; set; }
    public Color PlayerColor { get; set; }

    public PlayerDummyMovement playerDummyMovement;

    private float startTime;

    void Start()
    {
        //PlayerScript playerScript = player.GetComponent<PlayerScript>();
        //if (playerScript != null) { 
        //PlayerId = playerScript.playerId;
        //PlayerColor = playerScript.playerColor;
        //}
    }

    public void SetPlayerScript(PlayerScript script)
    {
        this.playerScript = script;
        PlayerId = playerScript.playerId;
        PlayerColor = playerScript.playerColor;
        GetComponent<SpriteRenderer>().color = PlayerColor;
    }

    public void StartTime()
    {
        startTime = Time.time;
    }

    public float GetLiveTime()
    {
        return Time.time - startTime;
    }
}
