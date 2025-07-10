using UnityEngine;

[CreateAssetMenu(fileName = "HideAction", menuName = "WorldActions/Hide")]
public class HideActionSO : WorldActionSO
{
    public float duration = 5f;

    public override void Execute(GameObject performer, GameObject target)
    {
        Debug.Log("Hide");
        if (performer.TryGetComponent<HideHandler>(out var hider))
        {
            hider.StartHiding(duration);
        }
    }
}
