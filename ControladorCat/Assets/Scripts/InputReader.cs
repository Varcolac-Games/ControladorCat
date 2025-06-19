using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    private PlayerInput playerInput;
    private Vector3 movement;

    public Vector3 Movement { get => movement; }

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        MovementInput();
    }

    private void MovementInput()
    {
        Vector2 movementVector = playerInput.actions["Move"].ReadValue<Vector2>();
        movement = new Vector3(movementVector.x, 0f, movementVector.y);
    }
}
