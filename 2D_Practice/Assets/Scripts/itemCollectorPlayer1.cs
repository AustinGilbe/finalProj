/*
    This script is responsible for managing a player's ability to collect items in the game world and updating the player's score based on the items collected.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using scoreMap;
using TMPro;

public class itemCollectorPlayer1 : MonoBehaviour
{
    //private scoreMap sm = new scoreMap();
    /*
        Define a private integer variable called points, which will be used to keep track of the player's score. Define two serialized private variables: a TextMeshProUGUI 
        object called Score, and an AudioSource object called collectSound. The Score object will be used to display the player's current score on the screen, and the collectSound 
        object will be used to play a sound effect when an item is collected. The collectSound field is marked with the [SerializeField] attribute, which allows it to be assigned a 
        value in the Unity Editor. Once the collectSound field has been assigned a valid AudioSource component in the scene, the Play() method of the AudioSource component is called 
        each time the player collects a Melon in the OnTriggerEnter2D method, causing the sound to play.
    */
    [SerializeField] private TextMeshProUGUI ScorePlayer1;
    [SerializeField] private AudioSource collectSound;

    // The private method OnTriggerEnter2D will be called automatically when the player collides with a trigger collider on an item in the game world.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the object has the "Melon" tag, the player has collided with a collectible item.
        if (collision.gameObject.CompareTag("Melon"))
        {
            //  Play the collectSound audio clip using the Play method of the AudioSource object.
            collectSound.Play();

            // Destroy the collision.gameObject, which is the game object that the player collided with (in this case, the Melon).
            Destroy(collision.gameObject);
            //  Increments the points variable by 500.
            scoreMap.all_scores["Ninja Frog"] = scoreMap.all_scores["Ninja Frog"] + 500;
            // The script updates the text of the Score object to display the current score, which is the value of the points variable.
            ScorePlayer1.text = "Score Player 1: " + scoreMap.all_scores["Ninja Frog"];
        }
    }
}