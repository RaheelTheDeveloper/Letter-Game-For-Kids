using UnityEngine;
using System.Collections;

public class AppController : MonoBehaviour
{

	public static void ButtonsOff(GameObject[] offButton , bool trueOrFalse)
	{
		for (int a=0; a<offButton.Length; a++) {
			offButton[a].SetActive(trueOrFalse);
			
		}
	}
	
	
	public static void CollidersOff(GameObject[] offCollider , bool trueOrFalse)
	{
		for (int a=0; a<offCollider.Length; a++) {
			offCollider[a].GetComponent<Collider2D>().enabled = trueOrFalse;
		}
	}
		
	public static int hintNum0 =-1,hintNum1 =-1,hintNum2 =-1;
    public static int dress0 = -1, dress1 = -1, dress2 = -1;
    public static bool secondWork = false;
    public static bool isMusic = true;
    public static bool isSound = true;
   
    public static bool chartBoostShow = false;
    public static bool chartBoostMainMenu = false;
    public static bool chartBoost = false;
	public static bool isScroller  = false;
	public static int level; //My Variable
	public static bool _isDialogue  = false;
	public static bool isCamPic=false;
	public static bool isDialogue  = false;
	public static bool showPurchaseDialogue  = false;
	
	public static int isPurchased  = 0;
	
	public static int gamePlayed  = 1;
	public static int toPlay  = 1;
	
	public static bool isEating = true;
	
    
    public static int alreadyRated = 0;

    public static float getMWidth(float pWidth )  {
		float w_  = ((pWidth * 100f) / 720f);
		return ((w_ /100.00f) *Screen.width);
	}
	
	public static float getMHeight(float pHeight )  {
		float h_  = ((pHeight * 100f) /1280f);
		return ((h_ /100.0f) * Screen.height);
	}
	
	public static float getRWidth(float pWidth ) {
		float w_  = ((pWidth * 100f) / Screen.width);
		return ((w_ /100.0f) * 720f);
		
	}
	
	public static float getRHeight(float pHeight ) {
		float h_  = ((pHeight * 100f) / Screen.height);
		return ((h_ /100.0f) * 1280f);
	}
}
