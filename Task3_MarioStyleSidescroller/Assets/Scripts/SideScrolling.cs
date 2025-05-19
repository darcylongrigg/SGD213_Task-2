using UnityEngine;

public class SideScrolling : MonoBehaviour
{
    private Transform player;

    private float minX;
    private float maxX;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform; //finds the object with the tay "player", specifically only their location
    }


    private void Start()
    {
        //Finds the position of the boundaries
        Transform leftBound = GameObject.Find("Boundary Left")?.transform;
        Transform rightBound = GameObject.Find("Boundary Right")?.transform;

        if (leftBound != null && rightBound != null)
        {
            //Sets the boundary positions to minX and maxX
            minX = leftBound.position.x;
            maxX = rightBound.position.x;

            //As the camera position refers to the center, the sides may go past the boundary
            //This adjusts the min and max X bounds so the camera view stays fully inside the level
            float cameraHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;
            minX += cameraHalfWidth;
            maxX -= cameraHalfWidth;

        }
    }
    private void LateUpdate() //ensures this happens AFTER the players position has been updated
    {
        Vector3 cameraPosition = transform.position; // Get current camera position
        cameraPosition.x = player.position.x; // Set the cameras x position to match the players x position
        cameraPosition.x = Mathf.Clamp(cameraPosition.x, minX, maxX);
        transform.position = cameraPosition; // move camera to new position
    }
}
