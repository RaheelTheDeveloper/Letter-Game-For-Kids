using UnityEngine;
using System.Collections;

public class exitDialoge : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Utility.isClicked_2D (GetComponent<Collider2D> ())) {
			
			transform.parent.gameObject.SetActive (false);
		}
	}
}
