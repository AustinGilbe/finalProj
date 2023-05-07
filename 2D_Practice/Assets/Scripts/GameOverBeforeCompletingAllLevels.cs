using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverBeforeCompletingAllLevels : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen; 

    private void Awake()
    {
        isGameOver = false;
    }

    void Update()
    {
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void ReplayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        scoreMap.all_scores["Ninja Frog"] = 500;
        scoreMap.all_scores["Mask Dude"] = 500; 
        SceneManager.LoadScene("Level 1");
    }
}
