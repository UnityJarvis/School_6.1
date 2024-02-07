using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

/// <summary>
/// Controls the seek bar functionality for a VideoPlayer component.
/// </summary>
public class VideoPlayerSeekBar : MonoBehaviour
{
    /// <summary>
    /// The VideoPlayer component associated with the seek bar.
    /// </summary>
    public VideoPlayer videoPlayer;

    /// <summary>
    /// The Slider UI element representing the seek bar.
    /// </summary>
    public Slider seekSlider;

    /// <summary>
    /// Changes the maximum value of the seek bar based on the video clip length.
    /// </summary>
    /// <param name="videoPlayer">The VideoPlayer component containing the video clip.</param>
    public void ChangeMaxSliderValue(VideoPlayer videoPlayer)
    {
        seekSlider.maxValue = (float)videoPlayer.clip.length;
    }

    /// <summary>
    /// Updates the video playback time based on the seek bar value.
    /// </summary>
    public void OnValueChange_UpdateVideoPlayback()
    {
        videoPlayer.time = seekSlider.value;
    }
}
