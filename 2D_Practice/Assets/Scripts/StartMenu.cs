/*
    Script that adds functionality to the start button.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Create a public method so that the button can access it 
    // When we click the start button, this method will be called and load the next scene? which is level one?????????????????????
    public void StartGame()
    {
        SceneManager.LoadScene(/*SceneManager.GetActiveScene().buildIndex + 1*/ 1);
    }
}
