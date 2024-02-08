using UnityEngine;
using System.Collections.Generic;
using BNG;

/// <summary>
/// Controls the tutorial behavior, handling UI elements, animations, and canvas selection.
/// </summary>
public class TutorialController : MonoBehaviour
{
    /// <summary>
    /// Button to toggle the tutorial.
    /// </summary>
    public UnityEngine.UI.Button iButton;

    /// <summary>
    /// Toggle status of the iButton.
    /// </summary>
    private bool iButtonToggleStatus;

    /// <summary>
    /// List of tutorial canvases.
    /// </summary>
    public List<GameObject> tutCanvas;

    /// <summary>
    /// Parent object of the tutorial hand animation.
    /// </summary>
    public GameObject tutorialHandParent;

    /// <summary>
    /// Tutorial animation player.
    /// </summary>
    public TutorialAnimPlayer tutorialAnimPlayer;

    private void Start()
    {
        iButton.onClick.AddListener(iButtonFunction);
        iButton.onClick.AddListener(() => TutorialCanvasSelector(ExperimentSelector.CurrentExperimentIndex, iButtonToggleStatus));
    }

    /// <summary>
    /// Selects the appropriate tutorial canvas based on the current experiment and toggle status.
    /// </summary>
    /// <param name="currentExp">Current experiment index.</param>
    /// <param name="status">Toggle status of the iButton.</param>
    void TutorialCanvasSelector(int currentExp, bool status)
    {
        if (status)
        {
            foreach (var tutCanvas in tutCanvas)
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

    /// <summary>
    /// Toggles the status of the iButton.
    /// </summary>
    public void iButtonFunction()
    {
        iButtonToggleStatus = !iButtonToggleStatus;
    }

    /// <summary>
    /// Calls the tutorial canvas selector for the back button.
    /// </summary>
    public void TutorialCanvasCallerForBackButtonBecauseButtonDoNotCallTwoParameterFunctionOnClick()
    {
        TutorialCanvasSelector(ExperimentSelector.CurrentExperimentIndex, iButtonToggleStatus);
    }

    /// <summary>
    /// Turns off the tutorial canvas when changing experiments.
    /// </summary>
    public void BackButtonOfMainBoardCanvasForTutorialTurnOffWhileChangingExperiments()
    {
        iButtonToggleStatus = false;
        TutorialCanvasSelector(ExperimentSelector.CurrentExperimentIndex, iButtonToggleStatus);
    }



    /// <summary>
    /// Reference to the left hand grabber.
    /// </summary>
    public Grabber leftHand;

    /// <summary>
    /// Reference to the right hand grabber.
    /// </summary>
    public Grabber rightHand;

    /// <summary>
    /// Reference to the TutorialController.
    /// </summary>
    public TutorialController tC;

    private void Update()
    {
        // Check if either the left or right hand is holding a grabbable object
        if (leftHand.HeldGrabbable != null || rightHand.HeldGrabbable != null)
        {
            // Close the tutorial
            tC.BackButtonOfMainBoardCanvasForTutorialTurnOffWhileChangingExperiments();
        }
    }
}
