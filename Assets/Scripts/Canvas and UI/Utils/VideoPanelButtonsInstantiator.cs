using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace InuCom.SchoolVR.UI.Videos
{
    /// <summary>
    /// Handles the instantiation and functionality of buttons in a video panel.
    /// </summary>
    internal class VideoPanelButtonsInstantiator : MonoBehaviour
    {
        /// <summary>
        /// Instantiates buttons for each video in the provided VideoLessons scriptable object.
        /// </summary>
        /// <param name="videoScriptableObj">The VideoLessons scriptable object containing video information.</param>
        /// <param name="scrollViewContext">The transform of the scroll view's content area.</param>
        /// <param name="videoPlayer">The VideoPlayer component for playing videos.</param>
        /// <param name="vp">The VideoPlayerAudio component for audio control.</param>
        /// <param name="vpb">The VideoPlayerSeekBar component for controlling video playback progress.</param>
        internal static void InstantiateButton(VideoLessons videoScriptableObj, Transform scrollViewContext, VideoPlayer videoPlayer, VideoPlayerSeekBar vpb)
        {
            for (int i = 0; i < videoScriptableObj.videoList.Count; i++)
            {
                var videoButton = Instantiate(videoScriptableObj.buttonPrefab, scrollViewContext);
                Text text = videoButton.GetComponentInChildren<Text>();
                text.text = (i + 1).ToString() + " - " + videoScriptableObj.videoList[i].name;
                videoButton.onClick.AddListener(() => { OnButtonPress(videoScriptableObj, videoPlayer, text.text); });
            }
        }

        /// <summary>
        /// Handles the functionality when a video button is pressed.
        /// </summary>
        /// <param name="videoScriptableObj">The VideoLessons scriptable object containing video information.</param>
        /// <param name="videoPlayer">The VideoPlayer component for playing videos.</param>
        /// <param name="videoName">The name of the selected video.</param>
        /// <param name="vp">The VideoPlayerAudio component for audio control.</param>
        /// <param name="vpb">The VideoPlayerSeekBar component for controlling video playback progress.</param>
        internal static void OnButtonPress(VideoLessons videoScriptableObj, VideoPlayer videoPlayer, string videoName)
        {
            int videoIndex = int.Parse(videoName.Substring(0, videoName.IndexOf("-")).Replace(" ", ""));
            videoPlayer.clip = videoScriptableObj.videoList[videoIndex - 1];
            PlayVideo(videoPlayer);
            //vpb.ChangeMaxSliderValue(videoPlayer);
        }
        internal static void PlayVideo(VideoPlayer videoPlayer)
        {
            videoPlayer.Play();
        }
    }
}
