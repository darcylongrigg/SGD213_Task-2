using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    private Vector2 spawnPoint; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void SetSpawn()
    {
        spawnPoint = transform.position; //set the spawnPoint to the current trnasform position
    }

    public void SendToSpawn() //send the player back to their spawn point
    {
        transform.position = spawnPoint; //set the transform position to the spawnPoint     
    }

}
