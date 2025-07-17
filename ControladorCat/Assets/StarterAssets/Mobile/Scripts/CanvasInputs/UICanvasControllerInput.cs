using UnityEngine;


public class UICanvasControllerInput : MonoBehaviour
{

    [Header("Output")]
    public InputReader inputs;

    public void VirtualMoveInput(Vector2 virtualMoveDirection)
    {
        inputs.Movement = virtualMoveDirection;
    }

    public void VirtualLookInput(Vector2 virtualLookDirection)
    {
        inputs.Look = virtualLookDirection;
    }

    //public void VirtualJumpInput(bool virtualJumpState)
    //{
    //    inputs.JumpInput(virtualJumpState);
    //}

    //public void VirtualSprintInput(bool virtualSprintState)
    //{
    //    inputs.SprintInput(virtualSprintState);
    //}
        
}

