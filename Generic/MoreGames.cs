using UnityEngine;
using System.Collections;

public class MoreGames : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		if (Utility.isClicked_2D(GetComponent<Collider2D>()) && !AppController._isDialogue)
        {
            //Utility.SoundPollInitCall();
            //GoogleAnalytics.GAActivity.Call("generateGAEvent", "UX", "touch", "MoreGames", null);
            Application.OpenURL("market://search?q=pub:Baca+Baca+Games");

        }
    }
}

