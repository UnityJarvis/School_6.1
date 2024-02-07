using UnityEngine;

namespace InuCom.SchoolVR.Audio
{
    /// <summary>
    /// Provides utility functions for playing UI-related sounds.
    /// </summary>
    public class UiSounds
    {
        /// <summary>
        /// Plays a click sound using the specified AudioSource and AudioClip.
        /// </summary>
        /// <param name="audioSource">The AudioSource component to play the sound.</param>
        /// <param name="audioClip">The AudioClip to be played.</param>
        internal static void ClickSound(AudioSource audioSource, AudioClip audioClip)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}
