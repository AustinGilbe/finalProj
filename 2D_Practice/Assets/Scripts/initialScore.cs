using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class initialScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScorePlayer1;
    [SerializeField] private TextMeshProUGUI ScorePlayer2;
    // Start is called before the first frame update
    void Start()
    {
        ScorePlayer1.text = "Score Player 1: " + scoreMap.all_scores["Ninja Frog"];
        ScorePlayer2.text = "Score Player 2: " + scoreMap.all_scores["Mask Dude"];
    }

}
