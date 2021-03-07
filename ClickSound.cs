using UnityEngine;
using System.Collections;

public class ClickSound : MonoBehaviour {

	AudioSource sound;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Utility.isClicked_2D (GetComponent<Collider2D> ())) {
			if (AppController.isSound) {
				sound = GetComponent<AudioSource> ();
				sound.Play ();	
			}

		}
	}
}
