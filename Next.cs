using UnityEngine;
using System.Collections;

public class Next : MonoBehaviour {

	public GameObject BariABC;
	public GameObject ABC;
	public GameObject back;
	public GameObject home;

	// Update is called once per frame
	void Update () {

		if (Utility.isClicked_2D(GetComponent<Collider2D>())) {
			//Debug.Log ("clicked");

			BariABC.transform.GetChild (AppController.level).gameObject.SetActive (false);
			if (AppController.level < 25) {
				AppController.level++;
				//Debug.Log (AppController.level);
				BariABC.transform.GetChild (AppController.level).gameObject.SetActive (true);	
			}
			else {
				BariABC.transform.GetChild (AppController.level).gameObject.SetActive (false);
				gameObject.SetActive (false);
				home.SetActive (false);
				ABC.SetActive (true);
				back.SetActive (false);

			}
		}
	}
}
