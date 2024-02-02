using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;


[TrackColor(1, 0, 1)]
[TrackBindingType(typeof(Material))]
[TrackClipType(typeof(XrPlayerClip))]
public class XrPlayerTrack : TrackAsset
{
    //public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    //{
    //    return ScriptPlayable<XrPlayerTrackMixer>.Create(graph, inputCount);
    //}
}
