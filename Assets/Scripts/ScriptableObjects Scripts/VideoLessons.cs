using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "VideoLessons", menuName = "ScriptableObjects/VideoLessons")]
public class VideoLessons : ScriptableObject
{
    public Button buttonPrefab;
    public List<VideoClip> videoList;
}

