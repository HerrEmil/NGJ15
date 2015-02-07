using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {

    public int playerId = 0;
    public Color playerColor;
    public GameObject pointsText;

    public int maxBalls = 3;
    public List<GameObject> balls;

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

    public int GetNumberOfBalls()
    {
        return (balls != null) ? balls.Count : 0;
    }
}
