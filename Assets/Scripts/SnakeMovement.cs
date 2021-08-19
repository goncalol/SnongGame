using System;
using UnityEngine;

public class SnakeMovement : MonoBehaviour {

    public GameObject Destination;
    public GameObject nextBodyPart;
    public int speed;
    private WayPoint waypoint;
    private bool canMove;
    private WayPoint initialWayPoint;
    private BodyPart bodyPart;
    private GameObject initialDestination;

    void Start () {
        waypoint = Destination.GetComponent<WayPoint>();
        bodyPart = nextBodyPart.GetComponent<BodyPart>();
        initialWayPoint = waypoint;
        initialDestination = Destination;
        //canMove = true;
	}
	
	void Update () {
        if (canMove)
        {
            var mypos = new Vector2(transform.position.x, transform.position.y);
            var destpos = (Vector2)Destination.transform.position;
            if (mypos != destpos)
            {
                var speedlocal = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(mypos, Destination.transform.position, speedlocal);
                bodyPart.UpdatePosition(transform, speedlocal);
            }
            else
            {
                Destination = waypoint.GetNextDestination();
                transform.Rotate(Vector3.forward * -90);
                waypoint = Destination.GetComponent<WayPoint>();
            }
        }
    }

    public void SetMoving(bool isMoving)
    {
        canMove = isMoving;
    }

    public void SetPosition(Vector2 initialPosition)
    {
        transform.position = initialPosition;
        Destination = initialDestination;
        waypoint = initialWayPoint;
        transform.rotation = Quaternion.identity;
    }
}
