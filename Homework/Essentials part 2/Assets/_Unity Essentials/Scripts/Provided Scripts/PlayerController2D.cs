using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2D : MonoBehaviour
{
    // Public variables
    public float speed = 5f; // The speed at which the player moves
    public bool canMoveDiagonally = true; // Controls whether the player can move diagonally
    
    public InputActionReference moveAction; //This is how we determine if there was an input for movement

    // Private variables 
    private Rigidbody2D rb; // Reference to the Rigidbody2D component attached to the player
    private Vector2 movement; // Stores the direction of player movement, stored as a triangle
    private bool isMovingHorizontally = true; // Flag to track if the player is moving horizontally
    // Called when the script is enabled
    private void OnEnable()
    {
        moveAction.action.Enable();
    }
    //This is all the stuff that runs at the very beginning and doesn't run again, it can run on process run or on creation
    void Start()
    {
        // Initialize the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
        // Prevent the player from rotating
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    //This is the 60 fps stuff, BE CAREFUL, loops and other tools are very dangerous here, so searches, sorting, that type of stuff
    void Update()
    {
        // Get player input from keyboard or controller
        // We are creting a Vector2 to store the movement input from the player
        //Specified as Vector2 because it could also be Vector3
        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();
        // We have a float value that represents the x and y input as a float
        float horizontalInput = moveInput.x;
        float verticalInput = moveInput.y;

        // Check if diagonal movement is allowed
        if (canMoveDiagonally)
        {
            // Set movement direction based on input

            movement = new Vector2(horizontalInput, verticalInput);
            // Optionally rotate the player based on movement direction
            // We froze rotatiton, so we don't end up spinning out
            RotatePlayer(horizontalInput, verticalInput);
        }
        else
        {
            // Determine the priority of movement based on input
            // We are prioritizing horizontal movement over vertical movement
            if (horizontalInput != 0)
            {
                // bools to check if the player is moving horizontally or vertically
                isMovingHorizontally = true;
            }
            //Checking for vertical while also seeing horizontal is 0
            else if (verticalInput != 0)
            {
                isMovingHorizontally = false;
            }

            // Set movement direction and optionally rotate the player
            if (isMovingHorizontally)
            {
                // We have horizontal input, we do not have vertical, so we just move horizontally based on the input
                movement = new Vector2(horizontalInput, 0);
                RotatePlayer(horizontalInput, 0);
            }
            else
            {
                // Exact opposite, proved we had no horizontal input, so we move vertically based on the input
                movement = new Vector2(0, verticalInput);
                RotatePlayer(0, verticalInput);
            }
        }
    }
    // To be covered in great detail later
    void FixedUpdate()
    {
        // Apply movement to the player in FixedUpdate for physics consistency
        rb.linearVelocity = movement * speed;
    }
    // We can rotate the player as we wish
    void RotatePlayer(float x, float y)
    {
        // If there is no input, do not rotate the player
        if (x == 0 && y == 0) return;

        // Calculate the rotation angle based on input direction
        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        // Apply the rotation to the player
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    // Disable the move action when the player is disabled
    private void OnDisable()
    {
        moveAction.action.Disable();
    }
}
