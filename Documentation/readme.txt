Welcome! 

Unity Playground offers a nice entry level into Unity, but does not provide 
an easy way for simple adaptive music switching, or basic randomisation of audio. 
That’s why we developed these small tools, meant for unity playground or any other 
way you might find them useful. 

Below is a small guide on how to get started using the provided scripts. 
Everything is free to use as you please, including all audio assets. 

Enjoy! 


Video tutorial can be found here: 

https://www.youtube.com/watch?v=oWZ0DdHQoIw

________________________________________________________________________

The following scripts are  used with the condition scripts in Unity. 
________________________________________________________________________

TriggerRandomAudio.cs

    Plays a random audio clip from the array. It's possible to set a 
    random pitch to be applied everytime this script is triggered. 


TriggerMixerSnapshot.cs

    Choose a snapshot to fade to. Use TransitionTo() to trigger snapshot abd provide 
    a float to specify how long the transition should take. 


ChooseMusicCue.cs
    Choose what element in the array should be triggered in the music container. 
    It's possible to set how fast the change should happen and set the fade out time. 
    This script change the music cue for all preset MusicContainers, so all of them stay in sync. 

________________________________________________________________________

These scripts are put on a gameobject and is playing continuely.
________________________________________________________________________


MusicContainer.cs

    This is a music player, that can hold a number of music files. 
    Use the ChooseMusicCue.cs to select what music to play. Remember to set the tempo(BPM) 
    to the BPM the music was composed in. The music player starts by playing the music cue in 
    position 0 of the array (the first file loaded in the array)


FootstepsTrigger.cs

    Place on a character, and it will trigger with set interval (frequency), but only when the character moves. 


LoopingRandomAudio.cs

    Continuously play audio. Picks a new random sound when the sound is played to end. 
    The looping audio can be stopped by using a trigger to call updateShouldPlay(). 
    Call methods with costum actions from the condition scripts. 


TimedRepeatRandomAudio.cs

    Plays random sounds with interval in between, set this with the frequency slider. 






