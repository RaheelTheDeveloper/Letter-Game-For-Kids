#region Documentation

// Version # [1.0.1]
// CREATED BY = zulfiqar younus
// CREATED DATE= 11/30/2015
// FUNCTIONALITY: 
//      Terminate (Auto terminate , Active button on all work done , Show dialog on termination ) with animation
//      Multirez
//      Escape 
//      DialogBoxes on escape
// INTIGRATION : 
//      step 1 : Put "TerminateSceneEditor" script in "Editor" folder in Assets.
//      step 2 : Put "TerminateScene" script in script folder
//      step 3 : Drage "TerminateScene" script into the scene and put it on empty game object;
//      step 4 : Set values from inspector according to requirment.
//      step 5 : Give refrence of "TerminateScene" to the script where you want to call it
//      step 6 : Call "Terminate" funtion to terminate scene.
//               // Creat public GameObject to get the script
//               public GameObject terminate;
//               // Call it where scene termination is reqired
//               terminate.GetComponent<TerminateScene>().Terminate();

#endregion

using UnityEngine;
using System.Collections;

public class TerminateScene : MonoBehaviour
{
    static TerminateScene term;

    #region Variables
    public enum TerminateMethod { AutoTerminate, DilogBox, ActiveButton };

    public TerminateMethod TerminationMethod;

    #region Scene Switching Input Option 
    public enum SceneSwichingInput { sceneName, sceneNumber };
    public SceneSwichingInput SceneSwichingInputMethod;
    public int sceneNumber;
    public string SceneName;
    #endregion


    #region Escape Variables

    public enum Gametype { Horrizontal, vertical };
    public Gametype GameType;

    public bool isEscapeAllow = true;
    public bool isMainMenu = false;
    public GameObject rateUsDialog;
    public GameObject quitdialog;

    public bool showDialogOnEscape;
    public GameObject EscapeDialog;

    public int OnEscapeGoToLevel = 1;

    public static bool isRatus = false;
    #region Escape Animation variable
        public AnimationType EscapeDilogBoxAnimationType;
        public AnimationBase EsccapeAnimationBaseOn;
        public Vector3 DlgStartPosition, DlgEndPosition;
        public Vector3 DlgStartScale, DlgEndScale;
        bool DlgStartAnim = false;
        float DlganimTime;
    #endregion

    #endregion

    public GameObject dialogBox;


    public GameObject button;

    public float ActivationTime = 1.5f;

    #region variable Animation

    public enum AnimationType { Defualt, Customize };
    public AnimationType animationType;

    public enum AnimationBase { position, scale, positionAndScale };

    public AnimationBase animationBaseOn;
    float animTime;

    public Vector3 startPosition, EndPosition;
    public Vector3 startScale, EndScale;

    bool startAnim = false;

    #endregion


  

    #endregion

    void Start()
    {
       
        if (button)
        {
            button.SetActive(false);
        }
        if (dialogBox)
        {
            dialogBox.SetActive(false);
        }
        if (EscapeDialog)
        {
            EscapeDialog.SetActive(false);
        }
        animTime = 0;
        startAnim = false;

        DlgStartAnim = false;
        DlganimTime = 0;
    }

    void Update()
    {
        #region dialog and button animation code
        if (startAnim)
        {
            animTime += 0.05f;
            if (animTime > 1)
            {
                //reached Orignal Position
                startAnim = false;
            }
            if (TerminationMethod == TerminateMethod.DilogBox)
            {
                if (AnimationBase.position == animationBaseOn || AnimationBase.positionAndScale == animationBaseOn)
                {
					dialogBox.transform.position = new Vector3(Mathf.Lerp(startPosition.x, EndPosition.x, animTime), Mathf.Lerp(startPosition.y, EndPosition.y, animTime), dialogBox.transform.position.z);
                }
                if (AnimationBase.scale == animationBaseOn || AnimationBase.positionAndScale == animationBaseOn)
                {
                    dialogBox.transform.localScale = new Vector3(Mathf.Lerp(startScale.x, EndScale.x, animTime), Mathf.Lerp(startScale.y, EndScale.y, animTime), transform.localScale.z);
                }
            }
            else if (TerminationMethod == TerminateMethod.ActiveButton)
            {
                if (AnimationBase.position == animationBaseOn || AnimationBase.positionAndScale == animationBaseOn)
                {
					button.transform.position = new Vector3(Mathf.Lerp(startPosition.x, EndPosition.x, animTime), Mathf.Lerp(startPosition.y, EndPosition.y, animTime), dialogBox.transform.position.z);
                }
                if (AnimationBase.scale == animationBaseOn || AnimationBase.positionAndScale == animationBaseOn)
                {
                    button.transform.localScale = new Vector3(Mathf.Lerp(startScale.x, EndScale.x, animTime), Mathf.Lerp(startScale.y, EndScale.y, animTime), transform.localScale.z);
                }
            }

        }
        #endregion


        #region Escape dialog and button animation code
        if (DlgStartAnim)
        {
            DlganimTime += 0.05f;
            if (DlganimTime > 1)
            {
                //reached Orignal Position
                DlgStartAnim = false;
            }
            if (showDialogOnEscape || isMainMenu)
            {
                if (AnimationBase.position == EsccapeAnimationBaseOn || AnimationBase.positionAndScale == EsccapeAnimationBaseOn)
                {
                    EscapeDialog.transform.position = new Vector3(Mathf.Lerp(DlgStartPosition.x, DlgEndPosition.x, DlganimTime), Mathf.Lerp(DlgStartPosition.y, DlgEndPosition.y, DlganimTime), transform.position.z);
                }
                if (AnimationBase.scale == EsccapeAnimationBaseOn || AnimationBase.positionAndScale == EsccapeAnimationBaseOn)
                {
                    EscapeDialog.transform.localScale = new Vector3(Mathf.Lerp(DlgStartScale.x, DlgEndScale.x, DlganimTime), Mathf.Lerp(DlgStartScale.y, DlgEndScale.y, DlganimTime), transform.localScale.z);
                }
            }            
        }
        #endregion

        #region EscapeScriptWork
        if (!AppController.isDialogue)
        {
            if (isEscapeAllow)
            {
                EscapeButton();
              
            }
        }
        #endregion

    }


