using UnityEngine;
using UnityEngine.Rendering;

public class Movement : MonoBehaviour
{
    private new Rigidbody2D rigidbody;

    private Vector2 velocity;

    
    [SerializeField]private float moveSpeed = 2f;
    [SerializeField]private float maxJumpHeight = 4f;
    [SerializeField]private float maxJumpTime = 1f;
    
    
    [SerializeField] private int maxJumps = 1; //max jumps player can do
    private int jumpsRemaining;
    

    public float jumpForce => (2f * maxJumpHeight) / (maxJumpTime / 2f); //Calculates the jump force needed to reach the max jump height in half the jump time
    public float gravity => (-2f * maxJumpHeight) / Mathf.Pow((maxJumpTime / 2f), 2); // Calculates the gravity needed to bring the player back down

    public bool grounded { get; private set; }
    private bool wasGrounded;




    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }



    private void Update()
    {

        grounded = rigidbody.Raycast(Vector2.down); // Checks if player is touching the ground by casting a box down

        if (grounded) // If player is on the ground, allow for grounded actions (like jumping)
        {
            GroundedMovement();
        }

      
        
        wasGrounded = grounded;
    }



    public void HorizontalMovement(float inputAxis)
    {
        velocity.x = inputAxis * moveSpeed; //Instantly sets horizontal velocity based on player input and movement speed
     
    }



    private void GroundedMovement() //Handles jumping when player is on the ground
    {
        velocity.y = Mathf.Max(velocity.y, 0f); //Stops any downward movement (resets fall velocity)
        if (!wasGrounded) //when player lands on the ground
        {
            jumpsRemaining = maxJumps; //reset jumpsRemaining
        }
    }


    public void Jump()
    {
        if (jumpsRemaining > 0) //check if player has any jumps remaining
        {
            velocity.y = jumpForce; //apply jump force
            jumpsRemaining--;
        }
    }

    public void DoubleJumpEnable() //allows player to double jump
    {

        maxJumps = 2; //sets max jumps to 2
    }

    public void DoubleJumpDisable() //disables double jump
    {
        maxJumps = 1; //sets max jumps back to 1
    }



    public void ApplyGravity(bool HoldingJump)
    {
        bool falling = velocity.y < 0f || !HoldingJump; //checks if player is falling OR has let go of the jump button
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
