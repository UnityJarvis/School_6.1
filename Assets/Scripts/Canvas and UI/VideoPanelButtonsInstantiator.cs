using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace InuCom.SchoolVR.UI.Videos
{
    internal class VideoPanelButtonsInstantiator : MonoBehaviour
    {
        int index { get; set; }
        internal static void InstantiateButton(VideoLessons videoScriptableObj, Transform scrollView_Context, VideoPlayer videoPlayer)
        {
            for (int i = 0; i < videoScriptableObj.videoList.Count; i++)
            {
                var videobutton = Instantiate(videoScriptableObj.buttonPrefab, scrollView_Context);
                Text text = videobutton.GetComponentInChildren<Text>();
                //text.text = videoScriptableObj.videoList[i].clip.name;
                text.text = (i+1).ToString() + " - " + videoScriptableObj.videoList[i].name;
                videobutton.onClick.AddListener(() => { OnButtonPress(videoScriptableObj, videoPlayer,text.text); });
            }
        }

        internal static void OnButtonPress(VideoLessons videoScriptableObj, VideoPlayer videoPlayer ,string videoName)
        {
            //Debug.Log(videoName.Substring(0,videoName.IndexOf("-")).Replace(" ", ""));
            //string s = videoName.Substring(0, videoName.IndexOf("-")).Replace(" ", "");
            int x = int.Parse(videoName.Substring(0, videoName.IndexOf("-")).Replace(" ", ""));
            videoPlayer.clip = videoScriptableObj.videoList[x-1];
            //videoPlayer.clip = videoScriptableObj.videoList[i];
        }
    }
}