using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class VideoPlayerSeekBar : MonoBehaviour
{
    public VideoPlayer vp;
    public Slider seekSlider;

    public void ChangeMaxSliderValue(VideoPlayer videoPlayer)
    {
        seekSlider.maxValue = (float)videoPlayer.clip.length;
    }
    public void OnValueChange_UpdateVideoPlayback()
    {
        vp.time = seekSlider.value;
    }
}
