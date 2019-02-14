using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BaseAudioClipContainer : Action {

	[Header("Load a list of sounds below")]
	
	public AudioClip[] sounds;
	
	[Header("Select ammount of random pitch applied to new clips")]
	[Range(0,3)]
	public float randomPitch;
	
	[Space(5)]
	[Header("Select the output mixer group")]
	public  AudioMixerGroup outputMixerGroup;
	private AudioClip randomClip;
	protected AudioSource audioPlayer;

	protected void getAudioSourceAndMixer () 
	{
		audioPlayer = GetComponent<AudioSource>();
		audioPlayer.outputAudioMixerGroup = outputMixerGroup;
	}
	
	public void PlayRandomClip()
	{
		float newPitch = 1;
		if (randomPitch != 0)
		{
			float addToPitch = randomPitch + 1;
			newPitch = newPitch * Random.Range( 1 / addToPitch, addToPitch);
		}
		
		if (sounds.Length > 1)
		{
			int index = Random.Range(1, sounds.Length);
			randomClip = sounds[index];
			sounds[index] = sounds[0];
			sounds[0] = randomClip;
		}   

		audioPlayer.clip = sounds[0];
		audioPlayer.pitch = newPitch;

        audioPlayer.Play();


	
	}
}
