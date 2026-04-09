using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = GameParameters.PlayerSpeed;
    public Rigidbody2D Rigidbody;
    public Animator Animator;

    private object priorityDevice = null;
    
    // MOVE METHOD
    // check which device player is using - KEYBOARD or GAME CONTROLLER
    public void Move(Vector2 direction, object inputDevice)
    {
        // MOVE
        SetPriorityInputDevice(direction, inputDevice);
        
        // ANIMATOR
        ApplyMovement(direction);
        
        // Apply Force
        
    }

    private void SetPriorityInputDevice(Vector2 direction, object inputDevice)
    {
        if (IsMoving(direction))
        {
            priorityDevice = inputDevice;
        }
    }

    private bool IsMoving(Vector2 direction)
    {
        // this checks both the X-AXIS and Y-AXIS
        // to make sure that they're NOT equal to 0
        return direction != Vector2.zero;
    }

    private void ApplyMovement(Vector2 direction)
    {
        Rigidbody.linearVelocity = direction * Speed;
    }
}
