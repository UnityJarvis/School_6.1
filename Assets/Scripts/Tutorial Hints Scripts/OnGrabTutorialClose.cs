using BNG;
using UnityEngine;

/// <summary>
/// Closes the tutorial when a grabbable object is held by either the left or right hand.
/// </summary>
public class OnGrabTutorialClose : MonoBehaviour
{
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
