using UnityEngine;
using System.Collections;

public class DialogueOperations : MonoBehaviour {

	void OnEnable(){
		AppController._isDialogue = true;
	}

	void OnDisable(){
		AppController._isDialogue = false;
	}
}
