using UnityEngine;
using System.Collections;

public class SoundPoolInit : MonoBehaviour {
	
	AndroidJavaObject testobj ;
	AndroidJavaObject playerActivityContext ;
	
	public static AndroidJavaObject activity ;
	
	void Start () {
		AndroidJavaObject actClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
 		playerActivityContext =  actClass.GetStatic<AndroidJavaObject>("currentActivity");
		activity = new AndroidJavaObject("com.icaw.soundpool.SoundPoool");
		activity.Call("initSound", playerActivityContext);
	}


	// Update is called once per frame
	void Update () {
	
	}
}
