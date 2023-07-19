using UnityEngine;
using BNG;

public class ControllerInteractionHaptics : MonoBehaviour
{
    public InputBridge input;
    public float VibrateFrequency = 0.3f;
    public float VibrateAmplitude = 0.1f;
    public float VibrateDuration = 0.1f;

    void PerformHaptics(ControllerHand touchingHand)
    {
        if (input)
        {
            input.VibrateController(VibrateFrequency, VibrateAmplitude, VibrateDuration, touchingHand);
        }
    }

    private void Update()
    {
        if(input.RightTrigger>0)
        {
            PerformHaptics(ControllerHand.Right);
        }
    }
}
