using UnityEngine;
using System.Collections;

public class DialogAppear : MonoBehaviour {

    public bool gal;
    public GameObject gallery;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnEnable()
    {
        if (gal)
        {
            gallery.SetActive(true);
        }
		AppController._isDialogue = true;
    }
    void OnDisable()
    {
		AppController._isDialogue = false;
    }
}
