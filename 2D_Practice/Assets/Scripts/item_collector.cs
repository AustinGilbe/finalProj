using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class item_collector : MonoBehaviour
{
    private int points = 0;
    [SerializeField] private TextMeshProUGUI Score;
    [SerializeField] private AudioSource collectSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Melon"))
        {
            collectSound.Play();
            Destroy(collision.gameObject);
            points += 500;
            Score.text = "Score: " + points;
        }
    }
}
