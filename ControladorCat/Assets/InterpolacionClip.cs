using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class InterpolacionClip : PlayableAsset
{
    public ExposedReference<Transform> objeto;
    public ExposedReference<Transform> posA;
    public ExposedReference<Transform> posB;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var behaviour = new InterpolacionBehaviour
        {
            objeto = objeto.Resolve(graph.GetResolver()),
            posA = posA.Resolve(graph.GetResolver()),
            posB = posB.Resolve(graph.GetResolver())
        };

        return ScriptPlayable<InterpolacionBehaviour>.Create(graph, behaviour);
    }
}
