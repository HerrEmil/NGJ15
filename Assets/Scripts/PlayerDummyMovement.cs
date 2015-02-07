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
	void Update () {
	
	}

	void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		UpdateDistanceFromCenter();

		Vector2 force = new Vector2(h,v);

		this.rigidbody2D.AddForce(force * MovementSpeed);
	}

	private void UpdateDistanceFromCenter()
	{
		Vector2 vector2dToCenter = new Vector2(GetNormalVectorToCenter().x, GetNormalVectorToCenter().y);
		rigidbody2D.AddForce(vector2dToCenter * GravityForce);

	}
}
