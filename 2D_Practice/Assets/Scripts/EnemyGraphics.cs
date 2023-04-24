using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGraphics : MonoBehaviour
{
    // or AIPath 2D, 3D??
    public AIPath aiPath;
 
    // Update is called once per frame
    void Update()
    {
        // If the velocity is positive, the enemy is moving to the right, and we update the transform component respectively. 
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        // If the velocity is negative, the enemy is moving to the left, and we update the transform component respectively. 
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
