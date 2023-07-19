using UnityEngine;
using UnityEngine.UI;
using InuCom.SchoolVR.Audio;

public class AudioManager : MonoBehaviour
{
    public Button boardSwitchButton;
    public AudioClipsHolder audioClipsHolder;
    public AudioSource audioSource;

    [Space(10)]
    public Button[] experimentBtn;

    private void Start()
    {
        boardSwitchButton.onClick.AddListener(() => UiSounds.ClickSound(audioSource, audioClipsHolder.audioClips[0]));
        foreach (var item in experimentBtn)
        {
            item.onClick.AddListener(() => UiSounds.ClickSound(audioSource, audioClipsHolder.audioClips[1]));
        }
    }
}
