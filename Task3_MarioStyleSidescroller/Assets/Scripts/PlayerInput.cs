using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>(); //create a reference to the playerMovement script
    }

    // Update is called once per frame
    void Update()
    {
        float inputAxis = Input.GetAxis("Horizontal"); // Gets horizontal input (A/D or Left/Right arrow keys)
        playerMovement.HorizontalMovement(inputAxis); //move player

        if (Input.GetButtonDown("Jump")) //If the jump button is pressed (space), start jumping
        {
            playerMovement.Jump();
        }

        bool HoldingJump = Input.GetButton("Jump");
        playerMovement.ApplyGravity(HoldingJump); // Apply gravity when player is not grounded
    }
}
