using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class XrPlayerClip : PlayableAsset
{
    public XrPlayerBehaviour XRB = new XrPlayerBehaviour();

    public ClipCaps clipCaps { get { return ClipCaps.None; } }

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var xrPlayable = ScriptPlayable<XrPlayerBehaviour>.Create(graph);

        XrPlayerBehaviour m_behaviour = xrPlayable.GetBehaviour();
        m_behaviour.playerInputs = XRB.playerInputs;
        return xrPlayable;
    }
}
