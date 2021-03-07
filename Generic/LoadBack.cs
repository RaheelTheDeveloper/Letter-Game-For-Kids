using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class LoadBack : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Utility.isClicked_2D(GetComponent<Collider2D>()))
        {
            Application.LoadLevel(2);
        }


	}
}
