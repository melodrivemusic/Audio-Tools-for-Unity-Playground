using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
[AddComponentMenu("Playground/Audio/Trigger Random Audio")]
public class TriggerRandomAudio : BaseAudioClipContainer {


	void Start () 
	{
		getAudioSourceAndMixer();
	}
	
	public override bool ExecuteAction(GameObject dataObject)
	{
		if(sounds != null)
		{
			PlayRandomClip();
			return true;
		}
		else
		{
			Debug.LogWarning("Sound array is null");
			return false;
		}
	}

}
