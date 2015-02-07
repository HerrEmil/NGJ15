using UnityEngine;
using System.Collections;

public class PlayerDummyMovement : MonoBehaviour {

	public float MovementSpeed = 1;
	public GameObject StageCenter;
	public float DesiredDistanceFromCenter;
	public float GravityForce;

	// Use this for initialization
	void Start () 
	{
		// Set the player object at the correct distance from the stage
		Vector3 lookVectorNormal = GetNormalVectorToCenter();

		Quaternion LookVector = Quaternion.LookRotation(lookVectorNormal);

		transform.position = lookVectorNormal * (DesiredDistanceFromCenter-2);
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
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		transform.RotateAround(StageCenter.transform.position, new Vector3(0,0,1), 10*Time.deltaTime * h * MovementSpeed);
	}

	void FixedUpdate()
	{

	}
}
