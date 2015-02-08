using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

	/*
	 * Music clips:
	 * 0 - Nordic Games Jam 2015 - Theme 1
	 * 1 - Nordic Games Jam 2015 - Theme 2
	 * 2 - Nordic Games Jam 2015 - Theme 3
	 * 3 - Nordic Games Jam 2015 - Theme 3 end
	 * 
	 * Soundclips:
	 * 0 - Hit ball 1
	 * 1 - Hit ball 2
	 * 2 - Hit ball 3
	 * 3 - Hit ball 4
	 * 4 - Hit ball 5
	 * 5 - Hit ball 6
	 * 6 - Miss ball
	 * 7 - Powerup 1
	 * 8 - Powerup 2
	 * 9 - Win
	 * 10 - Boss Dead
	 * 11 - Boss hit 1
	 * 12 - Boss hit 2
	 * */

	public AudioSource[] MusicClips;
	public AudioSource[] SoundClips;

	private int CurrentlyPlayingMusicClip;
	private int CurrentlyPlayingSoundClip;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	// Starts a specific music clip
	public void PlayMusicClip(int clipNumber)
	{
		if(clipNumber < MusicClips.Length)
		{
			MusicClips[clipNumber].Play();

			CurrentlyPlayingMusicClip = clipNumber;
		}
	}

	// Stops a specific music clip
	public void StopMusicClip(int clipNumber)
	{
		if(clipNumber < MusicClips.Length)
		{
			MusicClips[clipNumber].Stop();

			CurrentlyPlayingMusicClip = -1;
		}
	}

	// Starts a specific sound clip
	public void PlaySoundClip(int clipNumber)
	{
		if(clipNumber < SoundClips.Length)
		{
			SoundClips[clipNumber].Play();

			CurrentlyPlayingSoundClip = clipNumber;
		}
	}

	// Stops a specific sound clip
	public void StopSoundClip(int clipNumber)
	{
		if(clipNumber < SoundClips.Length)
		{
			SoundClips[clipNumber].Stop();

			CurrentlyPlayingSoundClip = -1;
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
