using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour {

	void Awake (){
		
		GameObject gameMusic   = GameObject.Find("GamePlayM");
		if(gameMusic){
			SoundInit.AudioBegin = false;
			Destroy(gameMusic);
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
