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
        SetPriorityInputDevice(direction, inputDevice);
        if (IsNotUsingPriorityInputDevice(inputDevice))
        {
            return;
        }
            
        FaceCorrectDirection(direction);
        Animate(direction);
        ApplyMovement(direction);
    }

    private bool IsNotUsingPriorityInputDevice(object inputDevice)
    {
        return inputDevice != priorityDevice;
    }

    private void FaceCorrectDirection(Vector2 direction)
    {
        if (IsNotFacingCorrectDirection(direction));
        {
            FlipFacingDirection();
        }
    }

    private void FlipFacingDirection()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    private bool IsNotFacingCorrectDirection(Vector2 direction)
    {
        return direction.x > 0 && transform.localScale.x < 0 || direction.x < 0 && transform.localScale.x > 0;
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

    private void Animate(Vector2 direction)
    {
        Animator.SetFloat("Horizontal", Mathf.Abs(direction.x));
        Animator.SetFloat("Vertical", Mathf.Abs(direction.y));
    }
    
}
