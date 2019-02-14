	using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[AddComponentMenu("Playground/Audio/Music Container")]
public class MusicContainer : MonoBehaviour {

	[Header("Tempo of the Music")]
	[Space(3)]
	public int bpm = 135;
	[Space(10)]

	[Header("Choose where the music changes happens")]
	[Space(3)]
	// public ChangeOnNext changeOnNext = ChangeOnNext.OnNextBar;
	public static float nextChangeOn = 4f;
	
	[Space(10)]
	[Header("Type number of Music Cues and load below")]

	public AudioClip[] musicClips;

	[Space(10)]
	[Header("Choose output mixer")]
	public  AudioMixerGroup outputMixerGroup;
	private AudioSource[] audioSources = new AudioSource[2];

	private double nextEventTime;
	
	
	public static float fadeTime = 0.5f;

	public static int nextIndex;
	private int indexPlaying;

	private int flip = 0;
	private int notFlip = 1;
	private double scheduledStart;

	private double progressInGrid;
	private double time;

	void Start () 
	{
		//makes two audio sources to flip between, for changing music. 
		for (int i = 0; i < 2; i++)
        {
            GameObject child = new GameObject("MusicPlayer");
            child.transform.parent = gameObject.transform;
            audioSources[i] = child.AddComponent<AudioSource>();
			audioSources[i].loop = true;
			audioSources[i].playOnAwake = false;
			audioSources[i].outputAudioMixerGroup = outputMixerGroup;
        }
		audioSources[flip].clip = musicClips[flip];
		audioSources[flip].Play();
		indexPlaying = flip;
		
		audioSources[notFlip].Stop();
		nextEventTime = AudioSettings.dspTime + 1.0f;
		
	
	}
	void Update()
    {
		float changeOnBeat = nextChangeOn;
		double gridSize = (60.0f / bpm * changeOnBeat);
		double dspTime = AudioSettings.dspTime;
	
        time = audioSources[flip].time;
		progressInGrid = time % gridSize;
		
		changeMusic(gridSize, dspTime);	

		if (scheduledStart < dspTime)
			stopAndFade();

		Debug.Log(" index playing: " + indexPlaying + "  next index: " + nextIndex + "   name: " + this.name);
    }

	private void changeMusic(double gridSize, double dspTime)
	{
		if(nextIndex != indexPlaying)
		{
			flip = 1 - flip;
			notFlip = Mathf.Abs(flip - 1);

			audioSources[flip].clip = musicClips[nextIndex];
			indexPlaying = nextIndex;
			
			nextEventTime = (gridSize - progressInGrid) + dspTime;
			audioSources[flip].volume = 1;
			audioSources[flip].PlayScheduled(nextEventTime);
			scheduledStart = nextEventTime;
		}
	}
	private void stopAndFade()
	{
		if(audioSources[notFlip].isPlaying && audioSources[notFlip].volume > 0)
			audioSources[notFlip].volume -= Time.deltaTime * fadeTime;
		else
		{
			audioSources[notFlip].Stop();
			audioSources[notFlip].volume = 1;
		}
	}

}
