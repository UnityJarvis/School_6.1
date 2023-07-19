using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using InuCom.SchoolVR.physics;

public class TutorialController : MonoBehaviour
{
    public Button iButton;
    bool iButtonToggleStatus;

    //public UiManager newCanvasManager;
    public List<GameObject> tutCanvas;
    public GameObject tutorialHandParent;
    public TutorialAnimPlayer tutorialAnimPlayer;

    private void Start()
    {
        iButton.onClick.AddListener(iButtonFunction);
        iButton.onClick.AddListener(() => TutorialCanvasSelector(ExperimentSelector.currentExp,iButtonToggleStatus));
    }

    void TutorialCanvasSelector(int currentExp, bool status)
    {
        if(status)
        {
            foreach(var tutCanvas in tutCanvas)
            {
                tutCanvas.SetActive(false);
            }
            tutCanvas[currentExp].SetActive(true);
            tutorialAnimPlayer.currentClip = currentExp + 1;
            tutorialHandParent.SetActive(true);
        }
        if (!status)
        {
            foreach (var tutCanvas in tutCanvas)
            {
                tutCanvas.SetActive(false);
            }
            tutorialHandParent.SetActive(false);

        }
    }

    public void iButtonFunction()
    {
        iButtonToggleStatus = !iButtonToggleStatus;
    }

    public void TutorialCanvasCallerForBackButtonBecauseButtonDoNotCallTwoParameterFunctionOnClick()
    {
        TutorialCanvasSelector(ExperimentSelector.currentExp, iButtonToggleStatus);
    }
    public void BackButtonOfMainBoardCanvasForTutorialTurnOffWhileChangingExperiments()
    {
        iButtonToggleStatus = false;
        TutorialCanvasSelector(ExperimentSelector.currentExp, iButtonToggleStatus);
    }
}
