using UnityEngine;
using System.Collections;

public class SimpleMovePad : MonoBehaviour {

    public Player player;
    private string prefix;
    private bool isHit;
    private float hitTimer;
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
	
    //void OnCollisionEnter2D(Collision2D col) {
    //    if (col.gameObject.name.Contains("pad"))
    //    {
    //        SimpleMovePad otherPad = col.gameObject.GetComponent<SimpleMovePad>();
            
    //        var ownVelocity = Mathf.Abs( rigidbody2D.velocity.magnitude);
    //        var otherVelocity = Mathf.Abs( col.gameObject.rigidbody2D.velocity.magnitude);

    //        print("Bang on " + col.gameObject.name + " own vel: " + rigidbody2D.velocity + ", other vel: " + col.gameObject.rigidbody2D.velocity);

    //        var ownDir = rigidbody2D.velocity.normalized.x;

    //        isHit = true;
    //        otherPad.isHit = true;

    //        if (ownVelocity > otherVelocity)
    //        {
    //            rigidbody2D.velocity = Vector2.zero;
    //            col.gameObject.rigidbody2D.velocity = Vector2.zero;
    //            hitTimer = 0.5f;
    //            otherPad.hitTimer = 1f;
    //            col.gameObject.rigidbody2D.AddForce(new Vector2(ownDir * 100, 0));
    //            rigidbody2D.AddForce(new Vector2(-ownDir * 50, 0));
    //        }
    //        if (ownVelocity == otherVelocity)
    //        {
    //            // Each one gets a random amount of push
    //            rigidbody2D.velocity = Vector2.zero;
    //            rigidbody2D.AddForce(new Vector2(-ownDir * Random.Range(30, 80), 0));
    //        }
    //    }
    //}

	// Update is called once per frame
	void Update () {
        if (player == Player.Player1)
            print("Velocity: " + rigidbody2D.velocity);
        if (hitTimer < 0)
        {
            isHit = false;
        }
        var move = Input.GetAxis(prefix + "Horizontal");
      //  print("Move " + move);
        if (!isHit && (move > 0.2f || move < -0.2f))
        {
            rigidbody2D.AddForce(new Vector2(move * 3, 0));
           // gameObject.transform.Translate(new Vector3(move * 0.1f, 0, 0));
        }

        hitTimer -= Time.deltaTime;
        if (gameObject.transform.position.y != 3)
        {
            gameObject.transform.Translate(new Vector3(0, 3 - gameObject.transform.position.y));
        }
       // var up = Input.GetAxis(prefix + "Vertical");
       //// print("Up: " + up);
       // if (up > 0.2f || up < -0.2f)
       // {
            
       //     gameObject.transform.Translate(new Vector3(0, up * 0.1f, 0));
       // }
	}
}

public enum Player
{
    Player1, Player2, Player3, Player4
}