using UnityEngine;
using System.Collections;

public class Gameplay : MonoBehaviour {

	public GameObject letterToShow;
	public GameObject ABC;
	public GameObject home;
	public GameObject back;
	public GameObject next;
	public int letterNumber;

	// Update is called once per frame
	void Update () {

		if (Utility.isClicked_2D (gameObject.GetComponent<Collider2D> ())) {
			letterToShow.SetActive (true);
			ABC.SetActive (false);
			home.SetActive (true);
			next.SetActive (true);
			back.SetActive (true);
			AppController.level = letterNumber;
		}
	}
}
