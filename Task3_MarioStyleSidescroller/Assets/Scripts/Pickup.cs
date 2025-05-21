using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Collider2D pickupCollider;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite activeSprite;
    [SerializeField] private Sprite disabledSprite;
    [SerializeField] private float pickupTimer = 5f; //pickup delay

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>(); //create a reference to the playerMovement script
        pickupCollider = GetComponent<Collider2D>(); //create a reference to the Collider
        spriteRenderer = GetComponent<SpriteRenderer>(); //create a reference to the spriteRenderer
    }

    void OnTriggerEnter2D(Collider2D collision) //when something collides with object
    {
        if(collision.tag == "Player") //if the player has collided with object
        {
            Debug.Log("Double Jump Enabled");
            DisablePickup();
            playerMovement.DoubleJumpEnable();
            StartCoroutine(PowerUpEnd(pickupTimer)); 
        }
    }


    IEnumerator PowerUpEnd(float delay) //disable double jump after a certain amount of seconds
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Double Jump Disabled");
        playerMovement.DoubleJumpDisable(); //disable double jump
        ResetPickup(); //reset pickup
    }

    void DisablePickup()
    {
        if (spriteRenderer != null) //check object has a spriteRenderer
        {
            spriteRenderer.sprite = disabledSprite; //change sprite
        }

        if (pickupCollider != null) //check object has a Collider
        {
            pickupCollider.enabled = false; //disable collider
        }
    }

    void ResetPickup()
    {
        if (spriteRenderer != null) //check object has a spriteRenderer
        {
            spriteRenderer.sprite = activeSprite; //reset sprite
        }
        
        if (pickupCollider != null) //check object has a Collider
        {
            pickupCollider.enabled = true; //enable collider
        }
    }
}
