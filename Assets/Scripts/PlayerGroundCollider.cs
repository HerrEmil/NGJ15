using UnityEngine;
using System.Collections;

public class PlayerGroundCollider : MonoBehaviour {

	public GameObject StageCenter;
	public GameObject Player;
	public float DesiredDistanceFromCenter;
	public Vector3 CenterFacingVector = new Vector3(0,1,0);

	private Quaternion RotationHolder = new Quaternion();


	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		// Get players position and update own position to match
		if(Player)
		{
			Vector2 playerPosition = new Vector2(Player.transform.position.x, Player.transform.position.y);
			Vector2 StageCenter2D = new Vector2(StageCenter.transform.position.x, StageCenter.transform.position.y);

			Vector2 normalVector = (playerPosition-StageCenter2D).normalized;

			//this.transform.position = normalVector * DesiredDistanceFromCenter;
		}

		// Rotate to face stage center
		if(StageCenter)
		{
			transform.RotateAround(StageCenter.transform.position,new Vector3(0,0,1),20.0f*Time.deltaTime);
			// Get vector between the collider and center point
			Vector3 CenterToColliderVector = this.transform.position - StageCenter.transform.position;
			Debug.Log (CenterToColliderVector);
			// Normalize it
			Vector3 normalVector = CenterToColliderVector.normalized;

			RotationHolder.Set(normalVector.x,normalVector.y, normalVector.z, normalVector.z);

			//transform.rotation = RotationHolder;


		}


	}
	
}
