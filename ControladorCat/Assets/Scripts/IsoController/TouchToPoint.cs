using UnityEngine;
using UnityEngine.InputSystem;

public class TouchToPoint : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private InputActionAsset inputActions;
    [SerializeField] private InputAction touchAction;
    private Vector3? worldPoint;
    public Vector3? WorldPoint { get => worldPoint; set => worldPoint = value; }

    private void OnEnable()
    {
        touchAction = inputActions.FindActionMap("PlayerMain").FindAction("Touch");
        touchAction.Enable();
    }

    private void OnDisable()
    {
        touchAction.Disable();
    }

    private void Update()
    {
        if (Touchscreen.current == null || Touchscreen.current.primaryTouch.press.wasPressedThisFrame == false)
            return;
        Vector2 touchInput = touchAction.ReadValue<Vector2>();

        if (Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            DetectPoint(touchInput);
        }
    }

    private void DetectPoint(Vector2 touchPoint)
    {
        Ray ray = Camera.main.ScreenPointToRay(touchPoint); 
        if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, groundLayer))
        {
            worldPoint = hit.point;
        }
    }
}
