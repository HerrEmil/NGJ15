using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    public int playerId = 0;
    public Color playerColor;
    public GameObject pointsText;

    private int playerPoints = 0;

    public void IncreasePoints(int points)
    {
        playerPoints += points;
        pointsText.GetComponent<Text>().text = playerPoints.ToString();
    }

    public void DecreasePoints(int points)
    {
        playerPoints -= points;
        pointsText.GetComponent<Text>().text = playerPoints.ToString();
    }
}
