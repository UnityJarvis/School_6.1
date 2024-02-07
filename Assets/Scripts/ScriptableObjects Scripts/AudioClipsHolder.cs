using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ScriptableObject to hold a list of AudioClips.
/// </summary>
[CreateAssetMenu(fileName = "AudioClip", menuName = "ScriptableObjects/AudioClips")]
public class AudioClipsHolder : ScriptableObject
{
    /// <summary>
    /// List of AudioClips.
    /// </summary>
    public List<AudioClip> audioClips;
}
