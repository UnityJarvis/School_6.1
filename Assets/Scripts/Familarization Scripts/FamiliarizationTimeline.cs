using UnityEngine;
using UnityEngine.Playables;

/// <summary>
/// Plays the familiarization timeline using a PlayableDirector.
/// </summary>
public class FamiliarizationTimeline : MonoBehaviour
{
    /// <summary>
    /// The PlayableDirector component responsible for controlling the timeline.
    /// </summary>
    private PlayableDirector playableDirector;

    /// <summary>
    /// Called when the script instance is being loaded.
    /// </summary>
    void Start()
    {
        InitializePlayableDirector();
        PlayTimeline();
    }

    /// <summary>
    /// Initializes the PlayableDirector component.
    /// </summary>
    private void InitializePlayableDirector()
    {
        playableDirector = GetComponent<PlayableDirector>();
        if (playableDirector == null)
        {
            Debug.LogError("PlayableDirector component not found on " + gameObject.name);
        }
    }

    /// <summary>
    /// Plays the familiarization timeline.
    /// </summary>
    private void PlayTimeline()
    {
        if (playableDirector != null)
        {
            playableDirector.Play();
        }
    }
}
