using UnityEngine;
using System.Collections;

public class Back : MonoBehaviour {
	public GameObject BariABC;
	public GameObject abc;
	public GameObject next;
	public GameObject home;
	public GameObject back;

	// Update is called once per frame
	void Update () {

		if (Utility.isClicked_2D(GetComponent<Collider2D>())) {

			BariABC.transform.GetChild (AppController.level).gameObject.SetActive (false);
			if (AppController.level > 0 && AppController.level < 26) {
				AppController.level--;
				BariABC.transform.GetChild (AppController.level).gameObject.SetActive (true);	
			}
			else {
				abc.SetActive (true);
				BariABC.transform.GetChild (AppController.level).gameObject.SetActive (false);
				gameObject.SetActive (false);
				home.SetActive (false);
				next.SetActive (false);
			}
		}
	}
}
