using UnityEngine;
using UnityEngine.AI;

public class CatController : MonoBehaviour
{
    [SerializeField] private TouchToPoint touchPoint;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform playerObj;

    [Header("Rotation")]
    [SerializeField] private float rotationSpeed;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (touchPoint != null && touchPoint.WorldPoint.HasValue)
        {
            Vector3 destination = touchPoint.WorldPoint.Value;

            agent.SetDestination(destination);

            touchPoint.WorldPoint = null;
        }

        if (agent.velocity.magnitude > 0.1f)
        {
            Quaternion lookRotation = Quaternion.LookRotation(agent.velocity.normalized);
            playerObj.rotation = Quaternion.Slerp(playerObj.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        }
    }
}
