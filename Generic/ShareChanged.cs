using UnityEngine;
using System.Collections;
using System.IO;

public class ShareChanged : MonoBehaviour {

    public GameObject[] gm;
    public SpriteRenderer[] otherButtons;
	private bool isProcessing = false;
//	public GameObject bottomBar;
	void Update ()
	{
        if (Utility.isClicked_2D(GetComponent<Collider2D>()))
        {
            for (int i = 0; i < otherButtons.Length; i++)
            {
                otherButtons[i].enabled = false;
            }
            for (int i = 0; i < gm.Length; i++)
            {
                gm[i].SetActive(false);
            }
            Clicked();
        }
        if (!isProcessing)
        {
            
        }
	}
	
	
	public void Clicked()
	{
		if (!isProcessing) {
	//		GoogleAnalytics.GAActivity.Call ("generateGAEvent", "UX", "touch", "ShareScore", null);
//		AppController.ButtonsOff (otherButtons, false);
			//	GetComponent<Renderer>().enabled = false;
		//	bottomBar.SetActive (true);
			StartCoroutine (ShareScreenshot ());
		}
	}
	
	
	
	public IEnumerator ShareScreenshot()
	{

        Application.LoadLevel(2);
	//	AppController.ButtonsOff (otherButtons, false);
	//	GetComponent<Renderer>().enabled = false;
		isProcessing = true;
		//bottomBar.SetActive (true);
		// wait for graphics to render
		yield return new WaitForEndOfFrame();
		//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- PHOTO
		// create the texture
		Texture2D screenTexture = new Texture2D(Screen.width, Screen.height,TextureFormat.RGB24,true);
		
		// put buffer into texture
		screenTexture.ReadPixels(new Rect(0f, 0f, Screen.width, Screen.height),0,0);
		
		// apply
		screenTexture.Apply();
		//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- PHOTO
		
		byte[] dataToSave = screenTexture.EncodeToPNG();
		ShareChanged intent2;
		string destination = Path.Combine(Application.persistentDataPath,System.DateTime.Now.ToString("yyyy-MM-dd-HHmmss") + ".png");
        string shareBody = "https://play.google.com/store/apps/details?id=com.bb.princess.coloring.book";
		
		File.WriteAllBytes(destination, dataToSave);
		
		if(!Application.isEditor)
		{
			// block to open the file and share it ------------START
			AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
			AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
			intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
			intentObject.Call<AndroidJavaObject>("setType", "text/plain");
			intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), shareBody);
			//intentClass.GetStatic<string>("EXTRA_TYPE"),
			AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
			AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse","file://" + destination);
			//////////////////////////
			intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);
			
			//intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), "testo");
			//intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), "SUBJECT");
			intentObject.Call<AndroidJavaObject>("setType", "image/jpeg");
			
			AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
			
			// option one WITHOUT chooser:
			currentActivity.Call("startActivity", intentObject);
			
			// option two WITH chooser:
			//AndroidJavaObject jChooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, "YO BRO! WANNA SHARE?");
			//currentActivity.Call("startActivity", jChooser);
			
			// block to open the file and share it ------------END
//			bottomBar.SetActive (false);
		//	AppController.ButtonsOff (otherButtons, true);
	//		GetComponent<Renderer>().enabled = true;		}
	//	AppController.ButtonsOff (otherButtons, true);
	//	GetComponent<Renderer>().enabled = true;
	//	bottomBar.SetActive (false);
		isProcessing = false;
		GetComponent<GUITexture>().enabled = true;
	}
}
}