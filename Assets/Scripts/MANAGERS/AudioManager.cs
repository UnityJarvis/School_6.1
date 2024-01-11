using UnityEngine;
using UnityEngine.UI;
using InuCom.SchoolVR.Audio;

public class AudioManager : MonoBehaviour
{
    public Button boardSwitchButton;
    public AudioClipsHolder audioClipsHolder;
    public AudioSource audioSource;
    public ControllerInteractionHaptics csh;

    public Button[] allHierarchyButtons;

    private void Start()
    {
        allHierarchyButtons = FindObjectsOfType<Button>(true);
        boardSwitchButton.onClick.AddListener(() => UiSounds.ClickSound(audioSource, audioClipsHolder.audioClips[0]));

        foreach (var btn in allHierarchyButtons)
        {
            btn.onClick.AddListener(() => UiSounds.ClickSound(audioSource, audioClipsHolder.audioClips[0]));
            btn.onClick.AddListener(() => csh.PerformHaptics(BNG.ControllerHand.Right));
        }
    }
}
