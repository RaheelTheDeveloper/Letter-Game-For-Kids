using UnityEngine;
using System.Collections;

public class DragAnim : MonoBehaviour
{

    bool detected = false;
    private Vector2 offset;
    private Vector3 initialPosition,camInitailPos;
    private float animTime;
    private Vector3 initialScale;
    bool goToInitial = true;

    public float x = 1, y = 1;


    //public GameObject OtherObject;
   
    bool isDone = false;

   
   
  
	// Use this for initialization

    void Awake()
    {

        //camInitailPos = OtherObject.transform.position;
        initialPosition = transform.position;
        initialScale = transform.localScale;
        isDone = false;
        goToInitial = true;
       
    }



    // Update is called once per frame
    void Update()
    {
        GetComponent<BoxCollider2D>().offset = new Vector2(initialPosition.x - transform.position.x, initialPosition.y - transform.position.y);
        if (!AppController.isDialogue && Utility.isClicked_2D(GetComponent<Collider2D>()) && !isDone)
        {
            Utility.SoundPollInitCall();
            animTime = 0;
            transform.localScale = new Vector3(x, y, 1);
            offset = new Vector2(transform.position.x - Utility.getPositionVector2().x, transform.position.y - Utility.getPositionVector2().y);
            detected = true;                   
        }
        if (detected)
        {
            //animTime += 0.02f;

            transform.position = new Vector3(Mathf.Clamp(Utility.getPositionVector2().x + offset.x, 0f, 2f), Mathf.Clamp(Utility.getPositionVector2().y + offset.y, 2.05f, 4.35f), transform.position.z);//(Utility.getPositionVector2().x + offset.x, Utility.getPositionVector2().y + offset.y, transform.position.z);
            //transform.position = new Vector3(Mathf.Lerp(transform.position.x, 5, animTime), Mathf.Lerp(transform.position.y, 5, animTime), transform.position.z);
           
            //graging
            
            if ((Utility.getTouched_Phase2D(0) == TouchPhase.Ended || Utility.getTouched_Phase2D(0) == TouchPhase.Canceled))
            {
                detected = false;
                transform.localScale = initialScale;
                //if (GetComponent<Collider2D>().bounds.Intersects(OtherObject.GetComponent<Collider2D>().bounds))
                //{                                    
                //    goToInitial = false;
                //    isDone = true;                   
                //}                              
            }
        }
        //to move back to initial
        if (!detected && animTime < 1 && goToInitial)
        {
            animTime += 0.05f;
            if(animTime>1)
            {
              //reached Orignal Position
            }
            //transform.position = new Vector3(Mathf.Lerp(transform.position.x, initialPosition.x, animTime), Mathf.Lerp(transform.position.y, initialPosition.y, animTime), transform.position.z);
        }

    }


}

