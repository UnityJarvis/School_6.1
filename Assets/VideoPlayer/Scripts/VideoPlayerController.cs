using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    private VideoPlayer vPlayer;
    private AudioSource vAudioSource;
    private bool vIsPlaying;
    private bool vIsMuted;
    private Slider vSlider;

    [SerializeField]
    private Button vPlayPause;
    [SerializeField]
    public Sprite pauseImage;
    private Sprite playImage;
    [SerializeField]
    private Button vStop;
    [SerializeField]
    private Button vMute;
    [SerializeField]
    private Sprite muteIcon;
    private Sprite volumeIcon;
    [SerializeField]
    private TextMeshProUGUI vTime;
    // public Button vNext;
    // public Button vPrev;

    private void Start()
    {
        vPlayer = GetComponent<VideoPlayer>();
        vAudioSource=GetComponent<AudioSource>();
        playImage=vPlayPause.GetComponent<Image>().sprite;
        volumeIcon=vMute.GetComponent<Image>().sprite;
        vSlider = this.transform.parent.transform.parent.GetComponentInChildren<Slider>();

        vPlayPause.onClick.AddListener(PlayPauseVideo);
        vMute.onClick.AddListener(MuteUnmute);
        vStop.onClick.AddListener(StopVideo);
        vSlider.onValueChanged.AddListener(Seek);
    }

    public void PlayPauseVideo()
    {
        if (vIsPlaying)
        {
            vPlayPause.GetComponent<Image>().sprite = playImage;
            vPlayer.Pause();
            vIsPlaying = false;
        }
        else
        {
            vPlayPause.GetComponent<Image>().sprite = pauseImage;
            vPlayer.Play();
            vIsPlaying = true;
        }
    }
    public void StopVideo()
    {
        vPlayPause.GetComponent<Image>().sprite = playImage;
        vPlayer.Stop();
        vSlider.value= 0;
        vIsPlaying = false;
       
        vTime.text = "00:00/00:00";
    }

    public void MuteUnmute()
    {
        vIsMuted = !vIsMuted;
        vAudioSource.mute = vIsMuted;
        if (vIsMuted) vMute.GetComponent<Image>().sprite = muteIcon;
        else vMute.GetComponent<Image>().sprite = volumeIcon;
    }

    public void Seek(float percentage)
    {
        percentage = Mathf.Clamp01(percentage);
        double seekTime = percentage * vPlayer.clip.length;
        vPlayer.time = seekTime;
        vSlider.value = (float)(seekTime / vPlayer.clip.length);
        if (!vIsPlaying)
        {
            vPlayer.Play();
            vIsPlaying = true;
            vPlayPause.GetComponent<Image>().sprite = pauseImage;
        }
    }
    public void VideoTime()
    {
        if (vIsPlaying)
        {
            float totalTime = (float)vPlayer.clip.length;
            float currentTime = (float)vPlayer.time;

            int totalMinutes = Mathf.FloorToInt(totalTime / 60);
            int totalSeconds = Mathf.FloorToInt(totalTime % 60);

            int currentMinutes = Mathf.FloorToInt(currentTime / 60);
            int currentSeconds = Mathf.FloorToInt(currentTime % 60);

            string formattedTime = string.Format("{0:00}:{1:00}/{2:00}:{3:00}", currentMinutes, currentSeconds, totalMinutes, totalSeconds);
            vTime.text = formattedTime;
            vSlider.value = currentTime / totalTime;
        }
    }

    private void Update()
    {
        VideoTime();
    }
}