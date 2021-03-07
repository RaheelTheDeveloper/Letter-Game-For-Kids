using UnityEngine;
using System.Collections;

public class QuitDial : MonoBehaviour {

	public GameObject dial;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Utility.isClicked_2D(GetComponent<Collider2D>())) {
			dial.SetActive (false);
		}
	}
}
