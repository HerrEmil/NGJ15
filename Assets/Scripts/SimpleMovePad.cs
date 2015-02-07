using UnityEngine;
using System.Collections;

public class SimpleMovePad : MonoBehaviour {

    public Player player;
    private string prefix;
	// Use this for initialization
	void Start () {
        switch (player)
        {
            case Player.Player1:
                prefix = "P1_";
                break;
            case Player.Player2:
                prefix = "P2_";
                break;
            case Player.Player3:
                prefix = "P3_";
                break;
            case Player.Player4:
                prefix = "P4_";
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
        var move = Input.GetAxis(prefix + "Horizontal");
        if (move != 0)
        {
           // rigidbody2D.AddForce(new Vector2(move * 3, 0));
            gameObject.transform.Translate(new Vector3(move * 0.1f, 0, 0));
        }
        var up = Input.GetAxis(prefix + "Vertical");
        if (up != 0)
        {
            gameObject.transform.Translate(new Vector3(0, up * 0.1f, 0));
        }
	}
}

public enum Player
{
    Player1, Player2, Player3, Player4
}