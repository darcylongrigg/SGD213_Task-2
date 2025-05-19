using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    private new Rigidbody2D rigidbody;

    private Vector2 velocity;
    private float inputAxis;

    
    public float moveSpeed = 8f;
    public float maxJumpHeight = 4f;
    public float maxJumpTime = 1f;

    public float jumpForce => (2f * maxJumpHeight) / (maxJumpTime / 2f); //Calculates the jump force needed to reach the max jump height in half the jump time
    public float gravity => (-2f * maxJumpHeight) / Mathf.Pow((maxJumpTime / 2f), 2); // Calculates the gravity needed to bring the player back down

    public bool grounded { get; private set; }
    public bool jumping { get; private set; }



private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }



    private void Update()
    {
        HorizontalMovement();

        grounded = rigidbody.Raycast(Vector2.down); // Checks if player is touching the ground by casting a box down

        if (grounded) // If player is on the ground, allow for grounded actions (like jumping)
        {
            GroundedMovement();
        }

        ApplyGravity(); // Apply gravity when player is not grounded
    }



    private void HorizontalMovement()  
    {
        inputAxis = Input.GetAxis("Horizontal"); // Gets horizontal input (A/D or Left/Right arrow keys)
        velocity.x = Mathf.MoveTowards(velocity.x, inputAxis * moveSpeed, moveSpeed /** Time.deltaTime*/); //Changes the movement speed to match the players input
    }



    private void GroundedMovement() //Handles jumping when player is on the ground
    {
        velocity.y = Mathf.Max(velocity.y, 0f); //Stops any downward movement (resets fall velocity)
        jumping = velocity.y > 0f; // Check if player is currently going up
        
        if (Input.GetButtonDown("Jump")) //If the jump button is pressed (space), start jumping
        {
            velocity.y = jumpForce; //apply jump force
            jumping = true;
        }
    }


    private void ApplyGravity()
    {
        bool falling = velocity.y < 0f || !Input.GetButton("Jump"); //checks if player is falling OR has let go of the jump button
        float multiplier = falling ? 2f : 1f; //stronger gravity when falling to make it 'feel' better

        velocity.y += gravity * multiplier * Time.deltaTime;
        velocity.y = Mathf.Max(velocity.y, gravity / 2f); // prevents player from falling too fast
    }


    private void FixedUpdate()
    {
        //Gets current position of the object, add movement based on velocity and time, then move object to new position
        Vector2 position = rigidbody.position;
        position += velocity * Time.fixedDeltaTime;

        rigidbody.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D collision) // checks if the player has hit their 'head' on an object, if so, set velocity.y to 0 so they start falling
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("PickUp")) //ignore collisions with objects in the pickup layer
        {
            if (transform.DotTest(collision.transform, Vector2.up)) 
            {
                velocity.y = 0f;
            }
        }
    }

}
