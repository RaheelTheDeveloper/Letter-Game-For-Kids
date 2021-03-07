using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {

    public Sprite onSprite, offSprite;
    SpriteRenderer sr;

    // Use this for initialization
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        if (!AppController.isSound)
        {
            sr.sprite = offSprite;
            GetComponent<AudioSource>().Stop();
        }

    }

    // Update is called once per frame
    void Update()
    {

		if (Utility.isClicked_2D(GetComponent<Collider2D>()) && !AppController._isDialogue)
        {
            if (AppController.isSound)
            {
                AppController.isSound = false;
                gameObject.GetComponent<SpriteRenderer>().sprite = offSprite;
            }
            else
            {
                AppController.isSound = true;
                gameObject.GetComponent<SpriteRenderer>().sprite = onSprite;
            }
        }
    }
}
