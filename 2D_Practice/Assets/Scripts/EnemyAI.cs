using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding; 

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public float speed = 200f;

    // How close the enermy needs to be to the waypoint before it moves to the next one. 
    public float nextWaypointDistance = 3f;

    public Transform enemyGraphics;

    // current path we are following
    Path path;
    // current waypoint along that path
    int currentWaypoint = 0;

    // to know whether or not we have reach the end of the path
    bool reachedEndOfPath = false;

    // reference the seeker script and the rigidbody 2D component. 
    Seeker seeker;
    Rigidbody2D rb; 

    // Start is called before the first frame update
    void Start()
    {
        // to find the seeker componet
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        // generate the path 
        // seeker is responsible for creating the path 
        // define a start point (current position of our enemy (rb.position). End of the Path (target position)
        // third parameter is the function we call whenever the path is calculated
        // depending on the complexity of the scene generating a path may take a while and we don't want our game to be hung up on generating a path.
        // it should do it on the background and notify when it's done
        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }
    // generated path 
    void OnPathComplete(Path p)
    {
        // check if we did not get any errors 
        if (!p.error)
        {
            // set current path to p (the newly generated path)
            path = p;
            // reset the progress along the path (start at the beginning of the new path)
            currentWaypoint = 0; 
        }
    }
    // Update is called once per frame
    // FixedUpdate (only called if fixed number of times per second???) 
    void FixedUpdate()
    {
        // if there is not path
        if (path == null)
            return;
        
        // make sure there are more waypoints in the path and we have not reach the end
        // if this condition is true, we reached the end of the path
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        // move the bird 
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        // add force to the enemy 
        rb.AddForce(force);
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++; 
        }

        // If the velocity is positive, the enemy is moving to the right, and we update the transform component respectively. 
        if (rb.velocity.x >= 0.01f)
        {
            enemyGraphics.localScale = new Vector3(-1f, 1f, 1f);
        }

        // If the velocity is negative, the enemy is moving to the left, and we update the transform component respectively. 
        else if (rb.velocity.x <= -0.01f)
        {
            enemyGraphics.localScale = new Vector3(1f, 1f, 1f);
        }

    }
}
