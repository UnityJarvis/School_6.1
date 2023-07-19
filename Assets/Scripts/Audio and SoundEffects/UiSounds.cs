using UnityEngine;

namespace InuCom.SchoolVR.Audio
{
    public class UiSounds
    {
        internal static void ClickSound(AudioSource audioSource, AudioClip audioClip)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}
