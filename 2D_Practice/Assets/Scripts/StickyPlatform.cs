/*
    This code defines a StickyPlatform class that is attached to a platform game object in the game. When the player character collides with the platform, it becomes "sticky" 
    and moves along with the platform. When the player character leaves the platform, it becomes un-sticky and stays in place.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{

    /*
        The OnTriggerEnter2D method is called when the player character enters the trigger area of the platform collider. It checks if the collision parameter (which is the collider 
        of the game object that entered the trigger) belongs to the "Character" game object by checking its name. If it does, then it sets the parent of the character's transform to 
        the transform of the sticky platform. This makes the character a child of the platform, and as a result, it moves along with the platform when the platform moves.
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Character")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    /*
        The OnTriggerExit2D method is called when the player character exits the trigger area of the platform collider. It checks if the collision parameter belongs to the "Character" game 
        object by checking its name. If it does, then it sets the parent of the character's transform to null, which removes the character from being a child of the platform. 
        This makes the character un-sticky and stay in place. 
    */
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Character")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
    
    
}