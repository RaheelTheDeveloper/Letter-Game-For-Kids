using UnityEngine;
using System.Collections;

public class LevelChange : MonoBehaviour {

    public int LevelNumber = 1;
    public bool isMainMenu, isSelction, isSelction1, copyDesign;
    public bool gallery;
	// Use this for initialization
	void Start () {
        TerminateScene.isRatus = false;
	}
    bool detected;
	// Update is called once per frame
    void Update()
    {
		if (Utility.isClicked_2D(GetComponent<Collider2D>()) && !AppController._isDialogue)
            {
                detected = true;
                transform.localScale = new Vector3(transform.localScale.x + 0.3f, transform.localScale.y + 0.3f, transform.localScale.z);
            }

            if (detected && Utility.getTouched_Phase2D(0) == TouchPhase.Ended)
            {
                detected = false;
                transform.localScale = new Vector3(transform.localScale.x - 0.3f, transform.localScale.y - 0.3f, transform.localScale.z);
                
                Invoke("changeLevel", 0.01f);
            }
    }

    public void changeLevel()
    {
        Application.LoadLevel(LevelNumber);
        
    }

 
    
}
