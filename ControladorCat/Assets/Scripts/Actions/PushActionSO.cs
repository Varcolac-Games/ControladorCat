using UnityEngine;

public struct PushActionData
{
    public GameObject performer;
    public string style;
    public float force;
    public Vector3 direction;
}

[CreateAssetMenu(fileName = "NewPushAction", menuName = "WorldActions/Push Action")]
public class PushActionSO : WorldActionSO
{
    public float force = 5f;
    public string pushStyle = "Zarpazo"; // Por ejemplo

    public override void Execute(GameObject performer, GameObject target)
    {
        if (target.TryGetComponent<IReactToPush>(out var reaction))
        {
            var data = new PushActionData
            {
                performer = performer,
                style = pushStyle,
                force = force,
                direction = (target.transform.position - performer.transform.position).normalized
            };

            reaction.OnPushed(data);
        }
        else if (target.TryGetComponent<Rigidbody>(out var rb))
        {
            // fallback físico
            Vector3 dir = (target.transform.position - performer.transform.position).normalized;
            rb.AddForce(dir * force, ForceMode.Impulse);
        }
    }
}
