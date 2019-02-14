using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[AddComponentMenu("Playground/Audio/Footstep Trigger")]
public class FootstepsTriggerAudio : BaseAudioClipContainer {

	[Header("Set number of seconds between triggers")]
	[Range(0.01f,1f)]
	public float frequency = 0.17f;

	private float timeLastEventFired;
	private Transform body;
	private Vector3 lastPosition;
	private float threshhold = 0.02f;
	
	void Start () {
		body = GetComponent<Transform>();
		timeLastEventFired = frequency;
		getAudioSourceAndMixer();
	}
	

	void Update () {
		

		//check bounds.contain 
		if (Vector2.Distance(lastPosition, body.position) > threshhold && Time.time >= timeLastEventFired + frequency)
		{	
			PlayRandomClip();
			timeLastEventFired = Time.time;
			
		}
		lastPosition = body.position;
		
	}
}
