using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target; 
    [SerializeField] private float smoothTime = 0.2f;
    [SerializeField] private float cameraCollisionBuffer = 0.2f; 

    private Vector3 currentVelocity;
    private Vector3 initialOffset;

    void Start()
    {
        initialOffset = transform.position - target.position;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position;

        Ray ray = new Ray(target.position, desiredPosition - target.position);
        float distance = Vector3.Distance(target.position, desiredPosition);

        if (Physics.Raycast(ray, out RaycastHit hit, distance))
        {
            desiredPosition = hit.point - ray.direction * cameraCollisionBuffer;
        }
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, smoothTime);
    }
}
