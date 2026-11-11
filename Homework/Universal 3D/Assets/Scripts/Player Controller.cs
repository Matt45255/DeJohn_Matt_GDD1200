using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    //Movement tuning shown in inspector
    public float speed = 5.0f;
    public float turnSpeed = 100f;

//Input System action exposed in Inspector for binding
    public InputAction MoveAction;
    
    //Current input value (x = left/right, y = forward/back,) private for internal use
    private Vector2 moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Enable the MoveAction so it starts reading inputs
        MoveAction.Enable();
    }


    // Update is called once per frame
    void Update()
    {
        //Deltatime is based on the difference in time between the current and previous frame.
        //If we have a 0 second difference between frames, we are good
        //if there is a discrepency, we need to compensate
        //We do this because hardware is extremely inconsistent
        
        //Read the 2D vector from the MoveAction (x: horizontal, y: vertical)
        moveInput = MoveAction.ReadValue<Vector2>();

        //Move the vehicle forward/back along its z axis using the y component
        transform.Translate(Vector3.forward * Time.deltaTime * speed * moveInput.y);

        //Rotate around y axis using the x component
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * moveInput.x);
        
    }
}
