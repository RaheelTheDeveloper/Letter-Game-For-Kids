using UnityEngine;
using System.Collections;

public class Home : MonoBehaviour {
	public GameObject ABC;
	public GameObject prefab;
	public GameObject letterToBeOff;
	public GameObject BariABC;
	public GameObject back;
	public GameObject next;

	// Update is called once per frame
	void Update () {

		if (Utility.isClicked_2D (GetComponent<Collider2D> ())) {
			BariABC.transform.GetChild (AppController.level).gameObject.SetActive (false);
			back.SetActive (false);
			next.SetActive (false);
			ABC.SetActive (true);
//			prefab.SetActive (false);
			gameObject.SetActive (false);
//			letterToBeOff.SetActive (false);
		}
	}
}
