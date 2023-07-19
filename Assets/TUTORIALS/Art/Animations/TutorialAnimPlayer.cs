using UnityEngine;

public class TutorialAnimPlayer : MonoBehaviour
{
    public Animator animator;
    public AnimationClip[] Clips;
    [Range(0f, 4f)]
    public int currentClip = 0;
    private void Update()
    {
        animator.Play(Clips[currentClip].name);
    }
}
