using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
[AddComponentMenu("Playground/Audio/Looping Random Audio")]
public class LoopingRandomAudio : BaseAudioClipContainer {

	[Header("Select if audio should play from beginning")]
	public bool shouldPlay = true;
	
	private void Start()
	{
		getAudioSourceAndMixer();
	}
	private void Update()

	{
		if(!audioPlayer.isPlaying && shouldPlay)
		{
			PlayRandomClip();
		}
		
	}
	public void updateShouldPlay(bool update)
	{
		shouldPlay = update;
	}
}
