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
        
		float h = Input.GetAxis(prefix + "Horizontal");
		float v = Input.GetAxis(prefix + "Vertical");

        Vector2 targetPos = new Vector2(h, v).normalized ;
        var targetAngle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        Vector3 lookVectorNormal = GetNormalVectorToCenter();
        var currentPos = lookVectorNormal;
        var currentAngle = Mathf.Atan2(currentPos.y, currentPos.x) * Mathf.Rad2Deg;

        var difference = Mathf.DeltaAngle(currentAngle, targetAngle);
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
        
        Vector3.Lerp(transform.position, lookVectorNormal * DesiredDistanceFromCenter, 1 * Time.deltaTime);

        if (Input.GetButtonDown(prefix + "Fire"))
        {
           
            GameObject b = Instantiate(ball, spawnBall.position, Quaternion.identity) as GameObject;
            b.GetComponentInChildren<BallMovement>().SetInitialVelocity(-lookVectorNormal);
            b.GetComponentInChildren<BallScript>().SetPlayerScript(playerScript);
        }

        var lt = Input.GetAxis(prefix + "LT");
        if (ActiveInput(lt))
        {
            transform.RotateAround(StageCenter.transform.position, new Vector3(0, 0, 1), 10 * Time.deltaTime * lt * MovementSpeed);
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
