#region
/// copyright (c) iNucom. All rights reserved.
#endregion

using UnityEngine;
using UnityEngine.UI;

public class ButtonsOnClickHapticsAndSound : MonoBehaviour
{
    public Button[] allButtons;
    public AudioSource audioSource;
    private void Start()
    {
        foreach (var button in allButtons) 
        {
            button.onClick.AddListener(() => Haptics.instance.doHaptics(BNG.ControllerHand.Right,0.3f,0.1f,0.1f));
            button.onClick.AddListener(PlayAudio);
        }
    }

    public void PlayAudio()
    {
        audioSource.Play();
    }
}