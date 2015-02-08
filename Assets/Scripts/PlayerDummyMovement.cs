using UnityEngine;
using System.Collections;

public class PlayerDummyMovement : MonoBehaviour {

	public float MovementSpeed = 1;
	public GameObject StageCenter;
	public float DesiredDistanceFromCenter;
	public float GravityForce;

    public GameObject ball;
    public Transform spawnBall;

    public PlayerScript playerScript;

    public Player player;
    private string prefix;

    private float actualSpeed;
    public float acceleration = 1;
    public float topSpeed = 10;
    private float direction;

	// Use this for initialization
	void Start () 
	{
        DesiredDistanceFromCenter = GameLogic.Radius;
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
		// Set the player object at the correct distance from the stage
		Vector3 lookVectorNormal = GetNormalVectorToCenter();

		Quaternion LookVector = Quaternion.LookRotation(lookVectorNormal);

		transform.position = lookVectorNormal * (DesiredDistanceFromCenter);
	}

	// Gets normalized vector between this object and stage center
	private Vector3 GetNormalVectorToCenter()
	{
		// Point the collider at the stage center
		Vector3 CenterToColliderVector = this.transform.position - StageCenter.transform.position;
		
		Vector3 normalVector = CenterToColliderVector.normalized;

		return normalVector;
	}
	
	// Update is called once per frame
	void Update () 
	{
        
        //float h = Input.GetAxis(prefix + "Horizontal");
        //float v = Input.GetAxis(prefix + "Vertical");

        //Vector2 targetPos = new Vector2(h, v).normalized ;
        //var targetAngle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        Vector3 lookVectorNormal = GetNormalVectorToCenter();
        //var currentPos = lookVectorNormal;
        //var currentAngle = Mathf.Atan2(currentPos.y, currentPos.x) * Mathf.Rad2Deg;

        //var difference = Mathf.DeltaAngle(currentAngle, targetAngle);
        //print("Dif: " + difference);

        //if (difference > 1 || difference < -1)
        //{
        //    if (difference > 0)
        //    {
        //        // Move clock wise
        //        transform.RotateAround(StageCenter.transform.position, new Vector3(0, 0, 1), 10 * Time.deltaTime * MovementSpeed);
        //    }
        //    else
        //    {
        //        // Move counter clock wise
        //        transform.RotateAround(StageCenter.transform.position, new Vector3(0, 0, 1), 10 * Time.deltaTime * -1 * MovementSpeed);
        //    }
        //}

        //print("Target: " + targetAngle + ", current: " + currentAngle);
        //print("Target: " + targetPos + ", current: " + currentPos);

        //if (ActiveInput(h))
        //{
        //    transform.RotateAround(StageCenter.transform.position, new Vector3(0, 0, 1), 10 * Time.deltaTime * h * MovementSpeed);

        //}
        
     //   Vector3.Lerp(transform.position, lookVectorNormal * DesiredDistanceFromCenter, 1 * Time.deltaTime);

        if (Input.GetButtonDown(prefix + "Fire"))
        {
            if (playerScript.GetNumberOfBalls() < playerScript.maxBalls)
            {
                ShootBall(lookVectorNormal);
            }
        }

        var lt = Input.GetAxis(prefix + "LT");
        if (lt == 0)
        {
            if (prefix.Equals("P1_"))
            {
                if (Input.GetKey("right"))
                {
                    lt = 1;
                }
                if (Input.GetKey("left"))
                {
                    lt = -1;
                }
            }

            if (prefix.Equals("P2_"))
            {
                if (Input.GetKey("e"))
                {
                    print("Yo P2 e");
                    lt = 1;
                }
                if (Input.GetKey("q"))
                {
                    lt = -1;
                }
                if (Input.GetKeyDown("w"))
                {
                    ShootBall(lookVectorNormal);
                }
            }

            if (prefix.Equals("P3_"))
            {
                if (Input.GetKey("n"))
                {
                    lt = 1;
                }
                if (Input.GetKey("v"))
                {
                    lt = -1;
                }
                if (Input.GetKeyDown("b"))
                {
                    ShootBall(lookVectorNormal);
                }
            }

            if (prefix.Equals("P4_"))
            {
                if (Input.GetKey("p"))
                {
                    lt = 1;
                }
                if (Input.GetKey("i"))
                {
                    lt = -1;
                }
                if (Input.GetKeyDown("o"))
                {
                    ShootBall(lookVectorNormal);
                }
            }
        }
        
        if (ActiveInput(lt))
        {
            direction = Mathf.Sign(lt);
            var scale = 1f;
            if (direction > 0 && actualSpeed < 0 || direction < 0 && actualSpeed > 0)
            {
                scale = 3f;
            }
            actualSpeed += scale * acceleration * lt * Time.deltaTime;
            if (actualSpeed > topSpeed)
            {
                actualSpeed = topSpeed;
            }
            else if (actualSpeed < -topSpeed)
            {
                actualSpeed = -topSpeed;
            }
            
        }
        else
        {
            if (actualSpeed > 0)
            {
                actualSpeed -= acceleration * Time.deltaTime;
                if (actualSpeed < 0)
                {
                    actualSpeed = 0;
                }
            }
            else
            {
                actualSpeed += acceleration * Time.deltaTime;
                if (actualSpeed > 0)
                {
                    actualSpeed = 0;
                }
            }
        }
        if (actualSpeed != 0)
        {
            transform.RotateAround(StageCenter.transform.position, new Vector3(0, 0, 1), Time.deltaTime * actualSpeed);
        }
        else
        {
            actualSpeed = 0;
        }
	}

    private void ShootBall(Vector2 lookVectorNormal)
    {
        if (playerScript.GetNumberOfBalls() < playerScript.maxBalls)
        {
            GameObject b = Instantiate(ball, spawnBall.position, Quaternion.identity) as GameObject;
            b.GetComponentInChildren<BallMovement>().SetInitialVelocity(-lookVectorNormal);
            b.GetComponentInChildren<BallScript>().SetPlayerScript(playerScript);
            playerScript.balls.Add(b);
        }
    }

    private bool ActiveInput(float input)
    {
        return input > 0.5f || input < -0.5f;
    }

    public void SetDesiredDistanceFromCenter(float distance)
    {
        this.DesiredDistanceFromCenter = distance;

    }

	void FixedUpdate()
	{

	}
}
