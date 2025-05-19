using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); //create a reference to the game manager
    }
    
    
    void OnTriggerEnter2D(Collider2D collision) //when something collides with object
    {
        if(collision.tag == "Player") //if the player has collided with object
        {
            Debug.Log("Sending to Next Level"); 
            gameManager.NextLevel(); //send the player to the next level
        }
    }

}
