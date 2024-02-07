using UnityEngine;
using UnityEngine.Video;

/// <summary>
/// Controls the playback of a video using a VideoPlayer component.
/// </summary>
public class VideoPlayerAudio : MonoBehaviour
{
    /// <summary>
    /// The VideoPlayer component responsible for video playback.
    /// </summary>
    public VideoPlayer videoPlayer;

    /// <summary>
    /// Plays the video using the attached VideoPlayer component.
    /// </summary>
    public void PlayVideo()
    {
        videoPlayer.Play();
    }
}
