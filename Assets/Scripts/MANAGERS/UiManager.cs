using UnityEngine;
using UnityEngine.UI;
using Inucom.SchoolVR.UI;
using InuCom.SchoolVR.physics;
using InuCom.SchoolVR.UI.Videos;
using UnityEngine.Video;

public class UiManager : MonoBehaviour
{
    [Header("Canvas UI")]
    public GameObject boardUI;
    public Transform[] contextt;
    public VideoPlayer videoPlayer;
    public VideoLessons[] videoLessons;

    [Space(20)]
    [Header("Canvas Board Toggle")]
    public Button boardButton;
    public Vector3 boardInitPos;
    public Vector3 bigBoardScale;
    public Vector3 smallBoardScale;
    public Transform leftHandPos, worldCanvasHolderPos, canvasUIParent;
    bool screenBoolPos;




    //--------------------------------------------------------------------------------------
    public GameObject[] panels;

    //--------------------------------------------------------------------------------------




    private void Start()
    {
        CanvasSwitcher.togglerer = true;                //Set Position of board to wall
        boardButton.onClick.AddListener(CanvasSwitcher.ScreenPosToggle);
        for(int i = 0; i < contextt.Length; i++)
        {
            VideoPanelButtonsInstantiator.InstantiateButton(videoLessons[i], contextt[i],videoPlayer); // Instantiating video buttons
        }
    }
    private void Update()
    {
        screenBoolPos = CanvasSwitcher.togglerer;
        CanvasSwitcher.ScreenTransition(boardInitPos, bigBoardScale, smallBoardScale, leftHandPos, worldCanvasHolderPos, canvasUIParent, screenBoolPos);
    } 

    public void currentExperiment(int experimentNumber)
    {
        ExperimentSelector.currentExp = experimentNumber;
    }

}
