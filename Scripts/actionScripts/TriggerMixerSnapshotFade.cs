using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[AddComponentMenu("Playground/Audio/Trigger Mixer Snapshot")]
public class TriggerMixerSnapshotFade : Action {

	public AudioMixerSnapshot snapshotName;
	[Space(10)]
	[Header("Fade time")]
	[Range(0f,10f)]
	public float fadeTime;
	// Use this for initialization
	
	public override bool ExecuteAction(GameObject dataObject)
	{
		if(snapshotName != null)
		{
			snapshotName.TransitionTo(fadeTime);
			return true;
		}
		else
		{
			Debug.LogWarning("mixer snapshot is null");
			return false;
		}
	}	


}
