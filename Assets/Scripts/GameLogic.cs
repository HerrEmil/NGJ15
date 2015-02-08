﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLogic : MonoBehaviour {

	private static List<GameObject> Boxes;
	private SoundController SoundController;
    public static float Radius = 6f;
	public float NewLevelLoadDelay = 5f;

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

	public void EndLevel()
	{
		// Plays outtro music
		SoundController.StopMusicClip(2);
		
		SoundController.PlayMusicClip(3);

		// Loads next level
		Invoke("Application.LoadLevel(Application.loadedLevel + 1)", NewLevelLoadDelay);
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
