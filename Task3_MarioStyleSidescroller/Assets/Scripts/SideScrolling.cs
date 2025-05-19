using UnityEngine;

public class SideScrolling : MonoBehaviour
{
    private Transform player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform; //finds the object with the tay "player", specifically only their location
    }

    private void LateUpdate() //ensures this happens AFTER the players position has been updated
    {
        Vector3 cameraPosition = transform.position; // Get current camera position
        cameraPosition.x = player.position.x; // Set the cameras x position to match the players x position
        transform.position = cameraPosition; // move camera to new position
    }
}
