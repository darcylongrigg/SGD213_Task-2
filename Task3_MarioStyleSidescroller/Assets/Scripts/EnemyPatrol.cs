using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    //patrol points (where the enemy moves towards)
    [SerializeField] private GameObject pointA; //left point
    [SerializeField] private GameObject pointB; //right point
    private Transform currentPoint;

    private Movement movement;
    private float direction;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movement = GetComponent<Movement>(); //create a reference to the movement script component
        currentPoint = pointB.transform; //initally set currentPoint to pointB

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position; 
        if(currentPoint == pointB.transform) //if the currentPoint is pointB
        {
            direction = 1f; //set direction to the right
        }
        else //if currentPoint is pointA
        {
            direction = -1f; //set direction to the left
        }

        movement.HorizontalMovement(direction); //enemy moves towards point


        //when the enemy reaches pointA or pointB
        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f)
        {
            if(currentPoint == pointB.transform) //if currentPoint is pointB
            {
                currentPoint = pointA.transform; //set currentPoint to pointA
            }
            else //if currentPoint is point A
            {
                currentPoint = pointB.transform; //Set currentPoint to pointB
            }
            
        }
    }

    private void OnDrawGizmos() //visualize the patrol points in editor
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}
