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
    }

    private void Update()
    {
        Vector3 inputs = inputReader.Movement;
        Vector3 viewDir = playerTransform.position - new Vector3(Camera.main.transform.position.x, playerTransform.position.y, Camera.main.transform.position.z);
        orientation.forward = viewDir.normalized;
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
        if (inputDir != Vector3.zero)
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
}
