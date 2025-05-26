using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    
    private Collider2D enemyBodyCollision;
    private GameManager gameManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyBodyCollision = GetComponent<Collider2D>(); //create a reference to the Collider
        gameManager = FindObjectOfType<GameManager>(); //create a reference to the game manager
    }

    void OnTriggerEnter2D(Collider2D collision) //when something collides with object
    {
        if(collision.tag == "Player") //if the player has collided with object
        {
            gameManager.LoseLife();
        }
    }

}
