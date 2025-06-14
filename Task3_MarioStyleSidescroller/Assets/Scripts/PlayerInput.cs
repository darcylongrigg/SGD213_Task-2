using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Movement movement;

    void Start()
    {
        movement = GetComponent<Movement>(); //create a reference to the playerMovement script
    }

    // Update is called once per frame
    void Update()
    {
        float inputAxis = Input.GetAxis("Horizontal"); // Gets horizontal input (A/D or Left/Right arrow keys)
        movement.HorizontalMovement(inputAxis); //move player

        if (Input.GetButtonDown("Jump")) //If the jump button is pressed (space), start jumping
        {
            movement.Jump();
        }

        bool HoldingJump = Input.GetButton("Jump");
        movement.ApplyGravity(HoldingJump); // Apply gravity when player is not grounded
    }
}
