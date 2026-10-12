using UnityEngine;
using UnityEngine.InputSystem; 

/// <summary>
/// Moves forward/backward and rotates with WASD/Arrow keys.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Tooltip("Forward/back speed (units/sec).")]
    public float speed = 5.0f;

    [Tooltip("Turn speed (degrees/sec).")]
    public float rotationSpeed = 120.0f;

//We have out rigidbody as a object so twe can call its methods and use its values, like transforms and stuff
//Objects SHOULD be private
    private Rigidbody rb; 
//Start happens before update, should use this for object reference or creation
//we have a method that sets everything up and then it's done
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //the null, warning that something went wrong if we didn't get a Rigidbody component
        if (rb == null) Debug.LogWarning("PlayerController needs a Rigidbody.");
    }
//Update is locked, normally, to 60fps
//Fixedupdate is used independently of the update for input and other infomation
//FixedUpdate ensures to the best of its ability that certain things will be taken care of and proccessed regardless of update

    private void FixedUpdate() 
    {
        //we can zero out vectors
        Vector2 moveInput = Vector2.zero;

        // Forward/backward movement by 1 unit
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)   moveInput.y = 1f;
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) moveInput.y = -1f;

        // Left/right (rotation)
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) moveInput.x = -1f;
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)moveInput.x = 1f;

        // Move in facing direction 
        //Transforming a vector basically means we add or subtract from the movement vector in the x, y, and z if 3d
        Vector3 movement = transform.forward * moveInput.y * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);

        // Y-axis rotation (invert when going backwards)
        //not moving, just turning
        float turnDirection = moveInput.x;
        if (moveInput.y < 0)
            turnDirection = -turnDirection;
        //calculate the turn
        float turn = turnDirection * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
