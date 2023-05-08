using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;

    private bool levelCompletedPlayer1 = false;
    private bool levelCompletedPlayer2 = false;

    // Start is called before the first frame update
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player1" && !levelCompletedPlayer1)
        {
            // This is so that we don't repeat the finish song when we touch the checkpoint flag again (during those 2 seconds before we jump to the next level)
            
            levelCompletedPlayer1 = true;
        }
        if (collision.gameObject.tag == "Player2" && !levelCompletedPlayer2)
        {
            // This is so that we don't repeat the finish song when we touch the checkpoint flag again (during those 2 seconds before we jump to the next level)
            
            levelCompletedPlayer2 = true;
        }

        if (levelCompletedPlayer1 && levelCompletedPlayer2)
        {
            finishSound.Play();
            // This is so that the transition to the other level is not abrupt
            Invoke("CompleteLevel", 2f);
        }
    }

    // This is no for this script, but when we finish the game, we want to add some game over method so that we don't jump to a new buildIndex (new scene)
    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
