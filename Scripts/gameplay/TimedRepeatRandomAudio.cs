using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[AddComponentMenu("Playground/Audio/Timed Repeating Random Audio")]
[RequireComponent(typeof(AudioSource))]

public class TimedRepeatRandomAudio : BaseAudioClipContainer {
	public float initialDelay = 0f;
	
	[Header("Set number of seconds between triggers")]
	[Range(0.1f,20f)]
	public float frequency = 1f;

	private float timeLastEventFired;


	private void Start()
	{
		timeLastEventFired = initialDelay - frequency;
		getAudioSourceAndMixer();

	}

	private void Update()
	{
		if(Time.time >= timeLastEventFired + frequency)
		{
			PlayRandomClip();
			timeLastEventFired = Time.time;
		}
	}
}
