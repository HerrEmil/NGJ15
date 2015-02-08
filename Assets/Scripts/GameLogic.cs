using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameLogic : MonoBehaviour {

	private static List<GameObject> Boxes;
	private SoundController SoundController;
    public static float Radius = 6f;
	public float NewLevelLoadDelay = 10f;

    public bool UseCountDown;
    public bool IsActive;

    public GameObject Player1Text, Player2Text, Player3Text, Player4Text, TextPositions;

    public GameObject Three, Two, One, Go;

	// Use this for initialization
	void Start () 
	{

		Boxes = new List<GameObject>();

		SoundController = GetComponent<SoundController>();

		SoundController.PlayMusicClip(0);

		// Get all boxes at start
		GameObject[] startBoxes = GameObject.FindGameObjectsWithTag("Boxes");

		for(int i = 0; i < startBoxes.Length; i++)
		{
			// Adds all the start boxes to the more flexible Boxes array list
			Boxes.Add(startBoxes[i]);
		}
        if (UseCountDown)
        {
            IsActive = false;
            DoTheCountdown();
        }
        else
        {
            IsActive = true;
        }
	}

    public void DoTheCountdown()
    {
        StartCoroutine(ShowNumber(3));
    }

    private IEnumerator ShowNumber(int number)
    {
        var time = 0.6f;
        print("Count " + number);
        GameObject inst = null;
        switch (number)
        {
            case 3:
                inst = Three;
				SoundController.PlaySoundClip(15);
                break;
            case 2:
                inst = Two;
				SoundController.PlaySoundClip(14);
                break;
            case 1:
                inst = One;
				SoundController.PlaySoundClip(13);
                break;
            case 0:
				SoundController.PlaySoundClip(16);
                IsActive = true;
                inst = Go;
               
                break;
        }
        GameObject go = Instantiate(inst, Vector3.zero, Quaternion.identity) as GameObject;
        Destroy(go, time);
        yield return new WaitForSeconds(time);
        if (number > 0)
        {
            StartCoroutine(ShowNumber(number - 1));
        }
       
    }

	// Update is called once per frame
	void Update () {

		UpdateLists();

		UpdateMusic();
	}

	private void UpdateMusic()
	{
		if(GetBoxCount() < 50 && SoundController.GetCurrentlyPlayingMusicClip() == 0)
		{
			// Play more intense music
			SoundController.StopMusicClip(0);
			
			SoundController.PlayMusicClip(1);
		}
		else if(GetBoxCount() < 20 && SoundController.GetCurrentlyPlayingMusicClip() == 1)
		{
			// Play even more intense music
			SoundController.StopMusicClip(1);
			
			SoundController.PlayMusicClip(2);
		}
	}

	private void LoadNextLevel()
	{
		if(Application.loadedLevel < 2)
		{
			Application.LoadLevel(Application.loadedLevel + 1);
		}
		else
		{
			Application.LoadLevel (0);
		}

	}

	public void EndLevel()
	{
		// Plays outtro music
		SoundController.StopMusicClip(0);
		SoundController.StopMusicClip(1);
		SoundController.StopMusicClip(2);
		
		SoundController.PlayMusicClip(3);

		SoundController.PlaySoundClip(9);

        ShowCrazyTexts();

		// Loads next level
		Invoke("LoadNextLevel", NewLevelLoadDelay);
	}

    private void ShowCrazyTexts()
    {
        PlayerScript p1, p2, p3, p4;
        p1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerScript>();
        p2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerScript>();
        p3 = GameObject.FindGameObjectWithTag("Player3").GetComponent<PlayerScript>();
        p4 = GameObject.FindGameObjectWithTag("Player4").GetComponent<PlayerScript>();

        PlayerScript[] players = new PlayerScript[] { p1, p2, p3, p4 };

        var mostMove = players.Aggregate((i1, i2) => i1.DistanceMoved > i2.DistanceMoved ? i1 : i2);
        var leastMove = players.Aggregate((i1, i2) => i1.DistanceMoved < i2.DistanceMoved ? i1 : i2);

        var mostPoints = players.Aggregate((i1, i2) => i1.Points > i2.Points ? i1 : i2);
        var leastPoints = players.Aggregate((i1, i2) => i1.Points < i2.Points ? i1 : i2);

        var mostDeaths = players.Aggregate((i1, i2) => i1.PlayerDeaths > i2.PlayerDeaths ? i1 : i2);
        var leastDeaths = players.Aggregate((i1, i2) => i1.PlayerDeaths < i2.PlayerDeaths ? i1 : i2);

        var mostCollisions = players.Aggregate((i1, i2) => i1.NumberOfBounces > i2.NumberOfBounces ? i1 : i2);
        var leastCollisions = players.Aggregate((i1, i2) => i1.NumberOfBounces < i2.NumberOfBounces ? i1 : i2);

        GameObject playerWin = null;
        switch (mostPoints.playerId)
        {
            case 1:
                playerWin = Player1Text;
                break;
            case 2:
                playerWin = Player2Text;
                break;
            case 3:
                playerWin = Player3Text;
                break;
            case 4:
                playerWin = Player4Text;
                break;
        }

        GameObject playerCollision = null;

        switch (mostCollisions.playerId)
        {
            case 1:
                playerCollision = Player1Text;
                break;
            case 2:
                playerCollision = Player2Text;
                break;
            case 3:
                playerCollision = Player3Text;
                break;
            case 4:
                playerCollision = Player4Text;
                break;
        }

        GameObject playerLeastMove = null;

        switch (leastMove.playerId)
        {
            case 1:
                playerLeastMove = Player1Text;
                break;
            case 2:
                playerLeastMove = Player2Text;
                break;
            case 3:
                playerLeastMove = Player3Text;
                break;
            case 4:
                playerLeastMove = Player4Text;
                break;
        }

        GameObject playerTerrible = null;
        switch (leastPoints.playerId)
        {
            case 1:
                playerTerrible = Player1Text;
                break;
            case 2:
                playerTerrible = Player2Text;
                break;
            case 3:
                playerTerrible = Player3Text;
                break;
            case 4:
                playerTerrible = Player4Text;
                break;
        }

        var go = Instantiate(TextPositions) as GameObject;

        var winPos = GameObject.Find("WinPlayerPos").transform.position;
        winPos = new Vector3(winPos.x, winPos.y, 20);
        Instantiate(playerWin, winPos, Quaternion.identity);

        var collPos = GameObject.Find("MariachiPlayerPos").transform.position;
        collPos = new Vector3(collPos.x, collPos.y, 20);
        Instantiate(playerCollision, collPos, Quaternion.identity);

        var movePos = GameObject.Find("SiestaPlayerPos").transform.position;
        movePos = new Vector3(movePos.x, movePos.y, 20);
        Instantiate(playerLeastMove, movePos, Quaternion.identity);

        var terriblePos = GameObject.Find("TerriblePlayerPos").transform.position;
        terriblePos = new Vector3(terriblePos.x, terriblePos.y, 20);
        Instantiate(playerTerrible, terriblePos, Quaternion.identity);
     //   Instantiate(playerWin);
    }

	public int GetBoxCount()
	{
		return Boxes.Count;
	}

	// Cleans out null objects from the lists when they've been destroyed
	private void UpdateLists()
	{
		Boxes.RemoveAll(item => item == null);
	}
}
