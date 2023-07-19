using BNG;
using UnityEngine;

public class OnGrabTutorialClose : MonoBehaviour
{
    public Grabber leftHand, rightHand;
    public TutorialController tC;
    private void Update()
    {
        if(leftHand.HeldGrabbable != null || rightHand.HeldGrabbable != null)
        {
            tC.BackButtonOfMainBoardCanvasForTutorialTurnOffWhileChangingExperiments();
        }
    }
}
