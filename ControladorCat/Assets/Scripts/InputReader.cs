using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    private Vector3 movement;
    private Vector3 look;

    public Vector3 Movement { get => movement;  set { movement = value; } }

    public Vector3 Look { get => look; set => look = value; }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    public void OnLook(InputValue value)
    {
        look = value.Get<Vector2>();
    }
}
