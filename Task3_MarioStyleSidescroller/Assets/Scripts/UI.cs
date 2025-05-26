using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
   private GameManager gameManager;
   [SerializeField] private Image healthBar;
   [SerializeField] private GameObject gameOverUI;
   

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); //create a reference to the game manager
    }

    void Update() 
    {
        healthBar.fillAmount = gameManager.currentLives / 10; //update the health bar
    }


    public void GameOverScreen()
    {
        gameOverUI.SetActive(true); //show the game over screen
    }
    
    public void PlayAgain() //Play again button
    {
        gameManager.StartGame(); //Start the game again from the first level
    }

    public void ExitButton() //Exit button
    {
        Application.Quit(); //close the application
        Debug.Log("Game closed");
    }
}
