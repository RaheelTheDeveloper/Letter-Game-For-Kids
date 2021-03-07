using UnityEngine;
using System.Collections;

public class PlayAudio : MonoBehaviour {
	public AudioSource toPlay;
	public bool isAwakeOn=true;

	void OnEnable()
	{
		if (isAwakeOn) 
		{
			if (AppController.isSound)
			{
				if (!GetComponent<AudioSource>().isPlaying) 
				{
					GetComponent<AudioSource>().Play ();
				}
			}
		}
	}
	void Awake()
	{

	}
	void playAudio () 
	{
		if (AppController.isSound) 
		{
			toPlay.GetComponent<AudioSource>().Play();
		}
	}
	
	void stopAudio () 
	{
		if (AppController.isSound) 
		{
			toPlay.GetComponent<AudioSource>().Stop();
		}
	}
}
