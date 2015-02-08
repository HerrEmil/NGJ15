using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLogic : MonoBehaviour {

	private static List<GameObject> Boxes;
	private SoundController SoundController;
    public static float Radius = 6f;
	public float NewLevelLoadDelay = 5f;

    public bool UseCountDown;
    public bool IsActive;

    public Sprite Three, Two, One, Go;

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
        print("Count " + number);
        switch (number)
        {
            case 3:

                break;
            case 2:

                break;
            case 1:

                break;
        }
        yield return new WaitForSeconds(1);
        if (number > 1)
        {
            StartCoroutine(ShowNumber(number - 1));
        }
        else
        {
            IsActive = true;
            print("GO!");
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
		SoundController.StopMusicClip(2);
		
		SoundController.PlayMusicClip(3);



		// Loads next level
		Invoke("LoadNextLevel", NewLevelLoadDelay);
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
