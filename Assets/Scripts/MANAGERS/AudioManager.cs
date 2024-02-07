using UnityEngine;
using UnityEngine.UI;
using InuCom.SchoolVR.Audio;

/// <summary>
/// Manages audio-related functionality in the application.
/// </summary>
public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// Button to switch the board.
    /// </summary>
    public Button boardSwitchButton;

    /// <summary>
    /// Holder for audio clips.
    /// </summary>
    public AudioClipsHolder audioClipsHolder;

    /// <summary>
    /// AudioSource to play audio clips.
    /// </summary>
    public AudioSource audioSource;

    /// <summary>
    /// Controller interaction haptics for providing feedback.
    /// </summary>
    public ControllerInteractionHaptics csh;

    /// <summary>
    /// All hierarchy buttons in the scene.
    /// </summary>
    private Button[] allHierarchyButtons;

    /// <summary>
    /// Called when the script instance is being loaded.
    /// </summary>
    private void Start()
    {
        // Find all buttons in the scene
        allHierarchyButtons = FindObjectsOfType<Button>(true);

        // Set up click listeners for the board switch button
        boardSwitchButton.onClick.AddListener(() => UiSounds.ClickSound(audioSource, audioClipsHolder.audioClips[0]));

        // Set up click listeners for all buttons in the hierarchy
        foreach (var btn in allHierarchyButtons)
        {
            btn.onClick.AddListener(() => UiSounds.ClickSound(audioSource, audioClipsHolder.audioClips[0]));
            btn.onClick.AddListener(() => csh.PerformHaptics(BNG.ControllerHand.Right));
        }
    }
}
