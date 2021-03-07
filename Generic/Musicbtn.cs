using UnityEngine;
using System.Collections;

public class Musicbtn : MonoBehaviour {

    public Sprite onSprite, offSprite;
	SpriteRenderer sr;
	
	// Use this for initialization
	void Awake () {
		sr = GetComponent<SpriteRenderer>();
		if (!AppController.isMusic) {
			sr.sprite = offSprite;
            GetComponent<AudioSource>().Stop();
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Utility.isClicked_2D(GetComponent<Collider2D>()) && !AppController._isDialogue)
        {
            if (GetComponent<AudioSource>())
            {
                if (AppController.isMusic)
                {
                    AppController.isMusic = false;
                    GetComponent<AudioSource>().Stop();
                    gameObject.GetComponent<SpriteRenderer>().sprite = offSprite;
                }
                else
                {
                    AppController.isMusic = true;
                    GetComponent<AudioSource>().Play();
                    gameObject.GetComponent<SpriteRenderer>().sprite = onSprite;
                }
            }
        }
	}
}
