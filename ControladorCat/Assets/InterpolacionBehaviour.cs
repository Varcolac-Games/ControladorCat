using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class InterpolacionBehaviour : PlayableBehaviour
{
    public Transform posA;
    public Transform posB;
    public Transform objeto;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        double time = playable.GetTime();
        double duration = playable.GetDuration();
        float t = (float)(time / duration);

        objeto.position = Vector3.Lerp(posA.position, posB.position, t);
    }
}
