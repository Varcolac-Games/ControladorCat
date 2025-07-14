using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    private Player playerInput;
    private Vector3 movement;

    public Vector3 Movement { get => movement; private set { movement = value; } }

    private void Awake()
    {
        playerInput = new Player();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Update()
    {
        Vector2 movementInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();
        Movement = new Vector3(movementInput.x, 0f, movementInput.y);
    }
    
}
