using UnityEngine;
using BNG;

/// <summary>
/// Manages controller haptics interaction.
/// </summary>
public class ControllerInteractionHaptics : MonoBehaviour
{
    /// <summary>
    /// Input bridge for controller input.
    /// </summary>
    public InputBridge input;

    /// <summary>
    /// Frequency of haptic vibrations.
    /// </summary>
    public float VibrateFrequency = 0.3f;

    /// <summary>
    /// Amplitude of haptic vibrations.
    /// </summary>
    public float VibrateAmplitude = 0.1f;

    /// <summary>
    /// Duration of haptic vibrations.
    /// </summary>
    public float VibrateDuration = 0.1f;

    /// <summary>
    /// Perform haptic feedback on the specified hand.
    /// </summary>
    /// <param name="touchingHand">The hand to perform haptics on.</param>
    public void PerformHaptics(ControllerHand touchingHand)
    {
        if (input)
        {
            input.VibrateController(VibrateFrequency, VibrateAmplitude, VibrateDuration, touchingHand);
        }
    }

}
