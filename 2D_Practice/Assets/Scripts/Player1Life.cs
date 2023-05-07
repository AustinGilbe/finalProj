/*
    This script handles the player's life and death in a game.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player1Life : MonoBehaviour
{
    /*  Declare a private variable called body of type Rigidbody2D that will be used to store the player's Rigidbody2D component.
        Declare a private variable called anim of type Animator that will be used to store the player's Animator component.
        Declare a private AudioSource variable called deathSound and makes it visible in the Unity Editor [SerializeField] for easy assignment of 
        an audio clip to play when the player dies.
    */
    private Rigidbody2D body;
    private Animator anim;
    [SerializeField] private AudioSource deathSound;
    [SerializeField] private TextMeshProUGUI ScorePlayer1;
    public GameObject otherPlayer;

    /*
        The Start() method is part of the MonoBehaviour class in Unity method that is called when the script is first enabled. It assigns the body and anim variables to the player's 
        Rigidbody2D and Animator components, respectively.
    */
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    /*
        OnCollisionEnter2D(Collision2D collision) is a built-in Unity method that is called when the player's Collider2D component collides with another Collider2D component. It checks if 
        the collided object has the "Trap" tag, and if so, calls the Die() method.
    */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            // User-defined method.
            // Die();
            LoseLives();
        }
    }

    // The private Die() method is called when the player collides with a trap object. It plays the deathSound, sets the player's bodyType to RigidbodyType2D.Static so they can't move after death,
    // and sets the "death" trigger on the anim component which will trigger the "death" animation.
    private void LoseLives()
    {
        deathSound.Play();
        scoreMap.all_scores["Ninja Frog"] = scoreMap.all_scores["Ninja Frog"] - 100;
        ScorePlayer1.text = "Score Player 1: " + scoreMap.all_scores["Ninja Frog"];

        if (scoreMap.all_scores["Ninja Frog"] == 0)
        {
            GameOverBeforeCompletingAllLevels.isGameOver = true;
            gameObject.SetActive(false);
            otherPlayer.SetActive(false);
        }
        //body.bodyType = RigidbodyType2D.Static; //So the player cant move after death
        //anim.SetTrigger("death");
    }


    // The RestartLevel() uses the SceneManager class which is part of the "UnityEngine.SceneManagement." The method is used to restart the current level.
    /*private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }*/

}