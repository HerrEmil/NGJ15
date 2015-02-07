﻿using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

	//private GameLogic GameLogic;

	public AudioSource[] MusicClips;
	public AudioSource[] SoundClips;

	private int CurrentlyPlayingMusicClip;
	private int CurrentlyPlayingSoundClip;

	// Use this for initialization
	void Start () 
	{
		//GameLogic = GetComponent<GameLogic>();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	// Starts a specific music clip
	public void PlayMusicClip(int clipNumber)
	{
		if(clipNumber <= MusicClips.Length)
		{
			MusicClips[clipNumber].Play();

			CurrentlyPlayingMusicClip = clipNumber;
		}
	}

	// Stops a specific music clip
	public void StopMusicClip(int clipNumber)
	{
		if(clipNumber <= MusicClips.Length)
		{
			MusicClips[clipNumber].Stop();

			CurrentlyPlayingMusicClip = null;
		}
	}

	// Starts a specific sound clip
	public void PlaySoundClip(int clipNumber)
	{
		if(clipNumber <= SoundClips.Length)
		{
			SoundClips[clipNumber].Play();

			CurrentlyPlayingSoundClip = clipNumber;
		}
	}

	// Stops a specific sound clip
	public void StopSoundClip(int clipNumber)
	{
		if(clipNumber <= SoundClips.Length)
		{
			SoundClips[clipNumber].Stop();

			CurrentlyPlayingSoundClip = null;
		}
	}

	// Returns numbers of music clips
	public int GetNumMusicClips()
	{
		return MusicClips.Length;
	}

	// Returns number of sound clips
	public int GetNumSoundClips()
	{
		return SoundClips.Length;
	}

	public int GetCurrentlyPlayingMusicClip()
	{
		return CurrentlyPlayingMusicClip;
	}

	public int GetCurrentlyPlayingSoundClip()
	{
		return CurrentlyPlayingSoundClip;
	}
}