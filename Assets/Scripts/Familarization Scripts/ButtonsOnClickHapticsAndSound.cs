#region Copyright

/// <summary>
/// Copyright (c) iNucom. All rights reserved.
/// </summary>

#endregion

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles haptic feedback and sound for button clicks.
/// </summary>
public class ButtonsOnClickHapticsAndSound : MonoBehaviour
{
    /// <summary>
    /// Array of action buttons that trigger haptic feedback and sound.
    /// </summary>
    public Button[] actionButtons;

    /// <summary>
    /// AudioSource for playing button click sound.
    /// </summary>
    public AudioSource buttonAudioSource;

    /// <summary>
    /// Called when the script instance is being loaded.
    /// </summary>
    private void Start()
    {
        RegisterButtonClickListeners();
    }

    /// <summary>
    /// Registers click listeners for each action button.
    /// </summary>
    private void RegisterButtonClickListeners()
    {
        foreach (var button in actionButtons)
        {
            button.onClick.AddListener(() => Haptics.Instance.DoHaptics(BNG.ControllerHand.Right, 0.3f, 0.1f, 0.1f));
            button.onClick.AddListener(PlayButtonClickSound);
        }
    }

    /// <summary>
    /// Plays the button click sound.
    /// </summary>
    private void PlayButtonClickSound()
    {
        if (buttonAudioSource != null)
        {
            buttonAudioSource.Play();
        }
    }
}
