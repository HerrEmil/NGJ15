﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLogic : MonoBehaviour {

	private static List<GameObject> Boxes;
	private SoundController SoundController;
    public static float Radius = 6f;
	public float NewLevelLoadDelay = 5f;

    public bool UseCountDown;
    public bool IsActive;

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
