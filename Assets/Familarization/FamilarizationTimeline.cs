using UnityEngine;
using UnityEngine.Playables;

public class FamilarizationTimeline : MonoBehaviour
{
    PlayableDirector pb;
    void Start()
    {
        pb = transform.GetComponent<PlayableDirector>();
        pb.Play();
    }
}
