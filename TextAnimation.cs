using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextAnimation : MonoBehaviour {

	public float letterPause = 0.5f;
	Text textComp;
	string message;

	// Use this for initialization

	void OnEnable(){

		textComp = GetComponent<Text> ();
		message = textComp.text;
		textComp.text = "";
		StartCoroutine(TypeText ());
	}

	IEnumerator TypeText(){
		foreach (char letter in message.ToCharArray()) {
			yield return new WaitForSeconds (letterPause);
			textComp.text += letter;


		}
	}
}
