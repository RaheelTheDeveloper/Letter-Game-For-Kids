using UnityEngine;
using System.Collections;

public class SoundInit : MonoBehaviour {


	public static bool AudioBegin = false;
	public AudioClip SoundClip;
	private AudioSource SoundSource;
	
	void Awake()
	{
		if (AppController.isMusic) {
						//Debug.Log("Sound Awake");
						if (!AudioBegin) {
								//Debug.Log("Sound Awake Inside");
								DontDestroyOnLoad (gameObject);
								SoundSource = gameObject.AddComponent<AudioSource> ();
								//SoundSource.playOnAwake = false;
								//SoundSource.rolloffMode = AudioRolloffMode.Logarithmic;
								SoundSource.loop = true;
								SoundSource.clip = SoundClip;
                                SoundSource.volume = 0.504f;
								SoundSource.Play (); 
								AudioBegin = true;
			
						}
				}
	}
	
	void Start () {
		//jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		//activity = jc.GetStatic.<AndroidJavaObject>("currentActivity"); 
	}
	
	void Update () {
		
	}
}
