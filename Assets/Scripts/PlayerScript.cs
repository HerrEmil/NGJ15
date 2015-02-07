using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    public int playerId = 0;
    public GameObject pointsText;

    private int playerPoints = 0;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void IncreasePoints(int points)
    {
        playerPoints += points;
        pointsText.GetComponent<Text>().text = playerPoints.ToString();
    }

    public void DecreasePoints(int points)
    {
        playerPoints -= points;
    }
}
