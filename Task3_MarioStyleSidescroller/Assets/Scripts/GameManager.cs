using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

   [SerializeField] private int startingLives = 3;
   public float currentLives{ get; private set; }
   
   private PlayerSpawn playerSpawn;
   private UI userInterface;


    void Start() 
    {
        playerSpawn = FindObjectOfType<PlayerSpawn>(); //get a reference to the PlayerSpawn script
        userInterface = FindObjectOfType<UI>(); //get a reference to the UI script

        Time.timeScale = 1; //makes sure game isnt paused when scene is loaded
        currentLives = startingLives; //set the currentLives to startingLives
        playerSpawn.SetSpawn(); //set players spawn point
    }


    public void LoseLife()
    {
        if  (currentLives <= 0) //ig the current lives is 0 then end the game
        {
            EndGame();
        }
        else //if the current lives are greater than 0
        {
            currentLives -= 1; //take away a life
            playerSpawn.SendToSpawn(); //send player back to spawn
        }
    }


    public void StartGame()
    {
        SceneManager.LoadScene("level1"); //load the first level
    }

    public void NextLevel() //send player to the next level
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex; //get the current level
        int totalLevels = SceneManager.sceneCountInBuildSettings; //get the total levels

        if (currentLevel == totalLevels - 1) //check if player is on the last level
        {
            EndGame(); //game ends
        }
        else //load the next level
        {
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }

    public void EndGame() //game ends
    {
        Time.timeScale = 0; //pause game
        userInterface.GameOverScreen(); //show game over screen
    }
}