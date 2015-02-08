using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {

    public float speed = 3.0f;
    public float maxSpeed = 8f;
    public PhysicsMaterial2D steadyBounce;
    private bool maxSpeedReached;
    private float checkTimer;
	// Use this for initialization
    void Start()
    {
        // Give the ball some initial movement direction
       // SetInitialVelocity(Vector2.one);
        
    }
	
	// Update is called once per frame
	void Update () {
        var speed = rigidbody2D.velocity.magnitude;
        if (speed > 0.001 && speed < 2)
        {
           rigidbody2D.velocity = rigidbody2D.velocity.normalized * speed;
        }

        //if (checkTimer < 0 && rigidbody2D.velocity.magnitude > maxSpeed)
        //{
        //   // print("velocity over maxSpeed");
        //    collider2D.sharedMaterial = steadyBounce;
        //    collider2D.enabled = false;
        //    collider2D.enabled = true;
        //    checkTimer = 1;
        //}
        //checkTimer -= Time.deltaTime;
	}

    public void SetInitialVelocity(Vector2 direction)
    {
        rigidbody2D.velocity = direction.normalized * speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Note: 'col' holds the collision information. If the
        // Ball collided with a racket, then:
        //   col.gameObject is the racket
        //   col.transform.position is the racket's position
        //   col.collider is the racket's collider

        // Hit the left Racket?
        //if (col.gameObject.name == "bluepad")
        //{
        //    // Calculate hit Factor
        //    float y = hitFactor(transform.position,
        //                        col.transform.position,
        //                        col.collider.bounds.size.y);

        //    // Calculate direction, make length=1 via .normalized
        //    Vector2 dir = new Vector2(1, y).normalized;

        //    // Set Velocity with dir * speed
        //    rigidbody2D.velocity = dir * speed;
        //}

       
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketHeight)
    {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.y - racketPos.y) / racketHeight;
    }
}
