using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class LetterToBePlayed : MonoBehaviour {

	public string characters;
	bool hide = true;
	public GameObject next;
	public GameObject back;
	public GameObject home;
	Animator anim;
	public Text characterText;
	AudioSource audioPlay;
	public GameObject letters;

	public AudioClip sound1;
	public AudioClip sound2;


	void OnEnable()
	{
		audioPlay = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {

		if (Utility.isClicked_2D (GetComponent<Collider2D> ())) {



			if (hide) {
				
//				gameObject.GetComponent<SpriteRenderer> ().enabled = false;

				StartCoroutine (PlayAudioClip());
				gameObject.GetComponent<Collider2D> ().enabled = false;
	
				anim = GetComponent<Animator> ();
				anim.speed = 0;

				next.SetActive (false);
				back.SetActive (false);
				home.SetActive (false);
				letters.SetActive(true);

				StartCoroutine (WaitUnhide());
			}

			GameObject g = Instantiate (Resources.Load (characters) as GameObject);
			Destroy (g, 11f);
		}
	}

	IEnumerator WaitUnhide(){
		yield return new WaitForSeconds (11f);
		//		gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		gameObject.GetComponent<Collider2D> ().enabled = true;
		anim.speed = 1;
		letters.SetActive(false);

		next.SetActive (true);
		back.SetActive (true);
		home.SetActive (true);


	}

	IEnumerator PlayAudioClip(){

//		audioPlay = gameObject.GetComponent<AudioSource>();
//		audioPlay.Play ();
		if (AppController.isSound) {
			audioPlay.clip = sound1;
			audioPlay.Play ();

			while (audioPlay.isPlaying) {
				yield return null;
			}

			yield return new WaitForSeconds (3.0f);

			audioPlay.clip = sound2;
			audioPlay.Play ();
		}

	}
}
