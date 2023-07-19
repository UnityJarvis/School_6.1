using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="AudioClip",menuName ="ScriptableObjects/AudioClips")]
public class AudioClipsHolder : ScriptableObject
{
    public List<AudioClip> audioClips;
}
