using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[AddComponentMenu("Playground/Audio/Chose Music Cue")]
public class ChooseMusicCue : Action {

	[Space(5)]
	[Header("Choose music cue to change to")]
	public int cueIndex;

	[Space(10)]
	[Header("Chose when the change happens")]
	public ChangeOnNext changeOnNext = ChangeOnNext.OnNextBar;
	
	[Space(10)]
	[Header("Fade out")]
	[Range(0.01f,50f)]
	
	public float fadetime = 1f;


	public override bool ExecuteAction(GameObject dataObject)
	{
		
			MusicContainer.nextIndex = cueIndex;
			MusicContainer.nextChangeOn = (float) changeOnNext * 0.5f;
			MusicContainer.fadeTime = 1/fadetime;
			return true;
		
	}

	public enum ChangeOnNext{
		
		OnNext8thNote = 1,
		OnNextBeat = 2,
		OnNextHalfNote = 4,
		OnNextBar = 8,
		OnNextTwoBarInLoop = 16,
		
	}
}