    public void Terminate()
    {
        if (TerminationMethod == TerminateMethod.AutoTerminate)
        {
            Invoke("autoChngeLevel", ActivationTime);
        }
        else if (TerminationMethod == TerminateMethod.ActiveButton)
        {
            Invoke("ActiveButton", ActivationTime);
        }
        else if (TerminationMethod == TerminateMethod.DilogBox)
        {
            Invoke("ActiveDialog", ActivationTime);
        }
    }

    public static void TerminateStatic()
    {
        term.Terminate();
    }

    #region private funtions
    void autoChngeLevel()
    {
       
        //autofade Change level
        if (SceneSwichingInputMethod == SceneSwichingInput.sceneNumber)
        {
            Application.LoadLevel(sceneNumber);
        }
        else
        {
            Application.LoadLevel(SceneName);            
        }
    }

    void ActiveDialog()
    {
        
        if (!dialogBox.activeInHierarchy)
        {
            if (AnimationType.Defualt == animationType)
            {
                animationBaseOn = AnimationBase.scale;
                dialogBox.transform.localScale = new Vector3(0, 0, 0);
                startScale = new Vector3(0, 0, 0);
                EndScale = new Vector3(1, 1, 1);
            }
            else
            {
                if (animationBaseOn == AnimationBase.scale || animationBaseOn == AnimationBase.positionAndScale)
                {
                    dialogBox.transform.localScale = startScale;
                }
                if (animationBaseOn == AnimationBase.position || animationBaseOn == AnimationBase.positionAndScale)
                {
                    dialogBox.transform.position = startPosition;
                }
            }
            dialogBox.SetActive(true);
            startAnim = true;
            animTime = 0;
        }
    }

    void ActiveButton()
    {
        if (!button.activeInHierarchy)
        {
            if (AnimationType.Defualt == animationType)
            {
                animationBaseOn = AnimationBase.scale;
                button.transform.localScale = new Vector3(0, 0, 0);
                startScale = new Vector3(0, 0, 0);
                EndScale = new Vector3(1, 1, 1);
            }
            else
            {
                if (animationBaseOn == AnimationBase.scale || animationBaseOn == AnimationBase.positionAndScale)
                {
                    button.transform.localScale = startScale;
                }
                if (animationBaseOn == AnimationBase.position || animationBaseOn == AnimationBase.positionAndScale)
                {
                    button.transform.position = startPosition;
                }
            }
            button.SetActive(true);
            startAnim = true;
            animTime = 0;
        }
    }

    void EscapeButton()
    {

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isMainMenu)
            {
                showDialogOnEscape = true;
                isRatus = !isRatus;
                if (PlayerPrefs.GetInt("RateUs") == 0)
                {
                    EscapeDialog = rateUsDialog;
                    EscapeActiveDialog(rateUsDialog);
                }
                else
                {
                    EscapeDialog = quitdialog;
                    EscapeActiveDialog(quitdialog);
                }
            }
            else
            {

                if (showDialogOnEscape)
                {
                    EscapeActiveDialog(EscapeDialog);// EscapeDialog.SetActive(!EscapeDialog.activeInHierarchy);
                }
                else
                {
                    Application.LoadLevel(OnEscapeGoToLevel);

                }
            }
        }
    }

    void EscapeActiveDialog(GameObject EscDilog )
    {
        if (showDialogOnEscape || isMainMenu)
        {
            if (!EscDilog.activeInHierarchy)
            {
                if (AnimationType.Defualt == EscapeDilogBoxAnimationType)
                {
                    EsccapeAnimationBaseOn = AnimationBase.scale;
                    EscDilog.transform.localScale = new Vector3(0, 0, 0);
                    DlgStartScale = new Vector3(0, 0, 0);
                    DlgEndScale = new Vector3(1, 1, 1);
                }
                else
                {
                    if (EsccapeAnimationBaseOn == AnimationBase.scale || EsccapeAnimationBaseOn == AnimationBase.positionAndScale)
                    {
                        EscDilog.transform.localScale = DlgStartScale;
                    }
                    if (EsccapeAnimationBaseOn == AnimationBase.position || EsccapeAnimationBaseOn == AnimationBase.positionAndScale)
                    {
                        EscDilog.transform.position = DlgStartPosition;
                    }
                }
                EscDilog.SetActive(true);
                DlgStartAnim = true;
                DlganimTime = 0;                
            }
            else
            {
                EscDilog.SetActive(false);
                DlgStartAnim = false;
                DlganimTime = 12;              
            }
        }
    }



    #endregion

  

    // Use this for initialization


    void Awake()
    {
        //PlayerPrefs.DeleteAll();
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        term = GetComponent<TerminateScene>();
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        if (GameType == Gametype.Horrizontal)
        {
            Camera.main.aspect = 16.0f / 9.0f;
        }
        else
        {
            Camera.main.aspect = 9.0f / 16.0f;
        }
    }



}