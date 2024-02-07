using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections.Generic;

/// <summary>
/// ScriptableObject to hold a list of VideoClips and a ButtonPrefab for video lessons.
/// </summary>
[CreateAssetMenu(fileName = "VideoLessons", menuName = "ScriptableObjects/VideoLessons")]
public class VideoLessons : ScriptableObject
{
    /// <summary>
    /// Prefab for buttons associated with video lessons.
    /// </summary>
    public Button buttonPrefab;

    /// <summary>
    /// List of VideoClips representing video lessons.
    /// </summary>
    public List<VideoClip> videoList;
}
