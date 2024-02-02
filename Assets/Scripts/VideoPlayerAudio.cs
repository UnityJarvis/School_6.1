using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerAudio : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public void PlayVideo()
    {
        videoPlayer.Play();
    }
}
