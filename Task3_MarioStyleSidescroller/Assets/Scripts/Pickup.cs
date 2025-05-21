using UnityEngine;

public class Pickup : MonoBehaviour
{
    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>(); //create a reference to the playerMovement script
    }

    void OnTriggerEnter2D(Collider2D collision) //when something collides with object
    {
        if(collision.tag == "Player") //if the player has collided with object
        {
            Debug.Log("Pickup Collected");
            gameObject.active = false; //hide object
            playerMovement.doubleJump();
        }
    }

}
