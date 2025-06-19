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
        movement = playerInput.actions["Move"].ReadValue<Vector3>();
    }
}
