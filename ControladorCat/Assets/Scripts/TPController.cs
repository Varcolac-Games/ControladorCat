using UnityEngine;

public class TPController : MonoBehaviour
{
    [Header("Movement References")]
    private Transform playerTransform;
    [SerializeField] private Transform orientation;
    [SerializeField] private Rigidbody rbPlayer;
    [SerializeField] private Transform playerObj;
    [SerializeField] private float speedMovement;
    [SerializeField] private float rotationSpeed;

    [Header("Camera")]
    [SerializeField] private Transform cameraFollowTarget;
    private float xRotation;
    private float yRotation;
    [SerializeField] private float clampMin;
    [SerializeField] private float clampMax;
    [SerializeField] private float lookSensitivity = 0.1f;
    [SerializeField] private float cameraRotationSmoothness = 3f;
    private Quaternion currentRotation;

    [Header("Input References")]
    private InputReader inputReader;
    private Vector3 inputDir;

    [Header("Animation References")]
    [SerializeField] private Animator anim;


    private void Awake()
    {
        playerTransform = GetComponent<Transform>();
        inputReader = GetComponent<InputReader>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        currentRotation = cameraFollowTarget.rotation;
    }

    private void Update()
    {
        Vector3 inputs = new Vector3(inputReader.Movement.x, 0f, inputReader.Movement.y);
        Vector3 viewDir = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up).normalized;
        orientation.forward = viewDir;
        inputDir = orientation.forward * inputs.z + orientation.right * inputs.x;
        float moveAmount = inputDir.magnitude;
        anim.SetFloat("Speed", moveAmount);
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        if (inputDir.magnitude > 0.1f)
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.fixedDeltaTime * rotationSpeed);
            Vector3 moveVelocity = inputDir.normalized * speedMovement;
            rbPlayer.velocity = new Vector3(moveVelocity.x, rbPlayer.velocity.y, moveVelocity.z);
        }
        else
        {
            rbPlayer.velocity = new Vector3(0, rbPlayer.velocity.y, 0);
        }
    }

    private void LateUpdate()
    {
        CameraRotation();
    }

    void CameraRotation()
    {
        xRotation += inputReader.Look.y * lookSensitivity;
        yRotation += inputReader.Look.x * lookSensitivity;
        xRotation = Mathf.Clamp(xRotation, clampMin, clampMax);
        Quaternion targetRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        currentRotation = Quaternion.Lerp(currentRotation, targetRotation, Time.deltaTime * cameraRotationSmoothness);
        cameraFollowTarget.rotation = currentRotation;
    }
}
