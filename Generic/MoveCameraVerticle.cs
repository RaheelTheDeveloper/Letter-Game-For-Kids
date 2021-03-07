using UnityEngine;
using System.Collections;

public class MoveCameraVerticle : MonoBehaviour {
	//
	// VARIABLES
	//
	public float panSpeed = 1.0f; // Speed of the camera when being panned
    
	public float top,bottom;
    public float left, right;
	private Vector3 mouseOrigin; // Position of cursor when mouse dragging starts
	private bool isPanning; // Is the camera being panned?



    public void changeAxis()
    {
        // float xposition = 6.3936f, yposition = 3.6f;

        // top = (top * _rotation.transform.localScale.y) + (yposition);
        //bottom = (bottom * _rotation.transform.localScale.y) - (yposition);
     //   left = 0;// ArrayInterChnging.Calculateposition(0, 0).x + 6.4094591f;
      //  right = ((ArrayInterChnging.col * 177) - 1280) / 100f;
        // Debug.Log("changeAxis :  right  " + right + "   top " + top + "  size  " + _rotation.transform.localScale);

    }


    void Start()
    {
        changeAxis();
       
    }
	void Update ()
	{
		
		// Get the right mouse button
        if (Utility.isTouchedDown() && !AppController.isDialogue )
        {
            // Get mouse origin
            mouseOrigin = Utility.getPositionVector3(0);
            isPanning = true;
        }
		// Get the middle mouse button
		
		// Disable movements on button release
		if (!Utility.isTouched()) isPanning=false;
		
		// Move the camera on it's XY plane
        if (isPanning)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Utility.getPositionVector3(1) - mouseOrigin);
            Vector3 move = new Vector3();

            if (transform.position.x >= left && transform.position.x <= right)
            {
                move = -new Vector3(pos.x * panSpeed, 0, 0);
                if (transform.position.x + move.x > right)
                {
                    move.x = right - transform.position.x;
                }
                if (transform.position.x + move.x < left)
                {
                    move.x = left - transform.position.x;
                }
                transform.Translate(move, Space.Self);
            }
            //            Debug.Log(transform);            
        }
	}
}
