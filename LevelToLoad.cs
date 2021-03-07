using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelToLoad : MonoBehaviour {

	public int level;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Utility.isClicked_2D (GetComponent<Collider2D> ())) {
			SceneManager.LoadScene (level);
			
		}
	
	}
}
