/*
    This script defines a WaypointFollower class that is attached to a game object in the game. 
    This script is used to make a game object follow a series of waypoints in the game. When the object reaches a waypoint, it moves towards the next one.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    // The class has an array of waypoints and a currentWaypointIndex variable that keeps track of the current waypoint the object is moving towards.
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;

    /*
        In the Update method, the code checks the distance between the current waypoint and the object's current position. If the object is close enough to the current
        waypoint (less than 0.1 units away), the current waypoint index is incremented, and if the new index exceeds the number of waypoints in the array, it is reset to zero.
    */
    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        // Then, the transform.position of the game object is updated using the Vector2.MoveTowards method to move towards the next waypoint at a speed defined by the speed variable.
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
