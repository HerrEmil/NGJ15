﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {

    public int playerId = 0;
    public Color playerColor;
    public GameObject pointsText;

    public GameObject padSmall, padNormal, padLarge, own;

    public int maxBalls = 3;
    public List<GameObject> balls;

    private int playerPoints = 0;

    private int playerDeaths = 0;
    private float longestStreak = 0f;
    private float distanceMoved = 0f;

    private int numberOfBounces = 0;

    public int PlayerDeaths { get { return playerDeaths; } }
    public float LongestStreak { get { return longestStreak; } }
    public float DistanceMoved { get { return distanceMoved; } }
    public int NumberOfBounces { get { return numberOfBounces; } }
    public int Points { get { return playerPoints; } }

    void Start()
    {
        Sprite smallSprite = null, normalSprite = null, largeSprite = null;
        switch (playerId)
        {
            case 1:
                smallSprite = Resources.Load<Sprite>("blue_1");
                normalSprite = Resources.Load<Sprite>("blue_2");
                largeSprite = Resources.Load<Sprite>("blue_3");
                break;
            case 2:
                smallSprite = Resources.Load<Sprite>("green_1");
                normalSprite = Resources.Load<Sprite>("green_2");
                largeSprite = Resources.Load<Sprite>("green_3");
                break;
            case 3:
                smallSprite = Resources.Load<Sprite>("pink_1");
                normalSprite = Resources.Load<Sprite>("pink_2");
                largeSprite = Resources.Load<Sprite>("pink_3");
                break;
            case 4:
                smallSprite = Resources.Load<Sprite>("red_1");
                normalSprite = Resources.Load<Sprite>("red_2");
                largeSprite = Resources.Load<Sprite>("red_3");
                break;
        }
        own.GetComponentInChildren<SpriteRenderer>().sprite = normalSprite;
        padNormal.GetComponentInChildren<SpriteRenderer>().sprite = normalSprite;
        if (padSmall == null)
        {
            print("null padsmall");
        }
        if (smallSprite == null)
        {
            print("null smallsprite");
        }
      //  padSmall.GetComponentInChildren<SpriteRenderer>().sprite = smallSprite;
      //  padLarge.GetComponentInChildren<SpriteRenderer>().sprite = largeSprite;
    }

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

    public void IncrementDeaths()
    {
        playerDeaths++;
    }

    public void UpdateLongestStreak(float streak)
    {
        if (streak > longestStreak)
        {
            longestStreak = streak;
        }
    }

    public void IncrementDistanceMoved(float dist)
    {
        this.distanceMoved += dist;
    }

    public void IncrementBounces()
    {
        this.numberOfBounces++;
    }
}
