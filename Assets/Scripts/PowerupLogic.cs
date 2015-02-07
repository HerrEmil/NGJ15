using UnityEngine;
using System.Collections;

public class PowerupLogic : MonoBehaviour {

	public GameObject[] Powerups;
	public float DropChance = 0.0f;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void RunPowerup(Vector3 position)
	{
		// If the chance to drop is calculate as true
		if(WillDrop())
		{
			var t = Instantiate(Powerups[Random.Range(0,Powerups.Length-1)], position, Quaternion.identity) as Transform;
		}
	}

	private bool WillDrop()
	{
		if(DropChance > 0)
		{
			if(Random.value < DropChance)
			{
				return true;
			}
		}
		return false;
	}
}
