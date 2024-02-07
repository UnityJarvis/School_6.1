using UnityEngine;

/// <summary>
/// Controls the animation playback for tutorials using an Animator.
/// </summary>
public class TutorialAnimPlayer : MonoBehaviour
{
    /// <summary>
    /// Reference to the Animator component.
    /// </summary>
    public Animator animator;

    /// <summary>
    /// Array of AnimationClips to be played.
    /// </summary>
    public AnimationClip[] Clips;

    /// <summary>
    /// Index of the current animation clip to be played.
    /// </summary>
    [Range(0f, 5f)]
    public int currentClip = 0;

    private void Update()
    {
        // Play the animation clip based on the currentClip index
        animator.Play(Clips[currentClip].name);
    }
}

