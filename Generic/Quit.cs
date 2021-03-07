using UnityEngine;
using System.Collections;

public class Quit : MonoBehaviour {

    // Use this for initialization

    

	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        if (Utility.isClicked_2D(gameObject.GetComponent<Collider2D>()))
        {
            Debug.Log("dk");
            Application.Quit();
        }

	}
}
