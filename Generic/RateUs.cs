using UnityEngine;
using System.Collections;

public class RateUs : MonoBehaviour
{
    public GameObject dialog;
    public bool isRateUsDialog = false;
    public string GameId = "";///eg com.icaw.newBornBaby
    // Use this for initialization
    void Start()
    {
        if (!PlayerPrefs.HasKey("RateUs"))
        {
            PlayerPrefs.SetInt("RateUs", 0);
            PlayerPrefs.Save();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!AppController.isDialogue)
        {
            if (Utility.isClicked_2D(GetComponent<Collider2D>()))
            {
                if (isRateUsDialog)
                {
      //             Log.LogSetDone(Log.isRateUs);
                    //Utility.SoundPollInitCall();
                    PlayerPrefs.SetInt("RateUs", 1);
                    PlayerPrefs.Save();
//                    GoogleAnalytics.GAActivity.Call("generateGAEvent", "UX", "touch", "RateUsDialogue", null);
                    Application.OpenURL("market://details?id="+GameId);
                    TerminateScene.isRatus = false;
                    dialog.SetActive(false);
                    //Application.Quit();
                }
                else if (!isRateUsDialog && !TerminateScene.isRatus)
                {
 //                  Log.LogSetDone(Log.isRateUs);
                    //Utility.SoundPollInitCall();
                    PlayerPrefs.SetInt("RateUs", 1);
                    PlayerPrefs.Save();
          //          GoogleAnalytics.GAActivity.Call("generateGAEvent", "UX", "touch", "RateUs", null);
                    Application.OpenURL("market://details?id=" + GameId);
                    dialog.SetActive(false);
                }
            }
           

            }
        }
    }

